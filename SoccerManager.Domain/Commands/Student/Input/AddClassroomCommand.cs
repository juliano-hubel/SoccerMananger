using Flunt.Notifications;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Student.Input
{
    public class AddClassroomCommand : Notifiable, ICommand
    {
        public Guid StudentId { get; set; }
        public Guid ClassroomId { get; set; }        

        public void Validate()
        {            
        }
    }
}
