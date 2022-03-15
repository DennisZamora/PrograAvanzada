﻿using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using BE.DAL.EF;
using BE.DAL.Repository;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace BE.DAL
{
    public class CustomerCustomerDemo : ICRUD<data.CustomerCustomerDemo>
    {
        private RepositoryCustomerCustomerDemo repo;
        public CustomerCustomerDemo(NDbContext dbContext)
        {
            repo = new RepositoryCustomerCustomerDemo(dbContext);
        }

        public void Delete(data.CustomerCustomerDemo t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.CustomerCustomerDemo> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.CustomerCustomerDemo GetOneById(string id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.CustomerCustomerDemo> GetOneByIdAsync(string id)
        {
            return null;
        }
        public Task<data.CustomerCustomerDemo> GetOneByIdAsync(string CustomerId,string CustomerTypeId)
        {
            return repo.GetOneByIdAsync(CustomerId, CustomerTypeId);
        }

        public void Insert(data.CustomerCustomerDemo t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.CustomerCustomerDemo t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
