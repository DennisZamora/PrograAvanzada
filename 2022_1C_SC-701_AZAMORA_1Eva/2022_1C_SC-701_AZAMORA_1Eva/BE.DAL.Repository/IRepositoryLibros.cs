using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryLibros : IRepositoryAutores<data.Libros>
    {
        Task<IEnumerable<data.Libros>> GetAllAsync();
        Task<data.Libros> GetOneByIdAsync(int id);
    }
}
