using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryCustomerCustomerDemo : IRepository<data.CustomerCustomerDemo>
    {
        Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync();
        Task<data.CustomerCustomerDemo> GetOneByIdAsync(string CustomerID, string CustomerTypeId);
    }
}
