using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;

namespace Logica
{
    public class ServicioContactoFamiliar : Icontacto<ContactoFamiliar>
    {
        Archivo arch = new Archivo();
        List<ContactoFamiliar> contactoFamiliars;

        // Contruccion de la lista de Telefonos (Familiares);
        public ServicioContactoFamiliar( )
        {

            contactoFamiliars = new List<ContactoFamiliar>();
            contactoFamiliars = arch.GetData();
        }

        public string Add(ContactoFamiliar contacto)
        {
            //validar
            try
            {
                arch.Guardar(contacto, true);

                contactoFamiliars = arch.GetData();

                return $"contacto {contacto.Nombre} guardado...";

            }
            catch (Exception)
            {
                return $"Error al guardar el contacto ...";
            }



        }

        public bool Delete(ContactoFamiliar contacto)
        {
            if (Exist(contacto))
            {
                int index = contactoFamiliars.FindIndex(x => x.Id == contacto.Id);
                contactoFamiliars.RemoveAt(index);
                arch.SaveList(contactoFamiliars);
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool Exist(ContactoFamiliar contacto)
        {
            var result =  contactoFamiliars.Where(i => i.Id == contacto.Id).ToList();

            if (result == null || result.Count <=0)
            {                                                                                                                                                                                                             
                return false;
            }
            else
            {
                return true;
            }
            }

        public List<ContactoFamiliar> GetAll()
        {
            if (contactoFamiliars.Count == 0) return null;

            return contactoFamiliars;
        }

        public List<ContactoFamiliar> GetByName(string name)
        {
            var result = from i in contactoFamiliars
                         where i.Nombre.Contains(name)
                         select i;
            if (result== null) { 
            return null;
            }
            {
                return  result.ToList();
            }
        }

        public List<ContactoFamiliar> GetByPhone(string phone)
        {
            var result = from i in contactoFamiliars
                         where i.Telefono.Contains(phone)
                        select i;
            if (result == null)
            {
                return null;
            }
            else
            {
                return result.ToList();
                
            }
        }
    
        public bool Update(ContactoFamiliar contacto)
        {
            if (Exist(contacto))
            {
                int index=contactoFamiliars.FindIndex(x => x.Id == contacto.Id);
                contactoFamiliars[index].Telefono = contacto.Telefono;
                contactoFamiliars[index].Nombre = contacto.Nombre;
                contactoFamiliars[index].FechaNacimiento = contacto.FechaNacimiento;
                arch.SaveList(contactoFamiliars);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
