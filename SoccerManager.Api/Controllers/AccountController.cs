using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoccerManager.Api.Security;
using SoccerManager.Domain.Commands.Teacher.Input;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SoccerManager.Api.Controllers
{
    public class AccountController : Controller
    {
        private Teacher _teacher;
        public readonly ITeacherRepository _repository;
        private readonly TokenOptions _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AccountController(IOptions<TokenOptions> jwtOptions, ITeacherRepository repository)
        {
            _repository = repository;
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public async Task<IActionResult> Post([FromForm] AuthenticateTeacherCommand command)
        {
            if (command == null)
                return BadRequest(new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var identity = await GetClaims(command);

            if(identity == null)
                return BadRequest(new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.Email),
                new Claim(JwtRegisteredClaimNames.NameId, command.Email),
                new Claim(JwtRegisteredClaimNames.Email, command.Email),
                new Claim(JwtRegisteredClaimNames.Sub, command.Email),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("SoccerManager")
            };

            var jwt = new JwtSecurityToken(
               issuer: _tokenOptions.Issuer,
               audience: _tokenOptions.Audience,
               claims: claims.AsEnumerable(),
               notBefore: _tokenOptions.NotBefore,
               expires: _tokenOptions.Expiration,
               signingCredentials: _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    id = _teacher.Id,
                    name = _teacher.Name.ToString(),
                    email = _teacher.Email,
                    username = _teacher.Email
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaims(AuthenticateTeacherCommand command)
        {
            var teacher = _repository.Get(command.Email);

            if (teacher == null)
                return Task.FromResult<ClaimsIdentity>(null);
            _teacher = teacher;

            if(!teacher.Authenticate(command.Email, command.Password))
                return Task.FromResult<ClaimsIdentity>(null);

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(teacher.Email, "Token"),
                new[] {
                    new Claim("SoccerManager", "Teacher")
                }));


        }
    }
}
