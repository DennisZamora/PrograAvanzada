using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BE.DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data = BE.DAL.DO.Objects;
using models = BE.API.DataModels;


namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public LibrosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Libros>>> GetLibros()
        {
            try
            {
                var respuesta = new BE.BS.Libros(_context).GetAll();
                List<models.Libros> mapaAux = _mapper.Map<IEnumerable<data.Libros>, IEnumerable<models.Libros>>(respuesta).ToList();
                return mapaAux;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Libros>> GetLibros(int id)
        {
            var libros = new BE.BS.Libros(_context).GetOneById(id);

            if (libros == null)
            {
                return NotFound();
            }

            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(libros);
            return mapaAux;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, models.Libros libros)
        {
            if (id != libros.Id)
            {
                return BadRequest();
            }

            try
            {
                data.Libros mapaAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new BE.BS.Libros(_context).Update(mapaAux);
            }
            catch (Exception ex)
            {
                if (!LibrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Libros>> PostLibros(models.Libros libros)
        {
            try
            {
                data.Libros mapaAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new BE.BS.Libros(_context).Insert(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            };

            return CreatedAtAction("GetLibros", new { id = libros.Id }, libros);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Libros>> DeleteLibros(int id)
        {
            var libros = new BE.BS.Libros(_context).GetOneById(id);
            if (libros == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Libros(_context).Delete(libros);
            }
            catch (Exception)
            {
                BadRequest();
            }

            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(libros);
            return mapaAux;
        }

        private bool LibrosExists(int id)
        {
            return (new BE.BS.Libros(_context).GetOneById(id) != null);
        }

    }
}
