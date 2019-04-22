using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Teacher.Input
{
    public class AuthenticateTeacherCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
