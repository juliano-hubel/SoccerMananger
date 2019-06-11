using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Repositories
{
    public interface ITeacherRepository
    {

        void CreateTeacher(Teacher teacher);
        IEnumerable<TeacherQueryResult> Get();
        Teacher Get(string email);
        TeacherQueryResult Get(Guid id);



    }
}
