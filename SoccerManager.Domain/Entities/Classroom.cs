using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Classroom : Entity
    {
        private IList<StudentsClassrooms> _studentsClassrooms;

        public Classroom(){ }
        
        public Classroom( DateTime start, DateTime end, DayOfWeek dayOfWeek)
        {
            Start = start;
            End = end;
            DayOfWeek = dayOfWeek;
            _studentsClassrooms = new List<StudentsClassrooms>();
        }

        public DateTime Start { get; private  set; }
        public DateTime End { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }

        //TODO : Encontrar uma forma de recuperar os students
        public ICollection<StudentsClassrooms> StudentsClassrooms { get; set; }



    }
}
