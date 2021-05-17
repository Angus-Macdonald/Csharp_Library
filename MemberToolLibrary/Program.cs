using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MemberToolLibrary
{
    class Program
    {
        public static ToolCollection toolCollect = new ToolCollection();
        public static MemberCollection memberCollect = new MemberCollection();
        public static ToolLibrarySystem system = new ToolLibrarySystem(toolCollect, memberCollect);
        public static string[,] catType = new string[9, 6];
        public static Index choices = new Index();
        public static Member currentMember = new Member("empty", "empty", "0", "0");
        public static string HideCharacter() //This needs updating/reference to stackoverflow
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    code = "";
                    Console.Write("       Password: ");
                }

            } while (key.Key != ConsoleKey.Enter);
            return code;
        }

        public static void WelcomeMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            string mainmenu = "################ MAIN MENU ####################";
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine(mainmenu);
            string options = @"
             1. Staff Login
             2. Member Login
             0. Exit";
            Console.WriteLine(options);
            Console.WriteLine();
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
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else { WelcomeMenu(); };
        }

        public static void StaffLogin()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine("################ Staff Login #####################");
            Console.WriteLine();
            Console.Write("       Username: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Password: ");
            string pass = HideCharacter();
            Console.WriteLine();

            if (input == PV.Staff() && pass == PV.Pass())
            {
                Console.WriteLine();
                Console.Write("Logging in ...");
                Thread.Sleep(1000);
                StaffMenu();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("You have entered an incorrect username or password.");
                Console.WriteLine("Press Enter to try again, or press any other key to exit.");
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
            Console.WriteLine();
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine("################ Member Login ####################");
            Console.WriteLine();
            Console.Write("       First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Password: ");
            string pass = HideCharacter();
            Console.WriteLine();
            Console.WriteLine();
            Member tempMember = new Member(first, last, "0", pass);

            int log = memberCollect.memberLogin(tempMember);
            if (log == 1)
            {
                currentMember = memberCollect.getMember(tempMember);

                Console.WriteLine("Logging in ...");
                Thread.Sleep(1000);
                MemberMenu();
            }
            else
            {
                if (log != 1)
                {
                    Console.WriteLine("Incorrect Username or Password");
                    Console.WriteLine("Press Enter to try again, or any other key to exit.");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Enter)
                    {
                        MemberLogin();
                    }
                    if (key != ConsoleKey.Enter)
                    {
                        WelcomeMenu();
                    }
                }

            }
        }

        public static void StaffMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 30);
            Console.WriteLine();
            string menu = "################ Staff Menu ####################";
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine(menu);
            Console.WriteLine(PV.staffOptions);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
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
                    AddTool();
                }
                if (input == '2')
                {
                    addExistingTool();
                }
                if (input == '3')
                {
                    removeQuantity();
                }
                if (input == '4')
                {
                    RegisterNewMember();
                }
                if (input == '5')
                {
                    RemoveMember();
                }
                if (input == '6')
                {
                    findContact();
                }
                else
                {
                    StaffMenu();
                }
            }
        }


        public static void AddTool()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("Tool Categories");
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category of tool 1-9, or 0 to return to previous menu");
            char category = Console.ReadKey(true).KeyChar;
            choices.CAT = Int32.Parse(category.ToString());
            if (category == '0')
            {
                StaffMenu();
            }
            Console.Clear();
            catDisplay(category);
            char type = Console.ReadKey(true).KeyChar;
            if (type == '0')
            {
                AddTool();
            }
            choices.TYPE = Int32.Parse(type.ToString());
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Creating New Tool");
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
            }
            if (q < 1)
            {
                Console.WriteLine("This is not a valid number, please enter a number greater than 0.");
                Thread.Sleep(1000);
                AddTool();
            }
            Tool newTool = new Tool(toolName, q, q, 0);
            if (toolCollect.search(newTool))
            {
                Console.WriteLine("This tool already exists. Please use the add new pieces of an existing tool option.");
                Console.WriteLine("Returning to staff menu now...");
                Thread.Sleep(1000);
                StaffMenu();
            }
            else
            {
                catType[choices.CAT - 1, choices.TYPE - 1] += newTool.Name + '/';
                system.add(newTool);
                Console.WriteLine("Tool added successfully.");
            }
            choices.clear();
            Console.WriteLine("Press Enter to add another tool, or any other key to return to menu.");
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.Enter)
            {
                AddTool();
            }
            if(key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        public static void addExistingTool()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("Add quantity to existing tool.");
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
                system.add(tempTool, q);
                Console.WriteLine("Quantity amount added to tool.");
                Console.WriteLine();
                Console.Write("Press Enter to add more, ");

            }
            else
            {
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            Console.WriteLine("or any other key to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Enter)
            {
                addExistingTool();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        public static void removeQuantity()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("Remove quantity to existing tool.");
            Console.WriteLine();
            foreach(Tool t in toolCollect.toArray())
            {
                Console.Write("Name:" + t.Name + " Available:" + t.AvailableQuantity + " | ");
            }
            Console.WriteLine();
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
                Console.WriteLine();
                Console.Write("Press Enter to remove a quantity from another tool, ");
            }
            else
            {
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            Console.WriteLine("or any other key to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Enter)
            {
                removeQuantity();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        public static void RegisterNewMember()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("New Member");
            Console.WriteLine();
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Phone: ");
            string mob = Console.ReadLine();
            Console.WriteLine();
            Console.Write("PIN: ");
            string pin = Console.ReadLine();
            Member tempMember = new Member(first, last, mob, pin);
            Console.WriteLine();
            if (memberCollect.search(tempMember))
            { 
                Console.Write("This user already exists.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");

            }
            else
            {
                system.add(tempMember);
                Console.WriteLine("User added to system.");
                Console.WriteLine();
                Console.Write("Press Enter to add another member, ");

            }
            Console.WriteLine("or any other key to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                RegisterNewMember();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }

        }

        public static void RemoveMember()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("Remove Member");
            Console.WriteLine();
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            Member tempMember = new Member(first, last, "0000", "0000");

            if (memberCollect.search(tempMember))
            {
                system.delete(tempMember);
                Console.WriteLine("This member has been deleted from the system.");
                Console.WriteLine();
                Console.Write("Press Enter to remove another member");
            }
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");

            }
            Console.WriteLine("or any other key to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                RemoveMember();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        public static void findContact()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("Contact Number of Member");
            Console.WriteLine();
            Console.WriteLine("Enter the member details");
            Console.WriteLine();
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            Member tempMember = new Member(first, last, "0000", "0000");
            if (memberCollect.search(tempMember))
            {
                string contact = system.getContact(tempMember);
                Console.WriteLine("The members contact number: " + contact);
                Console.WriteLine();
                Console.WriteLine("Press Enter to search again, ");
            }
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            Console.WriteLine("or any other key to exit to main menu.");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                findContact();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }


        public static void MemberMenu()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            string menu = "################ Member Menu ###################";
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine(menu);
            Console.WriteLine(PV.memberOptions);
            Console.WriteLine();
            Console.WriteLine(PV.spacer);
            Console.WriteLine();
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1 - 5, or 0 to return to log out: ");
            char input = Console.ReadKey(true).KeyChar;

            if (input == '0')
            {
                Console.WriteLine("Logging off ...");
                Thread.Sleep(1000);
                WelcomeMenu();
            }
            if (input == '1')
            {
                DisplayToolsOfType();
            }
            if (input == '2')
            {
                BorrowATool();
            }
            if (input == '3')
            {
                ReturnATool();
            }
            if (input == '4')
            {
                ListToolsIAmBorrowing();
            }
            if (input == '5')
            {
                ListTop3();
            }
            else { MemberMenu(); }
        }

        public static void ListTop3()
        {
            Console.Clear();
            Console.WriteLine("Top Three Most Borrowed");
            system.displayTopTHree();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit to main menu.");
            Console.ReadKey();
            MemberMenu();

        }

        public static void ListToolsIAmBorrowing()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Tools that you currently borrow");
            Console.WriteLine();
            string[] memberTools = memberCollect.getMember(currentMember).Tools;
            Console.WriteLine("Currently Borrowed:");
            foreach (string t in memberTools)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            MemberMenu();
        }

        public static void ReturnATool()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Return a Tool");
            Console.WriteLine();

            string[] memberTools = memberCollect.getMember(currentMember).Tools;
            Console.Write("Currently Borrowed: ");
            foreach (string t in memberTools)
            {
                Console.Write(t + "  ");
            }
            Console.WriteLine();
            Console.Write("Enter the name of the tool: ");
            string input = Console.ReadLine();

            if (memberTools.Contains(input))
            {
                foreach (string t in memberTools)
                {
                    if (t == input)
                    {
                        try
                        {
                            Tool returnTool = toolCollect.getTool(t);
                            Member returnMember = memberCollect.getMember(currentMember);
                            system.returnTool(returnMember, returnTool);

                            Console.WriteLine("Tool has been returned.");
                            break;
                        }
                        catch { }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("You have not borrowed that tool.");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to return another tool, or any key to return to menu");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                ReturnATool();
            }
            else
            {
                MemberMenu();
            }
        }

        public static void BorrowATool()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Borrow a Tool");
            Console.WriteLine();
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category between 1-9, or 0 to return to main menu.");
            char cat = Console.ReadKey().KeyChar;
            choices.CAT = Int32.Parse(cat.ToString());
            Console.Clear();
            Console.WriteLine();
            catDisplay(cat);
            if (cat == '0')
            {
                MemberMenu();
            }
            char type = Console.ReadKey().KeyChar;
            choices.TYPE = Int32.Parse(type.ToString());
            Console.Clear();
            Console.WriteLine();
            string[] toolNames = catType[choices.CAT - 1, choices.TYPE - 1].Split('/');
            ToolCollection toolTypes = new ToolCollection();
            foreach (string t in toolNames)
            {
                try
                {
                    Tool memberTools = toolCollect.getTool(t);
                    toolTypes.add(memberTools);
                }
                catch
                {}
            }
            foreach (Tool t in toolTypes.toArray())
            {
                Console.WriteLine("Name: " + t.Name + " Quantity: " + t.Quantity + " Available: " + t.AvailableQuantity);
            }
            Console.WriteLine();
            Console.Write("Enter the name of the tool: ");
            string input = Console.ReadLine();
            foreach (string name in toolNames)
            {
                if (name == input)
                {
                    try
                    {
                        Tool borrowingTool = toolCollect.getTool(name);
                        try
                        {
                            system.borrowTool(currentMember, borrowingTool);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); break; }

                        Console.WriteLine("You are now borrowing the current tools:");
                        foreach (string t in memberCollect.getMember(currentMember).Tools)
                        {
                            Console.Write(t + " ");
                        }
                    }
                    catch { }
                }
            }
            Thread.Sleep(2000);
            MemberMenu();
        }


        public static void DisplayToolsOfType()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Display Tools of a Type");
            Console.WriteLine();
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category between 1-9, or 0 to return to main menu.");
            char cat = Console.ReadKey().KeyChar;
            choices.CAT = Int32.Parse(cat.ToString());
            Console.Clear();
            Console.WriteLine();
            catDisplay(cat);
            if (cat == '0')
            {
                MemberMenu();
            }
            char type = Console.ReadKey().KeyChar;
            choices.TYPE = Int32.Parse(type.ToString());
            Console.Clear();
            Console.WriteLine();

            string[] toolNames = catType[choices.CAT - 1, choices.TYPE - 1].Split('/');
            ToolCollection toolTypes = new ToolCollection();
            foreach (string t in toolNames)
            {
                try
                {
                    Tool memberTools = toolCollect.getTool(t);

                    if (memberTools.Name != "null")
                    {
                        toolTypes.add(memberTools);
                    }
                }
                catch { }

            }

            foreach (Tool t in toolTypes.toArray())
            {
                Console.WriteLine("Name: " + t.Name + " Quantity: " + t.Quantity + " Available: " + t.AvailableQuantity);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu.");

            Console.ReadKey();
            MemberMenu();

        }

        public static void catDisplay(char cat)
        {
            if (cat == '1')
            {
                Console.WriteLine("Gardening Tools");
                Console.WriteLine(PV.gardeningTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '2')
            {
                Console.WriteLine("Flooring Tools");
                Console.WriteLine(PV.flooringTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '3')
            {
                Console.WriteLine("Fencing Tools");
                Console.WriteLine(PV.fencingTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '4')
            {
                Console.WriteLine("Measuring Tools");
                Console.WriteLine(PV.measuringTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '5')
            {
                Console.WriteLine("Cleaning Tools");
                Console.WriteLine(PV.cleaningTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '6')
            {
                Console.WriteLine("Painting Tools");
                Console.WriteLine(PV.paintingTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '7')
            {
                Console.WriteLine("Electronic Tools");
                Console.WriteLine(PV.electronicTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '8')
            {
                Console.WriteLine("Electricity Tools");
                Console.WriteLine(PV.electricityTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '9')
            {
                Console.WriteLine("Automotive Tools");
                Console.WriteLine(PV.automotiveTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
        }

        static void Main(string[] args)
        {
            WelcomeMenu();
        }
    }
}