using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Data
{
    public class DbInitializer
    {

        public static void Initialize(FinalContext context)
        {
            context.Database.EnsureCreated();

            // PARA PRE CARGADO DE PAISES
            if (context.Paises.Any())
            {
                return;   // DB has been seeded
            }

            var  paises = new Pais[]
            {
            new Pais{ID=1,Nombre="Argentina",Imagen="C:\\Banderas\\ar.png"},
            new Pais{ID=2,Nombre="Bolivia",Imagen="C:\\Banderas\\bo.png"},
            new Pais{ID=3,Nombre="Brasil",Imagen="C:\\Banderas\\br.png"},
            new Pais{ID=4,Nombre="Chile",Imagen="C:\\Banderas\\cl.png"},
            new Pais{ID=5,Nombre="Colombia",Imagen="C:\\Banderas\\co.png"},
            new Pais{ID=6,Nombre="Ecuador",Imagen="C:\\Banderas\\ec.png"},


            };
            foreach (Pais s in paises)
            {
                context.Paises.Add(s);
            }
            context.SaveChanges();

            // PARA PRECARGADO DE JUGADORES
            var Jugadores = new Jugador[]
            {
            new Jugador{PaisID=1,Nombres="Pedro Luis", Apellido_p="Del Catillo", Apellido_M="Vargas",Lugar_Nac="Buenos Aires", Fecha_Nac=Convert.ToDateTime("1983/06/28"), Altura=float.Parse("1,5"), Peso=float.Parse("85"),Club="Atletico Dagama", Foto="C:\\Jugadores\\1.jpg",Condicion="85", Fuerza="80", Velocidad="90", Reacción="77",Control_de_Balon="90",Anotacion="90", Barrida="60", Centros="80", Defensa="20", Marcaje="80", Carcateristica1="Tranquilo , sociable, escucha", Carcateristica2="No fuma no bebe"},
            new Jugador{PaisID=1,Nombres="Sergio", Apellido_p="Aguero", Apellido_M="Surdo",Lugar_Nac="Cordova", Fecha_Nac=Convert.ToDateTime("1983/06/28"), Altura=float.Parse("1,5"), Peso=float.Parse("85"),Club="Atletico la Argentina", Foto="C:\\Jugadores\\2.jpg",Condicion="85", Fuerza="80", Velocidad="90", Reacción="77",Control_de_Balon="90",Anotacion="90", Barrida="60", Centros="80", Defensa="20", Marcaje="80", Carcateristica1="Tranquilo , sociable, escucha", Carcateristica2="No fuma no bebe"},
            new Jugador{PaisID=1,Nombres="Lionel", Apellido_p="Mesi", Apellido_M="Mesias",Lugar_Nac="Buenos Aires", Fecha_Nac=Convert.ToDateTime("1983/06/28"), Altura=float.Parse("1,5"), Peso=float.Parse("85"),Club="Barcelona", Foto="C:\\Jugadores\\3.jpg",Condicion="85", Fuerza="80", Velocidad="90", Reacción="77",Control_de_Balon="90",Anotacion="90", Barrida="60", Centros="80", Defensa="20", Marcaje="80", Carcateristica1="Tranquilo , sociable, escucha", Carcateristica2="No fuma no bebe"},
            new Jugador{PaisID=1,Nombres="Kaka", Apellido_p="Con K", Apellido_M="de K",Lugar_Nac="Malvinas", Fecha_Nac=Convert.ToDateTime("1983/06/28"), Altura=float.Parse("1,5"), Peso=float.Parse("85"),Club="Zona Sud", Foto="C:\\Jugadores\\4.jpg",Condicion="85", Fuerza="80", Velocidad="90", Reacción="77",Control_de_Balon="90",Anotacion="90", Barrida="60", Centros="80", Defensa="20", Marcaje="80", Carcateristica1="Tranquilo , sociable, escucha", Carcateristica2="No fuma no bebe"},
            new Jugador{PaisID=1,Nombres="Di Maria", Apellido_p="Megarejo", Apellido_M="Vargas",Lugar_Nac="Cochabamba", Fecha_Nac=Convert.ToDateTime("1983/06/28"), Altura=float.Parse("1,5"), Peso=float.Parse("85"),Club="Barrio Lindo", Foto="C:\\Jugadores\\5.jpg",Condicion="85", Fuerza="80", Velocidad="90", Reacción="77",Control_de_Balon="90",Anotacion="90", Barrida="60", Centros="80", Defensa="20", Marcaje="80", Carcateristica1="Tranquilo , sociable, escucha", Carcateristica2="No fuma no bebe"},


            };
            foreach (Jugador c in Jugadores)
            {
                context.Jugadores.Add(c);
            }
            context.SaveChanges();

            
        }
    }
}
