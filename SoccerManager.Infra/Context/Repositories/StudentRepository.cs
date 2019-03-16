using Microsoft.EntityFrameworkCore;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Queries;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManager.Infra.Context.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private SoccerManagerDataContext _context;

        public StudentRepository(SoccerManagerDataContext context)
        {
            _context = context;
        }

        public void AddAddress(Guid StudentId, Address address)
        {
            var student =  _context.Students.SingleOrDefault(s => s.Id == StudentId);

            if(student != null)
            {
                student.AddAddress(address);
                _context.SaveChanges();
            }
        }

        public void AddClassroom(StudentsClassrooms  studentsClassrooms)
        {                        
            _context.StudentsClassrooms.Add(studentsClassrooms);
            _context.SaveChanges();
        }

        public void AddHealth(Guid StudentId, Health health)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == StudentId);
            student.AddHealth(health);
            _context.SaveChanges();
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        
        public IEnumerable<StudentQueryResult> Get()
        {
            return _context.Students.Select(s =>
            new StudentQueryResult {
                Id = s.Id,
                CPF = s.Name.CPF,
                Email = s.Email,
                FirstName = s.Name.FirstName,
                LastName = s.Name.LastName
            });
        }

        public Student GetById(Guid id)
        {
            Student student = _context.Students
                .FirstOrDefault(s => s.Id == id);
            return student;
        }

        public List<Student> GetStudentsByClassroom(Classroom classroom)
        {
            return new List<Student>();
        }

        public void RemoveClassroom(Guid StudentId, Guid ClassroomId)
        {
            var studenClassroom = _context.StudentsClassrooms.FirstOrDefault(s => s.StudentId == StudentId
                   && s.ClassroomId == ClassroomId);

            _context.StudentsClassrooms.Remove(studenClassroom);
            
            _context.SaveChanges();            
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public StudentQueryResult GetId(Guid Id)
        {
            Student student = _context.Students
                .FirstOrDefault(s => s.Id == Id);

            return new StudentQueryResult
            {
                Id = student.Id,
                CPF = student.Name.CPF,
                Email = student.Email,
                FirstName = student.Name.FirstName,
                LastName = student.Name.LastName              
            };
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        
    }
}
