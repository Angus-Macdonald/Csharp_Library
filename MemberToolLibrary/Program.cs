using System;
using System.Collections.Generic;
using System.Threading;

namespace MemberToolLibrary
{
    class Program
    {
        public static ToolCollection toolCollect = new ToolCollection();
        public static MemberCollection memberCollect = new MemberCollection();
        public static ToolLibrarySystem system = new ToolLibrarySystem(toolCollect, memberCollect);
        public static Index choices = new Index();
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
                if (i == ConsoleKey.Enter)
                {
                    StaffLogin();
                }
                else if (i != ConsoleKey.Enter)
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
            Console.Write("       PIN: ");
            string pass = HideCharacter();

            Member tempMember = new Member(first, last, "0", pass);

            int log = memberCollect.memberLogin(tempMember);
            if (log == 1)
            {
                Console.WriteLine("Logging in ...");
                Thread.Sleep(2000);
                MemberMenu();
            }
            else
            {
                if (log == 0)
                {
                    Console.WriteLine("Incorrect Username or Password");
                    Console.WriteLine("Try again.");
                    Thread.Sleep(2000);
                    MemberLogin();
                }
                else
                {
                    Console.WriteLine("This user does not exist.");
                }
            }
            Console.WriteLine("");
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
            else
            {
                if (input == '1')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    AddTool();
                }
                if (input == '2')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    addExistingTool();
                }
                if (input == '3')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    removeQuantity();
                }
                if (input == '4')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    RegisterNewMember();
                }
                if (input == '5')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    RemoveMember();
                }
                if (input == '6')
                {
                    choices.FUNCTION = Int32.Parse(input.ToString());
                    findContact();
                }
            }
        }


        public static void AddTool()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.categories);
            Console.WriteLine("");
            Console.WriteLine("Select a category of tool 1-9, or 0 to return to previous menu");
            char category = Console.ReadKey(true).KeyChar;
            choices.CAT = Int32.Parse(category.ToString());
            if (category == '0')
            {
                StaffMenu();
            }
            Console.Clear();
            Console.WriteLine("");
            if (category == '1')
            {
                Console.WriteLine("Gardening Tools");
                Console.WriteLine();
                Console.WriteLine(PV.gardeningTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (category == '2')
            {
                Console.WriteLine("Flooring Tools");
                Console.WriteLine();
                Console.WriteLine(PV.flooringTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (category == '3')
            {
                Console.WriteLine("Fencing Tools");
                Console.WriteLine();
                Console.WriteLine(PV.fencingTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (category == '4')
            {
                Console.WriteLine("Measuring Tools");
                Console.WriteLine();
                Console.WriteLine(PV.measuringTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (category == '5')
            {
                Console.WriteLine("Cleaning Tools");
                Console.WriteLine();
                Console.WriteLine(PV.cleaningTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (category == '6')
            {
                Console.WriteLine("Painting Tools");
                Console.WriteLine();
                Console.WriteLine(PV.paintingTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (category == '7')
            {
                Console.WriteLine("Electronic Tools");
                Console.WriteLine();
                Console.WriteLine(PV.electronicTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (category == '8')
            {
                Console.WriteLine("Electricity Tools");
                Console.WriteLine();
                Console.WriteLine(PV.electricityTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (category == '9')
            {
                Console.WriteLine("Automotive Tools");
                Console.WriteLine();
                Console.WriteLine(PV.automotiveTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }

            char type = Console.ReadKey(true).KeyChar;
            if(type == '0')
            {
                AddTool();
            }
            choices.TYPE = Int32.Parse(type.ToString());
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Creating New Tool");
            Console.WriteLine(PV.spacer);
            Console.WriteLine();
            Console.Write("Enter the tool name: ");
            string toolName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity: ");
            string amount = Console.ReadLine();
            if (Int32.TryParse(amount, out int q))
            {

            }
            else
            {
                Console.WriteLine("That is not a valid input. Please enter a integer value (Example: 1)");

            }
            Tool newTool = new Tool(toolName, q, q, 0);
            

            if (choices.FUNCTION == 1)
            {
                if (toolCollect.search(newTool))
                {
                    Console.WriteLine("This tool already exists. Please use the add new pieces of an existing tool option.");
                    Console.WriteLine("Returning to staff menu now...");
                    Thread.Sleep(2000);
                    StaffMenu();

                }
                else
                {
                    toolCollect.catType[choices.CAT - 1, choices.TYPE - 1] += newTool.Name + '/';
                    Console.WriteLine(toolCollect.catType[choices.CAT - 1, choices.TYPE - 1]);
                    system.add(newTool);
                    Console.WriteLine("Tool added successfully.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("The tool was not added due to an error.");
            }
            choices.clear();
            Console.WriteLine("Returning to Staff Menu ...");
            Thread.Sleep(1000);
            StaffMenu();
        }

        public static void addExistingTool()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("Add quantity to existing tool.");
            Console.WriteLine();
            Console.Write("Tool name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity: ");
            string quant = Console.ReadLine();
            if(Int32.TryParse(quant, out int q))
            { }
            Tool tempTool = new Tool(name, q, q, 0);

            if (toolCollect.search(tempTool))
            {
                system.add(tempTool, q);
                Console.WriteLine("Quantity amount added to tool.");
                Console.WriteLine("Returning to Staff menu.");
                Thread.Sleep(1000);
                StaffMenu();
            }
            else
            {
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine("Press Enter to try again");
                Console.WriteLine("Press 0 to return to main menu.");
                ConsoleKey key = Console.ReadKey().Key;
                if(key == ConsoleKey.Enter)
                {
                    addExistingTool();
                }
                else
                {
                    if(key == ConsoleKey.D0)
                    {
                        StaffMenu();
                    }
                }
            }
        }

        public static void removeQuantity()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("Remove quantity to existing tool.");
            Console.WriteLine();
            Console.Write("Tool name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity: ");
            string quant = Console.ReadLine();
            if (Int32.TryParse(quant, out int q))
            { }
            Tool tempTool = new Tool(name, q, q, 0);

            if (toolCollect.search(tempTool))
            {
                system.delete(tempTool, q);
                Console.WriteLine("Quantity removed from tool.");
                Console.WriteLine("Returning to Staff menu.");
                Thread.Sleep(1000);
                StaffMenu();
            }
            else
            {
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine("Press Enter to try again");
                Console.WriteLine("Press 0 to return to main menu.");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    removeQuantity();
                }
                else
                {
                    if (key == ConsoleKey.D0)
                    {
                        StaffMenu();
                    }
                }
            }
        }

        public static void RegisterNewMember()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("New Member");
            Console.WriteLine("");
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Phone: ");
            string mob = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("PIN: ");
            string pin = Console.ReadLine();
            Member tempMember = new Member(first, last, mob, pin);

            if (memberCollect.search(tempMember))
            {
                Console.WriteLine("This user already exists.");
                Console.WriteLine("Press Enter to try again, or 0 to return to main menu.");
                ConsoleKey key = Console.ReadKey().Key;
                if(key == ConsoleKey.Enter)
                {
                    RegisterNewMember();
                }
                if(key == ConsoleKey.D0)
                {
                    StaffMenu();
                }
            }
            else
            {
                system.add(tempMember);
                Console.WriteLine("This user has been added to the system.");
                Thread.Sleep(1000);
                StaffMenu();
            }

        }

        public static void RemoveMember()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("Remove Member");
            Console.WriteLine("");
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("");
            Member tempMember = new Member(first, last, "0000", "0000");

            if (memberCollect.search(tempMember))
            {
                system.delete(tempMember);
                Console.WriteLine("This member has been deleted from the system.");
                Thread.Sleep(2000);
                StaffMenu();
            }
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine("Press Enter to try again, or 0 to return to main menu.");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    RemoveMember();
                }
                if (key == ConsoleKey.D0)
                {
                    StaffMenu();
                }
            }
        }

        public static void findContact()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine("Contact Number of Member");
            Console.WriteLine("");
            Console.WriteLine("Enter the member details");
            Console.WriteLine("");
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("");
            Member tempMember = new Member(first, last, "0000", "0000");
            if (memberCollect.search(tempMember))
            {
                string contact = system.getContact(tempMember);
                Console.WriteLine("The members contact number: " + contact);
                Console.WriteLine();
                Console.WriteLine("Press any key to exit to main menu.");
                Console.ReadKey();
                StaffMenu();
            }
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine("Press Enter to try again, or 0 to return to main menu.");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    findContact();
                }
                if (key == ConsoleKey.D0)
                {
                    StaffMenu();
                }
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
            if (input == '1')
            {
                DisplayToolsOfType();
            }
        }


        public static void DisplayToolsOfType()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Display Tools of a Type");
            Console.WriteLine("");
            Console.WriteLine(PV.categories);
            Console.WriteLine("");
            Console.WriteLine("Select a category between 1-9, or 0 to return to main menu.");
            char cat = Console.ReadKey().KeyChar;
            choices.CAT = Int32.Parse(cat.ToString());
            Console.Clear();
            Console.WriteLine("");
            if (cat == '1') { 
                Console.WriteLine("Gardening Tools");
                Console.WriteLine();
                Console.WriteLine(PV.gardeningTools);
                Console.WriteLine("");
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
                char type = Console.ReadKey().KeyChar;
                choices.TYPE = Int32.Parse(type.ToString());
                Console.Clear();
                Console.WriteLine();
                string[] toolNames = toolCollect.catType[choices.CAT - 1, choices.TYPE - 1].Split('/');
                ToolCollection toolTypes = new ToolCollection();
                foreach(string t in toolNames)
                {
                    Tool memberTools = toolCollect.getTool(t);

                    if (memberTools.Name != "null")
                    {
                        toolTypes.add(memberTools);
                    }
                    
                }

                foreach(Tool t in toolTypes.toArray())
                {
                    Console.WriteLine("Name: " + t.Name + " Quantity: " + t.Quantity + " Available: " + t.AvailableQuantity);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu.");

                Console.ReadKey();
                MemberMenu();
            }
        }


        static void Main(string[] args)
        {
            WelcomeMenu();
        }
    }
}