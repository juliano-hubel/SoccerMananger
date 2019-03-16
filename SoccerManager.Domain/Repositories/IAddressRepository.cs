using SoccerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Repositories
{
    public interface IAddressRepository
    {
        Address GetById(Guid Id);
        void Update(Address address);
    }
}
