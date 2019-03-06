using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Repositories
{
    public interface IClassroomRepository
    {
        IEnumerable<ClassroomQueryResult> Get();

        Classroom GetById(Guid id);

        void AddClassroom(Classroom classroom);
    }
}
