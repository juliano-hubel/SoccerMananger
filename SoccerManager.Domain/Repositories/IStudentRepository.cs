using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Queries;
using System;
using System.Collections.Generic;

namespace SoccerManager.Domain.Repositories
{
    public interface IStudentRepository 
    {
        IEnumerable<StudentQueryResult> Get();

        StudentQueryResult GetId(Guid id);

        void CreateStudent(Student student);

        void UpdateStudent(Student student);

        List<Student> GetStudentsByClassroom(Classroom classroom);

        Student GetById(Guid id);

        void AddClassroom(StudentsClassrooms studentsClassrooms);

        void RemoveClassroom(Guid StudentId, Guid ClassroomId);

        void AddHealth(Guid StudentId, Health health);

        void AddAddress(Guid StudentId, Address address);
    }
}
