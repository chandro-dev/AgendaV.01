using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Presentacion
{
    public class ContactoFamiliarGUI
    {
        ServicioContactoFamiliar servicioContactoFamiliar = new ServicioContactoFamiliar();
        public void Capturar()
        {
            Console.Beep();
            var contacto = new ContactoFamiliar();
            int dia = 0, mes = 0, anio = 0;
            Console.Clear();
            try
            {
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)); Console.WriteLine("Agregar contacto Familiar");
                contacto.Id = new Random().Next(1, 30);
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 2); Console.Write("Nombre: "); contacto.Nombre = Console.ReadLine();
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 4); Console.Write("Telefono: "); contacto.Telefono = Console.ReadLine();
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 6); Console.WriteLine("Fecha De nacimiento: ");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 8); Console.Write("Dia: "); dia = int.Parse(Console.ReadLine());
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 10); Console.Write("MES: "); mes = int.Parse(Console.ReadLine());
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 12); Console.Write("AÑO: "); anio = int.Parse(Console.ReadLine());
                contacto.FechaNacimiento = new DateTime(anio, mes, dia);
                var msg = servicioContactoFamiliar.Add(contacto);
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 14); Console.WriteLine(msg);
            }
            catch
            {
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 14); Console.WriteLine("Se ingreso de forma errada un campo");
            }
            Console.ReadKey();
        }


        public void menu()
        {
            int op = 0;
            do

            {
                string[] opciones = new string[] { "Agregar Contacto.", "Editar Contacto.", "Mostrar contacto.", "Eliminar contacto.", "Salir." };
                Console.Clear();
                int i = 1;
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)); Console.Write("         Contactos Familiares ");
                foreach (var e in opciones)
                {
                    Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + i + i); Console.Write(i.ToString() + ".  " + e);
                    i++;
                }
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 15); Console.Write("Opcion :");

                try

                {
                    Console.SetCursorPosition((Console.LargestWindowWidth / 3) + 8, (Console.LargestWindowHeight / 3) + 15);
                    op = int.Parse(Console.ReadKey().KeyChar.ToString());
                }
                catch
                {
                    op = 0;
                }
                switch (op)
                {
                    case 1:
                        Capturar();
                        break;
                    case 2:
                        edit();
                        ;
                        break;
                    case 3:
                        lista();
                        break;
                    case 4:
                        delete();
                        break;
                }
                Console.Clear();
            } while (op != 5);

        }
        public void edit()
        {
            Console.Clear();
            ContactoFamiliar edit_contacto = new ContactoFamiliar();
            Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)); Console.Write(" Editar:");

            Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)); Console.Write("id:");

            try
            {

                edit_contacto.Id = int.Parse(Console.ReadLine());

            }
            catch
            {
                edit_contacto = null;
            }

            if (edit_contacto != null) {
                if (servicioContactoFamiliar.Exist(edit_contacto))
                {
                    int dia = 0, mes = 0, anio = 0;
                    try
                    {
                        Console.SetCursorPosition(30, 10); Console.Write("Nombre: "); edit_contacto.Nombre = Console.ReadLine();
                        Console.SetCursorPosition(30, 11); Console.Write("Telefono: "); edit_contacto.Telefono = Console.ReadLine();
                        Console.SetCursorPosition(30, 12); Console.WriteLine("Fecha De nacimiento ");
                        Console.SetCursorPosition(30, 13); Console.Write("Dia: "); dia = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(30, 14); Console.Write("MES: "); mes = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(30, 15); Console.Write("AÑO: "); anio = int.Parse(Console.ReadLine());
                        edit_contacto.FechaNacimiento = new DateTime(anio, mes, dia);
                    }
                    catch {
                        edit_contacto = null;
                    }
                    if (edit_contacto != null) {
                        servicioContactoFamiliar.Update(edit_contacto);
                        Console.SetCursorPosition(30, 16); Console.WriteLine($"Contacto {edit_contacto.Id} Editado exitosamente ");
                    }
                    else
                    {
                        Console.WriteLine("No se realizo la edicion correctamente.");
                    }
                }
                else
                {
                    Console.Write("No existe el contacto");
                }
            }
            else
            {
                Console.WriteLine("No existe este contacto");
            }
            Console.ReadKey();
        }
        public void delete()
        {
            Console.Clear();
            ContactoFamiliar delete_contacto = new ContactoFamiliar();

            Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)); Console.Write(" Eliminar Contacto");

            Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3) + 1); Console.Write("id:");

            try
            {

                delete_contacto.Id = int.Parse(Console.ReadLine());

            }
            catch
            {
                delete_contacto = null;
            }
            servicioContactoFamiliar.Delete(delete_contacto);
            Console.ReadKey();
        }
        public void lista()

        {
            ConsoleKeyInfo aux_2 = new ConsoleKeyInfo();
            string key = string.Empty;
            Console.Clear();
            if (servicioContactoFamiliar.GetAll() == null)
            {
                Console.SetCursorPosition(30, 6); Console.WriteLine("No hay contactos que mostrar");
            }
            else
            {
                view_lista_all(servicioContactoFamiliar.GetAll());
                Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                Console.SetCursorPosition(40, 20); aux_2 = Console.ReadKey();
                key = aux_2.KeyChar.ToString();
                do
                {
                if (char.IsNumber(aux_2.KeyChar))
                {  
                    if (servicioContactoFamiliar.GetByPhone(key) == null)
                        {
                            Console.Clear();
                            if (key.ToString() == "" || key.ToString() == string.Empty)
                            {
                                view_lista_all(servicioContactoFamiliar.GetAll());
                            }
                            Console.WriteLine("No hay contactos con este nombre.");
                            Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                            Console.SetCursorPosition(40, 20); Console.Write(key);
                            aux_2 = Console.ReadKey(true);
                            char aux = aux_2.KeyChar;
                            if (char.IsNumber(aux))
                            {
                                key += aux;
                            }
                            else
                            {
                                if (aux_2.Key == ConsoleKey.Backspace && key != string.Empty)
                                {
                                    key = key.Remove(key.LastIndexOf(key.Last()));
                                }
                            }
                        Console.SetCursorPosition(40, 20); Console.Write(key);

                        }
                        else
                            {

                                view_lista_all(servicioContactoFamiliar.GetByPhone(key));
                                Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                                Console.SetCursorPosition(40, 20); Console.Write(key);
                                aux_2 = Console.ReadKey(true);
                                char aux = aux_2.KeyChar;
                                if (char.IsNumber(aux))
                                {
                                    key += aux;
                                }

                                else
                                {
                                    if (aux_2.Key == ConsoleKey.Backspace && key != string.Empty)
                                    {

                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                        key = key.Remove(key.LastIndexOf(key.Last()));
                                        Console.Clear();
                                        try
                                        {
                                            view_lista_all(servicioContactoFamiliar.GetByPhone(key));
                                        }
                                        catch
                                        {

                                        }
                                        Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                                        Console.SetCursorPosition(40, 20); Console.Write(key);
                                    }
                                    else
                                    {
                                        view_lista_all(servicioContactoFamiliar.GetAll());
                                    }

                                }
                            
                        }
                    }
                    else
                    {
                        if (char.IsLetter(aux_2.KeyChar))
                        {
                            if (servicioContactoFamiliar.GetByName(key) == null)
                            {
                                Console.Clear();
                                if (key.ToString() == "" || key.ToString() == string.Empty)
                                {
                                    view_lista_all(servicioContactoFamiliar.GetAll());
                                }
                                Console.WriteLine("No hay contactos con este nombre.");
                                Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                                Console.SetCursorPosition(40, 20); Console.Write(key);

                                aux_2 = Console.ReadKey(true);
                                char aux = aux_2.KeyChar;
                                if (char.IsLetter(aux))
                                {
                                    key += aux;
                                }
                                else
                                {
                                    if (aux_2.Key == ConsoleKey.Backspace && key != string.Empty)
                                    {
                                        key = key.Remove(key.LastIndexOf(key.Last()));
                                        try
                                        {
                                            view_lista_all(servicioContactoFamiliar.GetByName(key));
                                        }
                                        catch
                                        {

                                        }
                                        Console.SetCursorPosition(40, 20); Console.Write(key);

                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();

                                view_lista_all(servicioContactoFamiliar.GetByName(key));
                                Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                                Console.SetCursorPosition(40, 20); Console.Write(key);
                                aux_2 = Console.ReadKey(true);
                                char aux = aux_2.KeyChar;
                                if (char.IsLetter(aux))
                                {
                                    key += aux;
                                }
                                else
                                {
                                    if (aux_2.Key == ConsoleKey.Backspace)
                                    {

                                        key = key.Remove(key.LastIndexOf(key.Last()));
                                        Console.Clear();
                                        try
                                        {
                                            view_lista_all(servicioContactoFamiliar.GetByName(key));
                                        }
                                        catch
                                        {

                                        }
                                        Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                                        Console.SetCursorPosition(50, 20); Console.Write(key);
                                    }
                                    else
                                    {
                                        view_lista_all(servicioContactoFamiliar.GetAll());
                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(30, 20); Console.Write("Busqueda: ");
                            Console.SetCursorPosition(40, 20); Console.Write(key);

                            aux_2 = Console.ReadKey(true);
                            if (aux_2.Key == ConsoleKey.Backspace && key != string.Empty)
                            {
                                key = key.Remove(key.LastIndexOf(key.Last()));
                                try
                                {
                                    view_lista_all(servicioContactoFamiliar.GetByName(key));
                                }
                                catch
                                {

                                }
                            }
                            else
                            {
                                if (char.IsLetter(aux_2.KeyChar) || char.IsNumber(aux_2.KeyChar))
                                {
                                    key += aux_2.KeyChar.ToString();

                                }
                            }
                        }

                    }
                   
                } while (aux_2.Key != ConsoleKey.Escape);
            }

        }
  
        /// <summary>
        /// Imprime toda la lista de Contactos Familiares.
        /// </summary>
        private void view_lista_all(List<ContactoFamiliar> list)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 3); Console.Write("Lista de contactos");
            Console.SetCursorPosition(29, 5); Console.Write("|Id|");
            Console.SetCursorPosition(35, 5); Console.Write("Nombre |");
            Console.SetCursorPosition(45, 5); Console.Write("Telefono | ");
            Console.SetCursorPosition(60, 5); Console.Write("Fecha de nacimiento |");
            int i = 2;
            
            foreach (var item in list)
            {
       
                Console.SetCursorPosition(29, 4);  Console.Write("____________________________________________________");
                Console.SetCursorPosition(29, 4 + i); Console.Write("|");
                Console.SetCursorPosition(30, 4 + i); Console.Write(item.Id);
                Console.SetCursorPosition(35, 4 + i); Console.Write(item.Nombre);
                Console.SetCursorPosition(45, 4 + i); Console.Write(item.Telefono);
                Console.SetCursorPosition(60, 4 + i); Console.Write(item.FechaNacimiento.ToShortDateString());
                Console.SetCursorPosition(80, 4+i);Console.Write("|");
                i++;
            }
                Console.SetCursorPosition(29, 4+i); Console.Write("|__________________________________________________|");

        }
    }
}
