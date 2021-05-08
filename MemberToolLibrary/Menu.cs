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
                Console.Write("*");
                code += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter);
            return code;
        }

        public static void WelcomeMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            string welcome = "   Welcome to the Library Tool Rental System  ";
            string mainmenu = "################ MAIN MENU ####################";
            Console.WriteLine(welcome);
            Console.WriteLine("");
            Console.WriteLine(mainmenu);
            string options = @"
             1. Staff Login
             2. Member Login
             0. Exit";
            Console.WriteLine(options);
            Console.WriteLine("");
            Console.WriteLine("###############################################");
            Console.WriteLine("Press 1 or 2 to log in");
            Console.WriteLine("Press 0 to exit the program");
            char theKey = Console.ReadKey(true).KeyChar;
            if (theKey == '1')
            {
                StaffLogin();
            }
            if (theKey == '2')
            {
                Console.WriteLine("You are logging in as a Member");
                MemberLogin();
            }
            if (theKey == '0')
            {
                Console.WriteLine("You are logging off...");
                Environment.Exit(0);
            }
        }

        public static void StaffLogin()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("          Library Tool Rental System  ");
            Console.WriteLine("");
            Console.WriteLine("################ Staff Login #####################");
            Console.WriteLine("");
            Console.Write("       Username: ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("       Password: ");
            string pass = HideCharacter();
            Console.WriteLine("");
            Console.WriteLine(pass);
            Console.WriteLine("");
            Console.Write("Logging in ...");
            StaffMenu();
        }

        public static void MemberLogin()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("          Library Tool Rental System  ");
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
            Console.WriteLine(pass);
            Console.WriteLine("");
            Console.Write("Logging in ...");
            MemberMenu();
        }

        public static void StaffMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 30);
            Console.WriteLine("");
            string welcome = "   Welcome to the Library Tool Rental System  ";
            string menu = "################ Staff Menu ####################";
            Console.WriteLine(welcome);
            Console.WriteLine("");
            Console.WriteLine(menu);
            string options = @"
1. Add a new tool
2. Add new pieces of an existing tool
3. Remove some pieces of a tool
4. Register a new member
5. Remove a member
6. Find the contact number of a member
0. Return to Main Menu";
            Console.WriteLine(options);
            Console.WriteLine("");
            Console.WriteLine("###############################################");
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
            string welcome = "   Welcome to the Library Tool Rental System  ";
            string menu = "################ Member Menu ###################";
            Console.WriteLine(welcome);
            Console.WriteLine("");
            Console.WriteLine(menu);
            string options = @"
1. Display all the tools of a tool type
2. Borrow a tool
3. Return a tool
4. List all the tools that I am renting
5. Display the top three (3) most frequently rented tools
0. Return to Main Menu";
            Console.WriteLine(options);
            Console.WriteLine("");
            Console.WriteLine("###############################################");
            Console.WriteLine("");
            Console.WriteLine("Please make a selection");
            Console.Write("1 - 5, or 0 to return to Main Menu: ");
            char input = Console.ReadKey().KeyChar;

            if (input == '0')
            {
                WelcomeMenu();
            }
        }
    }
}
