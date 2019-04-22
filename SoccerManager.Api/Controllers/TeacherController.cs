using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoccerManager.Domain.Commands.Teacher.Input;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Queries;
using SoccerManager.Domain.Repositories;
using SoccerManager.Shared.Commands;
using SoccerManager.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerManager.Api.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherHandler _handler;
        private ITeacherRepository _repository;

        public TeacherController(TeacherHandler handler, ITeacherRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("teachers")]
        [Authorize(policy: "Administrator")]
        public IEnumerable<TeacherQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        [Route("teachers")]     
        [Authorize(policy:"Administrator")]
        public ICommandResult Post([FromBody]CreateTeacherCommand command)
        {
            return _handler.Handle(command);
        }


    }
}
