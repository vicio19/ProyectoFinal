using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Jugador
    {
        public int ID { get; set; }

        public int PaisID { get; set; }
        public Pais Pais { get; set; }
        // DATOS PERSONALES
        public string Nombres { get; set; }
        public string Apellido_p { get; set; }
        public string Apellido_M { get; set; }
        public string Lugar_Nac { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public string Club { get; set; }
        public string Foto { get; set; }
        // Cualidades Fisicas

        public string Condicion { get; set; }
        public string Fuerza { get; set; }
        public string Velocidad { get; set; }
        public string Reacción { get; set; }

        // TECNICA 
        public string Control_de_Balon { get; set; }
        public string Anotacion { get; set; }
        public string Barrida { get; set; }
        public string Centros { get; set; }
        public string Defensa { get; set; }
        public string Marcaje { get; set; }
        // Carcater
        public string Carcateristica1 { get; set; }
        public string Carcateristica2 { get; set; }

        


    }
}
