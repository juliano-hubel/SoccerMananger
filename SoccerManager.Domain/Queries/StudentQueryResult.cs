using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Domain.Queries
{
    public class StudentQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}
