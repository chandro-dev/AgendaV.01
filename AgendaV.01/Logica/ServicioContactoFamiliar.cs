using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public bool Exist(ContactoFamiliar contacto)
        {
            bool match = false;
            if (contactoFamiliars.FindIndex(x => x.Id == contacto.Id) > -1) {
                match = true;
            }
            return match;
        }

        public List<ContactoFamiliar> GetAll()
        {
            if (contactoFamiliars.Count == 0) return null;

            return contactoFamiliars;
        }

        public List<ContactoFamiliar> GetByName(string name)
        {

            List<ContactoFamiliar> list_byName = new List<ContactoFamiliar>();
            bool find = false;

            foreach (var i in contactoFamiliars)
            {

                for (int w = 0; w <= name.Length; w++)
                {

                    try
                    {
                        if (name.ToLower()[w] == i.Nombre.ToLower()[w] && name.Length <= i.Nombre.Length)
                        {
                            find = true;

                        }
                        else
                        {
                            find = false;
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
                if (find)
                {

                    list_byName.Add(i);
                    find = false;

                }
            }

            if (list_byName.Count <= 0)
            {
                return null;
            }
            return list_byName;

        }

        public List<ContactoFamiliar> GetByPhone(string phone)
        {
            List<ContactoFamiliar> list_byPhone = new List<ContactoFamiliar>();
            bool find = false;


            foreach (var i in contactoFamiliars)
            {

                for (int w = 0; w <= phone.Length; w++)
                {

                    try
                    {
                        if (phone[w] == i.Telefono[w] && phone.Length <= i.Nombre.Length)
                        {
                            find = true;

                        }
                        else
                        {
                            find = false;
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
                if (find)
                {

                    list_byPhone.Add(i);
                    find = false;

                }
            }

            if (list_byPhone.Count <= 0)
            {
                return null;
            }
            return list_byPhone;

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
