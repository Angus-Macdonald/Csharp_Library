using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MemberToolLibrary
{
    class Menu
    {
        public static string HideCharacter() //This needs updating/reference to stackoverflow
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    code = "";
                    Console.Write("       Password: ");
                }
                if (key.Key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
            } while (key.Key != ConsoleKey.Enter);
            return code;
        }

        public static void WelcomeMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            string mainmenu = "################ MAIN MENU ####################";
            Console.WriteLine(PV.header);
            Console.WriteLine("");
            Console.WriteLine(mainmenu);
            string options = @"
             1. Staff Login
             2. Member Login
             0. Exit";
            Console.WriteLine(options);
            Console.WriteLine("");
            Console.WriteLine(PV.spacer);
            Console.WriteLine("Press 1 or 2 to log in");
            Console.WriteLine("Press 0 to exit the program");
            char theKey = Console.ReadKey(true).KeyChar;
            if (theKey == '1')
            {
                StaffLogin();
            }
            if (theKey == '2')
            {
                MemberLogin();
            }
            if (theKey == '0')
            {
                Console.WriteLine("Shutting down ...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        public static void StaffLogin()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.header);
            Console.WriteLine("");
            Console.WriteLine("################ Staff Login #####################");
            Console.WriteLine("");
            Console.Write("       Username: ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("       Password: ");
            string pass = HideCharacter();
            Console.WriteLine("");
            
            if (input == PV.Staff() && pass == PV.Pass())
            {
                Console.Write("Logging in ...");
                Thread.Sleep(2000);
                StaffMenu();
            }

            else
            {
                Console.WriteLine("You have entered an incorrect username or password.");
                Console.WriteLine("");
                Console.WriteLine("Press Enter to try again, else press any key to exit.");
                ConsoleKey i = Console.ReadKey().Key;
                if(i == ConsoleKey.Enter)
                {
                    StaffLogin();
                }
                else if(i != ConsoleKey.Enter)
                {
                    WelcomeMenu();
                }
            }  
        }

        public static void MemberLogin()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.header);
            Console.WriteLine("");
            Console.WriteLine("################ Member Login ####################");
            Console.WriteLine("");
            Console.Write("       First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("       Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("       Password: ");
            string pass = HideCharacter();

            Console.WriteLine("");


            Console.Write("Logging in ...");
            MemberMenu();
        }

        public static void StaffMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 30);
            Console.WriteLine("");
            string menu = "################ Staff Menu ####################";
            Console.WriteLine(PV.header);
            Console.WriteLine("");
            Console.WriteLine(menu);
            Console.WriteLine(PV.staffOptions);
            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("Please make a selection");
            Console.Write("1 - 6, or 0 to return to Main Menu: ");
            char input = Console.ReadKey().KeyChar;
            if (input == '0')
            {
                WelcomeMenu();
            }
        }

        public static void MemberMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            string menu = "################ Member Menu ###################";
            Console.WriteLine(PV.header);
            Console.WriteLine("");
            Console.WriteLine(menu);
            Console.WriteLine(PV.memberOptions);
            Console.WriteLine("");
            Console.WriteLine(PV.spacer);
            Console.WriteLine("");
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1 - 5, or 0 to return to log out: ");
            char input = Console.ReadKey(true).KeyChar;

            if (input == '0')
            {
                Console.WriteLine("Logging off ...");
                Thread.Sleep(2000);
                WelcomeMenu();
            }
            if(input == '1')
            {
                MemberOptions.Options.DisplayTools();
            }
        }
    }
}
