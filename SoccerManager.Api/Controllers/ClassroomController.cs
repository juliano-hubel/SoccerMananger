using Microsoft.AspNetCore.Mvc;
using SoccerManager.Domain.Commands.Classroom.Input;
using SoccerManager.Domain.Commands.Classroom.Output;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Queries;
using SoccerManager.Domain.Repositories;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerManager.Api.Controllers
{
    public class ClassroomController
    {
        private IClassroomRepository _repository;
        private ClassroomHandler _handler;

        public ClassroomController(IClassroomRepository repository, ClassroomHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("classrooms")]
        public IEnumerable<ClassroomQueryResult> Get()
        {
            return  _repository.Get();
        }

        [HttpPost]
        [Route("classrooms")]
        public ICommandResult Post([FromBody] CreateClassroomCommand command)
        {
          return _handler.Handle(command);
        }
    }
}
