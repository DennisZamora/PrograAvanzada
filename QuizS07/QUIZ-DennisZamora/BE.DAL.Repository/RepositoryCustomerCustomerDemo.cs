using BE.DAL.DO.Objects;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public class RepositoryCustomerCustomerDemo : Repository<data.CustomerCustomerDemo>, IRepositoryCustomerCustomerDemo
    {
        public RepositoryCustomerCustomerDemo(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<CustomerCustomerDemo>> GetAllAsync()
        {
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(n => n.CustomerType).ToArrayAsync();
        }

        public async Task<CustomerCustomerDemo> GetOneByIdAsync(string CustomerID,string CustomerTypeId)
        {
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(n => n.CustomerType).SingleOrDefaultAsync(n => n.CustomerId == CustomerID && n.CustomerTypeId == CustomerTypeId);
        }
        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
