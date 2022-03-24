using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Autores
    {
        public Autores()
        {
            //Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Creacion { get; set; }
        public bool Activo { get; set; }
        public DateTime? Desactivacion { get; set; }
        public string DesactivadoPor { get; set; }
        public string CreadoPor { get; set; }
        public int? PaisId { get; set; }

        //public virtual ICollection<Libros> Libros { get; set; }
    }
}
