using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Principal
    {
        public static  void menu()
        {
            
            int op = 0;
            do
            {
                Console.WindowWidth = Console.LargestWindowWidth;
                Console.WindowHeight = Console.LargestWindowHeight;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Beep();
                Console.BufferHeight= Console.LargestWindowHeight;
                Console.BufferWidth= Console.LargestWindowWidth;
                
                Console.Title = "Contactos";
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+1); Console.Write("         Contactos ");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+2); Console.Write("____________________________________");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+4); Console.Write("1. Gestión de contactos Familiares. ");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+6); Console.Write("2. Gestión de contactos Empresariales. ");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+8); Console.Write("3. Salir.");
                Console.SetCursorPosition((Console.LargestWindowWidth / 3), (Console.LargestWindowHeight / 3)+10); Console.Write("Opcion :");
                try
                {

                    Console.SetCursorPosition((Console.LargestWindowWidth / 3)+8, (Console.LargestWindowHeight / 3) + 10);
                    
                    op = int.Parse(Console.ReadKey().KeyChar.ToString());
                }
                catch
                {
                 op = 0;
                }
                switch (op)
                {
                    case 1:
                        var familiargui = new ContactoFamiliarGUI();
                        familiargui.menu();
                        break;
                    case 2:
                        var empresagui = new ContactoEmpresaGUI();
                        break;

                        
                }
            } while (op != 3);
            }
    }
}
