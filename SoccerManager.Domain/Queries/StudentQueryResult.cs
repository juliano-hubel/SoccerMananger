using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Enums;

namespace SoccerManager.Domain.Queries
{
    public class StudentQueryResult
    {
        public Guid Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentRG { get; set; }
        public string StudentCPF { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Notes { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherRG { get; set; }
        public string FatherCPF { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherRG { get; set; }
        public string MotherCPF { get; set; }
        public decimal PaymentFee { get; set; }
        public int PaymentExpirationDay { get; set; }
        public int Age { get; set; }
        public ICollection<ClassroomQueryResult> Classrooms { get; set; }
    }
}
