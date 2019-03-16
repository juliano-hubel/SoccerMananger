using Flunt.Validations;
using SoccerManager.Domain.Enums;
using SoccerManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManager.Domain.Entities
{
    public class Student : Person
    {
        protected Student(){ }

        public Student(Name father, Name mother, Payment payment,
            Name name, string email, DateTime birthDate, EGender gender,
            string notes)                        
            :base(name, email,  birthDate,  gender, notes, null)
        {
            Father = father;
            Mother = mother;
            Payment = payment;            
        }

        public Name Father { get; private set; }
        public Name Mother { get; private set; }
        public Payment Payment { get; private set; }
        public Health Health { get; private set; }
        public ICollection<StudentsClassrooms> StudentsClassrooms { get; set;}


        public void UpdateStudent(Name father, Name mother, Payment payment,
            Name name, string email, DateTime birthDate, EGender gender,
            string notes)
        {
            Father = father;
            Mother = mother;
            Payment = payment;
            UpdatePerson(name, email, birthDate, gender, notes);
        }

        public void AddClassroom(Classroom classroom)
        {
            //var activeClass = 
            //    _studentsClassrooms.FirstOrDefault(
            //        room =>
            //            classroom.DayOfWeek == room.DayOfWeek
            //            && classroom.Start.TimeOfDay < room.End.TimeOfDay
            //            && room.Start.TimeOfDay < classroom.End.TimeOfDay);
            
            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsTrue(activeClass == null, "Student.Classrooms", "O Aluno já está matriculado em uma aula nesse horário"));


            //if (Valid)
            //    _studentsClassrooms.Add(classroom);            
        }

        public void RemoveClassroom(Classroom classroom)
        {
            //_studentsClassrooms.Remove(classroom);
        }

        public void AddHealth(Health health)
        {
            Health = health;
        }
        


    }
}
