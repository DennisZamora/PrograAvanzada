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
    public class RepositoryLibros : RepositoryAutores<data.Libros>, IRepositoryLibros
    {
        public RepositoryLibros(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Libros>> GetAllAsync()
        {
            return await _db.Libros.Include(x => x.Id).ToListAsync();
        }

        public async Task<Libros> GetOneByIdAsync(int id)
        {
            return await _db.Libros.Include(x => x.Autor).SingleOrDefaultAsync(x => x.AutorId == id);
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
