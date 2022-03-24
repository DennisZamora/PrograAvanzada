using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using BE.DAL.EF;
using BE.DAL.Repository;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace BE.DAL
{
    public class Libros : ICRUD<data.Libros>
    {
        private RepositoryLibros repositorio;

        public Libros (NDbContext dbContext)
        {
            repositorio = new RepositoryLibros(dbContext);
        }

        public void Delete(data.Libros t)
        {
            repositorio.Delete(t);
            repositorio.Commit();
        }

        public IEnumerable<data.Libros> GetAll()
        {
            return repositorio.GetAll();
        }

        public Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            return repositorio.GetAllAsync();
        }

        public data.Libros GetOneById(int id)
        {
            return repositorio.GetOnebyID(id);
        }

        public Task<data.Libros> GetOneByIdAsync(int id)
        {
            return repositorio.GetOneByIdAsync(id);
        }

        public void Insert(data.Libros t)
        {
            repositorio.Insert(t);
            repositorio.Commit();
        }

        public void Update(data.Libros t)
        {
            repositorio.Update(t);
            repositorio.Commit();
        }
    }
}
