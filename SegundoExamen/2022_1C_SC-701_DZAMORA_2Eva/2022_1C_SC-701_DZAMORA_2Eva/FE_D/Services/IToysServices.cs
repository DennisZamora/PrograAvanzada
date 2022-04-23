using FE_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE_D.Services
{
    public interface IToysServices
    {
        void Insert(Toys t);
        void Update(Toys t);
        void Delete(Toys t);
        IEnumerable<Toys> GetAll();
        Toys GetOneById(int id);
        Task<IEnumerable<Toys>> GetAllAsync();
        Task<Toys> GetOneByIdAsync(int id);
    }
}
