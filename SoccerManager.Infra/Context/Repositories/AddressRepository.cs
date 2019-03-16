using Microsoft.EntityFrameworkCore;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoccerManager.Infra.Context.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private SoccerManagerDataContext _context;

        public AddressRepository(SoccerManagerDataContext context)
        {
            _context = context;
        }

        public Address GetById(Guid Id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == Id);
        }

        public void Update( Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
