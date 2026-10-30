# CineWeb: catálogo de películas

Aplicación web para administrar un catálogo de películas, desarrollada en **C# y ASP.NET Web Forms (.NET Framework 4.8)** con separación en capas. Proyecto del ramo Programación I del programa Analista Programador (IPLACEX).

## Estructura

| Proyecto | Responsabilidad |
| --- | --- |
| `CineWeb` | Presentación: Master Page, página de inicio y formulario para agregar películas. |
| `Modelo` | Lógica de negocio: clase `Pelicula` y `PeliculaController` con Create, Read, ReadAll, Update, Delete y Search. |
| `Datos` | `PeliculaEntity` y la colección estática que hace de almacenamiento. |

Cada película tiene nombre, director, idioma, duración, valoración, fecha de estreno y banderas (todo público, en cartelera, con subtítulos).

## Estado y limitaciones

- Los datos viven en una **lista en memoria**, así que se pierden al reiniciar. No usa base de datos.
- La interfaz tiene inicio y alta de películas. El listado (`ListarPeliculas.aspx`) figura en el mapa del sitio, pero la página aún no está implementada, aunque la lógica de lectura y búsqueda ya existe en `PeliculaController`.

## Cómo ejecutarlo

1. Abre `CineWeb.slnx` en Visual Studio 2022 o superior.
2. Restaura los paquetes NuGet (automático al compilar).
3. Ejecuta con IIS Express (F5).
