using Microsoft.EntityFrameworkCore;
using Peliculas_API.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas_API.AplicacionDBContext
{
    public class ConexionBD : DbContext
    {
        public ConexionBD(DbContextOptions options) : base(options) { }

        public DbSet<DatosPeliculas> BaseDatosPeliculas {get; set;}
    }
}
