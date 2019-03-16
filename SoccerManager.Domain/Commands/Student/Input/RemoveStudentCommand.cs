using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Student.Input
{
    public class RemoveStudentCommand : ICommand
    {
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public void Validate()
        {            
        }
    }
}
