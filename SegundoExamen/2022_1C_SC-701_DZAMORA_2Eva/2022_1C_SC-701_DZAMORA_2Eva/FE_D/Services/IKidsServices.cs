using FE_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE_D.Services
{
    public interface IKidsServices
    {
        void Insert(Kids t);
        void Update(Kids t);
        void Delete(Kids t);
        IEnumerable<Kids> GetAll();
        Kids GetOneById(int id);
        Task<IEnumerable<Kids>> GetAllAsync();
        Task<Kids> GetOneByIdAsync(int id);
    }
}
