using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class StudentsClassrooms : Entity
    {
        private StudentsClassrooms() { }        

        public StudentsClassrooms(Student student, Classroom classroom)
        {
            StudentId = student.Id;
            Student = student;
            ClassroomId = classroom.Id;
            Classroom = classroom;
        }

        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }
        public Guid ClassroomId { get; private set; }
        public Classroom Classroom { get; private set; }



    }
}
