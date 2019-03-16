using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManager.Domain.Commands.Student.Input;
using SoccerManager.Domain.Commands.Student.Output;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Queries;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.Repositories;
using SoccerManager.Shared.Commands;

namespace SoccerManager.Api.Controllers
{
    public class StudentController : Controller
    {
        private StudentHandler _handler;
        private IStudentRepository _repository;

        public StudentController(StudentHandler handler, IStudentRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("students")]
        public IEnumerable<StudentQueryResult> Get()
        {
            return _repository.Get();
        }
        [HttpGet]
        [Route("students/{id}")]
        public StudentQueryResult GetId(Guid id)
        {
            return _repository.GetId(id);
        }

        [HttpPost]
        [Route("students")]
        public ICommandResult Post([FromBody] CreateStudentCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPost]
        [Route("students/address")]
        public ICommandResult AddAddress([FromBody] AddAddressCommand command)
        {
            return _handler.Handle(command);        
        }

        [HttpPost]
        [Route("students/classroom")]
        public ICommandResult AddClassroom([FromBody] AddClassroomCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPost]
        [Route("students/health")]
        public ICommandResult AddHealth([FromBody] AddHealthCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("students")]
        public ICommandResult UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            return _handler.Handle(command);
        }
        [HttpPut]
        [Route("students/address")]
        public ICommandResult UpdateAdress([FromBody] UpdateAddressCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("students/classroom")]
        public ICommandResult RemoveClassroom([FromBody] RemoveClassRoomCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("students")]
        public ICommandResult Remove([FromBody] RemoveStudentCommand command)
        {
            return _handler.Handle(command);
        }

    }
}