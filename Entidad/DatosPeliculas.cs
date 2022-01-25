using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas_API.Entidad
{
    public class DatosPeliculas
    {
        public int ID { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public float Puntuacion { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        public float Año_Publicacion { get; set; }

    }
}
