using Flunt.Validations;
using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{

    public class ClassroomHistory : Entity
    {
        protected ClassroomHistory(){}

        private IList<Student> _markedUpStudents;
        private IList<Student> _temporaryStudents;
        private IList<Student> _presentStudents;


        public ClassroomHistory(Classroom classroom, Teacher teacher)
        {
            Classroom = classroom;
            StartDate = DateTime.Now;            
            Teacher = teacher;
            _markedUpStudents = new List<Student>();
            _temporaryStudents = new List<Student>();
            _presentStudents = new List<Student>();

            AddNotifications(Classroom, Teacher);
        }  

        public Classroom Classroom { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Notes { get; private set; }
        public Teacher Teacher { get; private set; }
        public ICollection<Student> MarkedUpStudents => _markedUpStudents.ToArray();
        public ICollection<Student> TemporaryStudents => _temporaryStudents.ToArray();
        public ICollection<Student> PresentStudents => _temporaryStudents.ToArray();

        public void AddNotes(string notes, List<Student> markedUpStudents)
        {
            Notes = notes;
            if(markedUpStudents != null)
                markedUpStudents.ForEach(s => _markedUpStudents.Add(s));
        }

        public void AddTemporaryStudent(Student temporaryStudent)
        {
            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsFalse(Classroom.StudentsClassrooms.Select(s => s.Student).Contains(temporaryStudent), "TemporaryStudent",
            //    "Você não pode adicionar alunos temporarios que já estão matriculados na aula"));

            if(Valid)
                _temporaryStudents.Add(temporaryStudent);
        }

        public void AddPresentStudent(Student presentStudent)
        {
            _presentStudents.Add(presentStudent);
        }


        public void EndClassroom()
        {
            EndDate = DateTime.Now;
        }
    }
}
