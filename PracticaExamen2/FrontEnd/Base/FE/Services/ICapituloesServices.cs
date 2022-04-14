using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface ICapituloesServices
    {
        void Insert(Capitulo t);
        void Update(Capitulo t);
        void Delete(Capitulo t);
        IEnumerable<Capitulo> GetAll();
        Capitulo GetOneById(int id);
        Task<IEnumerable<Capitulo>> GetAllAsync();
        Task<Capitulo> GetOneByIdAsync(int id);
    }
}
