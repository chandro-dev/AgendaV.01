using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;





namespace Datos
{
    public class Archivo
    {
        private StreamWriter sw = null;
        private StreamReader sr = null;
        string path = "Contactos.txt";
        public Archivo (){
            StreamWriter m= new StreamWriter(path,true);
            
            m.Close();
    }
        public string Guardar(ContactoFamiliar c , bool mode)
        {
            try
            {
                using (sw = new StreamWriter(path, mode))
                {
                   

                    sw.WriteLine($"{c.Id};{c.Nombre};{c.Telefono};{c.FechaNacimiento}");
                }
            }catch
            {
                Console.WriteLine("No se guardo correctamente el dato");
            }
            return "ok";
        }
        public bool SaveList(List<ContactoFamiliar> list)
        {
            try
            {
                using (sw = new StreamWriter(path, false))
                {
                    foreach (ContactoFamiliar c in list)
                    {
                        sw.WriteLine($"{c.Id};{c.Nombre};{c.Telefono};{c.FechaNacimiento}");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<ContactoFamiliar> GetData()
        {
            List<ContactoFamiliar> list = new List<ContactoFamiliar>();

            using (sr =new StreamReader(path,true))
            {
                try
                {
                   string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(new ContactoFamiliar() { Id = int.Parse(line.Split(';')[0]), Nombre = line.Split(';')[1], Telefono = line.Split(';')[2], FechaNacimiento = DateTime.Parse(line.Split(';')[3]) });
                    }
                }
                catch(Exception e) { 
                    Console.WriteLine(e.Message );
                    //Console.ReadKey();
                }
            }

                return list;
        }

                   
    }
}
