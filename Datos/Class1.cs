using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PeliculaEntity // Modelo que se guarda en la "base de datos en memoria" (lista estática)
    {
        public string Id = Guid.NewGuid().ToString();
        public string Nombre {  get; set; }
        public string Director { get; set; }
        public string Idioma { get; set; }
        public int Duracion { get; set; }
        public int Valoracion { get; set; }
        public bool EsTodoPublico { get; set; }
        public bool EnCartelera { get; set; }
        public bool TieneSubtitulos { get; set; }
        public DateTime FechaEstreno { get; set; }

        private DateTime _createdAt = DateTime.Now;

        public DateTime RetornarCreatedAt()
        {
            return _createdAt;
        }
    }

    public static class PeliculaCollection // Listado de películas guardado en la base de datos (estático)
    {
        private static List<PeliculaEntity> _listadoPeliculas = new List<PeliculaEntity>();

        public static List<PeliculaEntity> ListadoPeliculas
        {
            get {  return _listadoPeliculas; }
            set {  _listadoPeliculas = value;}
        }
    }
}
