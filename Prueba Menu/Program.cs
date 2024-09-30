


#region    USINGS


using System;
using System.ComponentModel.DataAnnotations.Schema;

//using ModuleHub.ConsoleApp.ClientOptions.MainMenu;


#endregion

namespace ModuleHub.PruebaMenu
{

    internal class Program
    {



        static async Task Main(string[] args)
        {







            int Try = 1;
            string AccessPassword = "ModuleHub";
            string Password;

            Console.WriteLine("                           **************    CLIENT  APPLICATION    ******************** ");
            Console.WriteLine("                    *****************   MODULE HUB CONFIGURATION   ***************************");
            Console.WriteLine("__________________________________________________________________________________________________________________");
            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("    Enter Password:                  ");


                Password = Console.ReadLine();

                if (Password == AccessPassword)
                {


                    // MainMenu mainMenu = new ClientOptions.MainMenu.MainMenu();

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("                        ********************      WELCOME      ********************");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    // mainMenu.OptionsList




                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("    Invalid  Password          Try Again.....");

                }

            } while (Try <= 3);

        }
    }

}