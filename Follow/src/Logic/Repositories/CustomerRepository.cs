﻿using Logic.Entities;
using Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IReadOnlyList<Customer> GetList()
        {
            return _unitOfWork
                .Query<Customer>()
                .ToList();
        }

        public Customer GetByEmail(Email email)
        {
            return _unitOfWork
                .Query<Customer>()
                .SingleOrDefault(x => x.Email == email);
        }
    }
}
