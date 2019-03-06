using SoccerManager.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.ValueObjects
{
    public class Payment : ValueObject
    {
        public Payment(decimal fee, int expirationDay)
        {
            Fee = fee;
            ExpirationDay = expirationDay;
        }

        public decimal Fee { get; private set; }
        public int ExpirationDay { get; private set; }
    }
}
