using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ContactoFamiliar:Persona
    {
        public ContactoFamiliar() { }
        public DateTime FechaNacimiento { get; set; }
        public ContactoFamiliar(int id, string nombre, string telefono, DateTime fechaNacimiento) : base(id, nombre, telefono)
        {
            FechaNacimiento = fechaNacimiento;
        }
    }
}
