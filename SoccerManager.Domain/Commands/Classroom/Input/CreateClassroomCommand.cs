using Flunt.Notifications;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Classroom.Input
{
    public class CreateClassroomCommand : Notifiable, ICommand
    {        

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public void Validate()
        {            
        }
    }
}
