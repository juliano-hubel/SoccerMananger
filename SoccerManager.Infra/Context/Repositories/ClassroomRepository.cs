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
    public class ClassroomRepository : IClassroomRepository
    {
        private SoccerManagerDataContext _context;
        public ClassroomRepository(SoccerManagerDataContext context)
        {
            _context = context;
        }

        public Classroom GetById(Guid id)
        {
            return _context.Classrooms.FirstOrDefault(x => x.Id == id);
        }

        public void AddClassroom(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
        }

        public IEnumerable<ClassroomQueryResult> Get()
        {
            return _context.Classrooms.Select(c =>
                        new ClassroomQueryResult()
                        {
                            Id = c.Id,
                            DayOfWeek = c.DayOfWeek.ToString(),
                            Start = c.Start,
                            End = c.End
                        });
        }
    }
}
