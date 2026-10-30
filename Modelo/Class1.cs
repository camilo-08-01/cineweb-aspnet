using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Pelicula
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Director { get; set; }
        public string Idioma { get; set; }
        public int Duracion { get; set; }
        public int Valoracion { get; set; }
        public bool EsTodoPublico { get; set; }
        public bool EnCartelera { get; set; }
        public bool TieneSubtitulos { get; set; }
        public DateTime FechaEstreno { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public static class PeliculaController
    {
        public static string Create(Pelicula peli)
        {   
            // Verificamos si ya existe la película en nuestra base de datos
            bool existe = PeliculaCollection.ListadoPeliculas.Any(p => p.Nombre == peli.Nombre); // Esto devuelve el listado de películas y Any recorre los elementos 
                                                                                                 // de la lista para ver si se cumple la condición 
            if (existe)
            {
                return $"Error, la película {peli.Nombre} ya éxiste."; // el $ antes de las comillas dice que el string puede tener variables (todo lo que este entre {})
            }

            PeliculaEntity newpeli = new PeliculaEntity(); // Si no existe, crear el PeliculaEntity y asignar valores

            newpeli.Nombre = peli.Nombre;
            newpeli.Director = peli.Director;
            newpeli.Idioma = peli.Idioma;
            newpeli.Duracion = peli.Duracion;
            newpeli.Valoracion = peli.Valoracion;
            newpeli.EsTodoPublico = peli.EsTodoPublico;
            newpeli.EnCartelera = peli.EnCartelera;
            newpeli.TieneSubtitulos = peli.TieneSubtitulos;
            newpeli.FechaEstreno = peli.FechaEstreno;

            PeliculaCollection.ListadoPeliculas.Add(newpeli); // Añadimos la película creada a la base de datos

            return $"La película {peli.Nombre} fue agregada con éxito.";
        }

        public static Pelicula Read(string id)
        {
            // Buscar la peli en la lista por su Id
            PeliculaEntity existe = PeliculaCollection.ListadoPeliculas.FirstOrDefault(p => p.Id == id); // Busca el primer elemento que cumpla y lo devuelve completo
                                                                                                         // Si no encuentra devuelve null
            if (existe == null) { return null; } // si no existe retorna nulo


            Pelicula pel = new Pelicula();

            pel.Id = existe.Id;
            pel.Nombre = existe.Nombre;
            pel.Director = existe.Director;
            pel.Idioma = existe.Idioma;
            pel.Duracion = existe.Duracion;
            pel.Valoracion = existe.Valoracion;
            pel.EsTodoPublico = existe.EsTodoPublico;
            pel.EnCartelera = existe.EnCartelera;
            pel.TieneSubtitulos = existe.TieneSubtitulos;
            pel.FechaEstreno = existe.FechaEstreno;
            pel.CreatedAt = existe.RetornarCreatedAt();

            return pel;

        }

        public static string Update(string id, int valoracion, bool enCartelera)
        {
            PeliculaEntity existe = PeliculaCollection.ListadoPeliculas.FirstOrDefault(p => p.Id == id);

            if( existe == null )
            {
                return $"Error, la película {id} no existe";
            }

            existe.Valoracion = valoracion;
            existe.EnCartelera = enCartelera;

            return $"La información de la película {id} fue actualizada correctamente.";

        }

        public static string Delete(string id)
        {
            PeliculaEntity existe = PeliculaCollection.ListadoPeliculas.FirstOrDefault(p => p.Id == id);

            if (existe == null)
            {
                return $"Error, la película {id} no existe";
            }

            PeliculaCollection.ListadoPeliculas.Remove(existe);

            return $"La película {id} fue eliminada exitosamente.";
        }

        public static List<Pelicula> ReadAll()
        {
            List<Pelicula> peli = new List<Pelicula>(); // Crea lista vacía que se retornará

            foreach(PeliculaEntity entity in PeliculaCollection.ListadoPeliculas) // Recorre todas las PeliculaEntity de la colección
            {
                Pelicula p = new Pelicula(); // Crea un objeto del tipo Película y copia los valores
                p.Id = entity.Id;
                p.Nombre = entity.Nombre;
                p.Director = entity.Director;
                p.Idioma = entity.Idioma;
                p.Duracion = entity.Duracion;
                p.Valoracion = entity.Valoracion;
                p.EsTodoPublico = entity.EsTodoPublico;
                p.EnCartelera = entity.EnCartelera;
                p.TieneSubtitulos = entity.TieneSubtitulos;
                p.FechaEstreno = entity.FechaEstreno;
                p.CreatedAt = entity.RetornarCreatedAt();

                peli.Add(p); // Se agrega a la lista
            }

            return peli ; //retorna la lista completa
        }

        public static List<Pelicula> Search(string filtro)
        {
            List<PeliculaEntity> filtradas = PeliculaCollection.ListadoPeliculas.Where(p => p.Nombre.Contains(filtro) // where recorre y guarda todos los que cumplen
                                                                                   || p.Director.Contains(filtro)     // la condición. || = OR lógico
                                                                                   || p.Idioma.Contains(filtro))      // .where no devuelve una List<T>, con .ToList la convertimos en una.
                .ToList();

            List<Pelicula> listado = new List<Pelicula>();

            foreach(PeliculaEntity entity in filtradas)
            {
                Pelicula p = new Pelicula(); // Crea un objeto del tipo Película y copia los valores
                p.Id = entity.Id;
                p.Nombre = entity.Nombre;
                p.Director = entity.Director;
                p.Idioma = entity.Idioma;
                p.Duracion = entity.Duracion;
                p.Valoracion = entity.Valoracion;
                p.EsTodoPublico = entity.EsTodoPublico;
                p.EnCartelera = entity.EnCartelera;
                p.TieneSubtitulos = entity.TieneSubtitulos;
                p.FechaEstreno = entity.FechaEstreno;
                p.CreatedAt = entity.RetornarCreatedAt();

                listado.Add(p); // Se agrega a la lista
            }

            return listado;
        }

    }
}
