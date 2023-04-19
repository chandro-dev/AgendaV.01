using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }    
        public string   Telefono { get; set; }
        public Persona()
        {


        }

        public Persona(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
