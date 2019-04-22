using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Queries;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoccerManager.Infra.Context.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private SoccerManagerDataContext _context;

        public TeacherRepository(SoccerManagerDataContext context)
        {
            _context =context;                
        }

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public Teacher Get(string email)
        {
            return _context.Teachers.FirstOrDefault(t => t.Email == email);
            
        }

        public IEnumerable<TeacherQueryResult> Get()
        {
            return _context.Teachers.Select(t =>
                new TeacherQueryResult
                {
                    Id = t.Id,
                    FirstName = t.Name.FirstName,
                    LastName = t.Name.LastName,
                    Email = t.Email
                });

        }
    }
}
