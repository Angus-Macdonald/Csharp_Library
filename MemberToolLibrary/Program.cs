using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MemberToolLibrary
{
    /// <summary>
    /// This main class that holds all instances of ToolCollection/MemberCollection/ToolLibrarySystem.
    /// This class holds all functions for displaying the menu's.
    /// </summary>
    class Program
    {
        /// A ToolCollection object to store Tools added to the system.
        public static ToolCollection toolCollect = new ToolCollection();
        /// A MemberCollection object to store Members added to the system.
        public static MemberCollection memberCollect = new MemberCollection();
        /// A ToolLibrarySystem object to manipulate the Tool and Member collections.
        public static ToolLibrarySystem system = new ToolLibrarySystem(toolCollect, memberCollect);
        /// A String 2-dimensional array to store a string for each type; that contains the names of tools of that type,
        /// seperated by a dividing character. This could be a jaggered array to save 4 blocks of memory
        /// (50 tool types, this instance allocates 54 blocks) but for code clarity and ease of use,
        /// I found it was appropriate to waste such minimal memory.
        public static string[,] catType = new string[9, 6];
        /// An instance of the Index object, please read class comments for Index.cs for further clarity on use.
        public static Index choices = new Index();
        /// A blank member object that is given the logged in users data upon successful log in.
        public static Member currentMember = new Member("empty", "empty", "0", "0");
        /// An array of ints of "choices" a user can make throughout the menus. Created for checking if the input was valid.
        public static char[] charChoices = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        /// <summary>
        /// This function has been developed from existing code written by user Mohammed Nadeem on 04/08/2010
        /// at https://stackoverflow.com/questions/3404421/password-masking-console-application, accessed 04/05/2021.
        ///
        /// This function allows for console readline entries to be masked with '*' characters opposed to the input
        /// characters, primarily to hide a users password upon entry.
        /// </summary>
        /// <returns> A string containing the input hidden string. </returns>
        public static string HideCharacter()
        {
            /// Initialising a ConsoleKeyInfo variable.
            ConsoleKeyInfo key;
            /// A variable to store the entered string.
            string input = "";

            /// Starts loop
            do
            {
                /// Reads the next key input by user.
                key = Console.ReadKey(true);
                /// If the input key is not enter (the user has not finished typing their string)
                if (key.Key != ConsoleKey.Enter)
                {
                    /// Writes 1 '*' character to console.
                    Console.Write("*");
                    /// Updates the input string by appending input character
                    input += key.KeyChar;
                }
                /// If the user has entered the backspace key.
                if (key.Key == ConsoleKey.Backspace)
                {
                    /// Resets the line and empties the input string.
                    /// If the user backspaces, appears to delete the entire entered string and waits for new a new hidden input.
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    input = "";
                    Console.Write("       Password: ");
                }
             
            }
            /// After code has finished, if the entered key is not Enter key, it will run again
            while (key.Key != ConsoleKey.Enter);
            /// Once user has input the Enter key, it returns the entered string.
            return input;
        }

        /// <summary>
        /// This function prints the first menu to console, it allows the user to select from Staff or Member log in. Or close the system down.
        /// </summary>
        public static void WelcomeMenu()
        {
            /// Clearing the console
            Console.Clear();
            /// Sets window size
            Console.SetWindowSize(47, 20);
            /// Formatting
            Console.WriteLine();
            /// Header
            Console.WriteLine(PV.header);
            Console.WriteLine();
            /// Title
            Console.WriteLine("--------------- MAIN MENU---------------- ");
            /// Variable of options
            string options = @"
             1. Staff Login
             2. Member Login
             0. Exit";
            /// Printing them to console
            Console.WriteLine(options);
            Console.WriteLine();
            /// Formatting and providing choice options
            Console.WriteLine(PV.spacer);
            Console.WriteLine("Press 1 or 2 to log in");
            Console.WriteLine("Press 0 to exit the program");
            /// Takes the input from console
            char theKey = Console.ReadKey(true).KeyChar;
            /// Choice 1 runs the Staff Log In Menu
            if (theKey == '1')
            {
                StaffLogin();
            }
            /// Choice 2 runs the Member Log In Menu
            if (theKey == '2')
            {
                MemberLogin();
            }
            /// Choice 0 shuts down the console.
            if (theKey == '0')
            {
                Console.WriteLine("Shutting down ...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            /// If user presses anything else, just keeps them on the same screen.
            else { WelcomeMenu(); };
        }


        /// <summary>
        /// This function prints Staff Log In menu details to console
        /// </summary>
        public static void StaffLogin()
        {
            /// General set-up and formatting
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine("-------------- Staff Login --------------");
            Console.WriteLine();
            Console.Write("       Username: ");
            /// Takes the input Username
            string input = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Password: ");
            /// Tkes the input Password, which is character hidden
            string pass = HideCharacter();
            Console.WriteLine();

            /// If the input username and password are matching to the static variables
            /// found in PV.cs, runs the staff menu function.
            if (input == PV.Staff() && pass == PV.Pass())
            {
                Console.WriteLine();
                Console.Write("Logging in ...");
                Thread.Sleep(1000);
                StaffMenu();
            }
            /// If wrongs, prompts the user with an error, asks for an input to try again
            /// or take back to welcome menu.
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

        /// <summary>
        /// Console prints for the Member to log in, asks for a firstname, lastname and password.
        /// Checks the details within the system.
        /// </summary>
        public static void MemberLogin()
        {
            /// Formatting and set-up
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine("-------------- Member Login -------------");
            Console.WriteLine();
            Console.Write("       First Name: ");
            /// User inputs firstname of member
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Last Name: ");
            /// User inputs lastname of member
            string last = Console.ReadLine();
            Console.WriteLine();
            Console.Write("       Password: ");
            /// User inputs password of member
            string pass = HideCharacter();
            Console.WriteLine();
            Console.WriteLine();

            /// Creates a temporary member object with the input details
            Member tempMember = new Member(first, last, "0", pass);
            /// Collects the members within the system into an array
            Member[] memberArray = memberCollect.toArray();
            /// Searches an array of Members using Array.Exists (which has time complexity of O(n) / linear search) bu last name, first name, and password.
            /// This function has to be used as our Binary Search Tree search function asks for only searching by last name, and first name.
            if (Array.Exists(memberArray, x => (x.LastName, x.FirstName, x.PIN) == (tempMember.LastName, tempMember.FirstName, tempMember.PIN)))
            {
                /// If the user exists, grabs the member information and stores within current member info.
                currentMember = memberArray.First(x => (x.LastName, x.FirstName, x.PIN) == (tempMember.LastName, tempMember.FirstName, tempMember.PIN));
                Console.WriteLine("Logging in ...");
                Thread.Sleep(1000);
                /// Runs Member Menu function
                MemberMenu();
            }
            /// If the user is not found, display error message and prompt to try again
            /// or exit.
            else
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

        /// <summary>
        /// Displays the options for Staff Menu
        /// </summary>
        public static void StaffMenu()
        {
            //Set-up and formatting
            Console.Clear();
            Console.SetWindowSize(47, 30);
            Console.WriteLine();
            string menu ="-------------- Staff Menu ---------------";
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine(menu);
            /// Display options and prompt choices
            Console.WriteLine(PV.staffOptions);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please make a selection");
            Console.Write("1 - 6, or 0 to return to Main Menu: ");
            /// Take input
            char input = Console.ReadKey().KeyChar;
            /// Logs user out
            if (input == '0')
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("       Are you sure you want to log out?");
                Console.WriteLine("");
                Console.Write("       Y/N:");
                char i = Console.ReadKey(true).KeyChar;
                if (i == 'y' || i == 'Y')
                {
                    Console.WriteLine();
                    Console.WriteLine("Logging off...");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    WelcomeMenu();
                }
                if (i == 'n' || i == 'N')
                {
                    StaffMenu();
                }
            }
            /// Input choice prompts relating menu function to execute
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

        /// <summary>
        /// This function is used for a Staff Member to add a new tool to the library.
        /// The function displays the categories and types of tools, in which the user
        /// input is stored within the "choices" Index constructor. The program takes the
        /// user inputs and creates a new tool object, then uses the system.Add function to
        /// add this new tool within the system.
        /// </summary>
        public static void AddTool()
        {
            /// Formatting and Set-up
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("------------ Tool Categories ------------");
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category of tool 1-9, or 0 to return to previous menu");
            char category = Console.ReadKey(true).KeyChar;
            /// If the input category is in 0-9
            if (charChoices.Contains(category))
            {
                /// Parse the char to an into and store it within the constructor 
                choices.CAT = Int32.Parse(category.ToString());
            }
            /// Returns to Staff Menu
            if (category == '0')
            {
                StaffMenu();
            }
            /// Set up and display
            Console.Clear();
            /// Takes the input category and prints the relating tool types of category to screen
            catDisplay(category);
            /// Takes the input
            char type = Console.ReadKey(true).KeyChar;
            /// If 0, returns to previous menu.
            if (type == '0')
            {
                AddTool();
            }
            /// If valid input, parses the char to an int and stores within the constructor. 
            if (charChoices.Contains(type))
            {
                choices.TYPE = Int32.Parse(type.ToString());
            }
            /// If the input is invalid, just start the process again
            else
            {
                Console.WriteLine("That is not a valid input");
                Thread.Sleep(1000);
                AddTool();
            }
            /// Formatting and Set Up
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---------------- Create a New Tool ------------------");
            Console.WriteLine();
            Console.Write("      Enter the tool name: ");
            /// Tool name input
            string toolName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("                 Quantity: ");
            string amount = Console.ReadLine();
            /// To amount input
            if (Int32.TryParse(amount, out int q))
            {
                /// This tries to convert the input amount from a char to an int
                /// If the input is not a valid number, it will be less than 1.
            }
            else
            {
            }
            /// In the case where the input quantity isn't valid.
            if (q < 1)
            {
                /// Prints the error to console, and runs the function again.
                Console.WriteLine("This is not a valid number, please enter a number greater than 0.");
                Thread.Sleep(1000);
                AddTool();
            }
            /// Stores the name and added quantity within a new tool object
            Tool newTool = new Tool(toolName, q, q, 0);
            /// Searches the collection to see if this tool already exists.
            if (toolCollect.search(newTool))
            {
                /// If the Tool already exists, prompts user to use the correct option on staff menu.
                Console.WriteLine("This tool already exists. Please use the add new pieces of an existing tool option");
                Console.WriteLine("on the staff menu.");
                /// Offers to exit back to staff menu to use correct option, or in case of typo, user can start the process again.
                Console.WriteLine("Press Enter to try again, or any other key to return to staff menu.");
                ConsoleKey input = Console.ReadKey().Key;
                if(input == ConsoleKey.Enter)
                {
                    AddTool();
                }
                if(input != ConsoleKey.Enter)
                {
                    StaffMenu();
                }  
            }
            /// If the tool doesn't exist within the system.
            else
            {
                /// Appends the name of the tool followed by '/' to the associated category and type string cell within catType.
                catType[choices.CAT - 1, choices.TYPE - 1] += newTool.Name + '/';
                /// Adds the tool to the system.
                system.add(newTool);
                /// Confirms with user
                Console.WriteLine("Tool added successfully.");
            }
            /// Resets the choices for category and index made.
            choices.clear();
            /// Gives options to add another tool or return to menu.
            Console.WriteLine("Press Enter to add another tool, or any other key to return to menu.");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                AddTool();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        /// <summary>
        /// This functions adds quantity to an existing member.
        /// </summary>
        public static void addExistingTool()
        {
            /// Format and setup of window
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("            Add quantity to existing Tool            ");
            Console.WriteLine("-----------------------------------------------------");
            /// If there exists some number of Tool within the system.
            if (toolCollect.Number != 0)
            {
                /// Prints all information of tools to console.
                foreach (Tool t in toolCollect.toArray())
                {
                    t.printTool();
                }
            }
            Console.WriteLine();
            Console.Write("Tool Name: ");
            /// Takes the input of the name of tool user wishes to add more pieces.
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity: ");
            /// Takes the quantity they wish to add.
            string quant = Console.ReadLine();
            if (Int32.TryParse(quant, out int q))
            { /// Runs a tryparse on the quantity to assure input validity
            }

            if(q < 1)
            {
                Console.WriteLine("This is not a valid input for quantity.");
                Thread.Sleep(1000);
                addExistingTool();
            }
            /// Creates a new tool and stores the input information within.
            Tool tempTool = new Tool(name, q, q, 0);

            /// If the tool exists within the system
            if (toolCollect.search(tempTool))
            {
                /// Add the tool to the system in an amount of quantity
                system.add(tempTool, q);
                /// Formatting and assurance
                Console.WriteLine("Quantity amount added to tool.");
                Console.WriteLine();
                Console.Write("Press Enter to add more, ");

            }
            /// If tool does not exist within system
            else
            {
                /// Provide error
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            Console.WriteLine("or any other key to return to main menu.");
            /// Takes user input to either try again or return to menu
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

        /// <summary>
        /// This function provides the user with the ability to remove a quantity
        /// of an existing tool.
        /// </summary>
        public static void removeQuantity()
        {
            /// Format and setup
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("           Remove quantity to existing Tool          ");
            Console.WriteLine("-----------------------------------------------------");
            /// If there are tools within the system
            if (toolCollect.Number != 0)
            {
                /// Prints all the tools within the system out to the user
                foreach (Tool t in toolCollect.toArray())
                {
                    t.printTool();
                }
            }
            /// Provide the user with information regarding the amount of tools within system,
            else
            {
                Console.WriteLine("         There are no Tools in the system        ");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu.");
                Console.ReadKey();
                StaffMenu();
            }
            Console.WriteLine();
            Console.Write("Tool Name: ");
            /// Takes the input of a Tool name to remove quantity
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Quantity: ");
            /// Takes the input of a Tool quantity to remove
            string quant = Console.ReadLine();

            if (Int32.TryParse(quant, out int q))
            {
                /// Attempts to convert the input into an integer
            }
            /// If the input quantity is not valid, provides error and restarts function.
            if(q < 1)
            {
                Console.WriteLine("This is not a valid quantity.");
                Thread.Sleep(1000);
                removeQuantity();
            }

            /// Create a new tool with the input name and quantity
            Tool tempTool = new Tool(name, q, q, 0);

            /// Uses the tempTool to search if it exists within the sytem.
            if (toolCollect.search(tempTool))
            {
                /// Retrieves the tool from the collection where they share the same name
                Tool deleteTool = toolCollect.toArray().First(x => x.Name == tempTool.Name);
                try
                {
                    /// Deletes the tool from the system.
                    system.delete(deleteTool, q);
                }
                /// Prints any errors that are caught
                catch(Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine();
                Console.Write("Press Enter to remove a quantity from another tool, ");
            }
            /// Provides information the tool was not found within the system.
            else
            {
                Console.WriteLine("Tool not found in system.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            Console.WriteLine("or any other key to return to main menu.");
            ConsoleKey key = Console.ReadKey().Key;
            /// Takes the users input and updates to menu they wish to go to.
            if (key == ConsoleKey.Enter)
            {
                removeQuantity();
            }
            if (key != ConsoleKey.Enter)
            {
                StaffMenu();
            }
        }

        /// <summary>
        /// This function provides menus for the staff member to register a new member.
        /// </summary>
        public static void RegisterNewMember()
        {
            /// Set up and formatting
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("--------------------- New Member --------------------");
            Console.WriteLine();
            /// Takes the information for Names, contact number and password of the new user
            Console.Write("            First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("             Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            Console.Write("                 Phone: ");
            string mob = Console.ReadLine();
            Console.WriteLine();
            Console.Write("              Password: ");
            string pin = Console.ReadLine();
            /// Creates a temporary member to store this data within
            Member tempMember = new Member(first, last, mob, pin);
            Console.WriteLine();
            /// If this user already exists within the system.
            if (memberCollect.search(tempMember))
            {
                /// Provides errors
                Console.Write("This user already exists.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");

            }
            /// If the user does not exist
            else
            {
                /// Adds the user to the system and provides assurance 
                system.add(tempMember);
                Console.WriteLine("User added to system.");
                Console.WriteLine();
                Console.Write("Press Enter to add another member, ");

            }

            /// Handles users input for next menu.
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

        /// <summary>
        /// This function provides a menu for the user to remove a member from the system
        /// </summary>
        public static void RemoveMember()
        {
            /// Set up and formatting
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("------------------ Remove Member --------------------");
            Console.WriteLine();
            /// Takes the input of names of the member to remove
            Console.Write("        First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("         Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();

            /// Creates a temporary member object with details of input
            Member tempMember = new Member(first, last, "0000", "0000");

            /// Searches the system for the member, if they exist
            if (memberCollect.search(tempMember))
            {
                /// Deletes the member and provides assurance
                system.delete(tempMember);
                Console.WriteLine("This member has been deleted from the system.");
                Console.WriteLine();
                Console.Write("Press Enter to remove another member, ");
            }
            /// If they do not exist, provides error
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");

            }
            /// Takes input of user and returns appropriate menu
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

        /// <summary>
        /// Creates a menu for the user to find the contact number of a user
        /// </summary>
        public static void findContact()
        {
            /// Formatting and setup
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            Console.WriteLine("------- Contact Number of Member -------");
            Console.WriteLine();
            Console.WriteLine("Enter the member details");
            Console.WriteLine();
            /// Takes the member names for searching
            Console.Write("First name: ");
            string first = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine();
            /// Creates a temporary member
            Member tempMember = new Member(first, last, "0000", "0000");
            /// Searches if the member exists by their name, if they exist
            if (memberCollect.search(tempMember))
            {
                /// Gets the contact number of the user and prints to console
                string contact = system.getContact(tempMember);
                Console.WriteLine("The members contact number: " + contact);
                Console.WriteLine();
                Console.WriteLine("Press Enter to search again, ");
            }
            /// If user doesn't exist, returns errors
            else
            {
                Console.WriteLine("This user does not exist.");
                Console.WriteLine();
                Console.Write("Press Enter to try again, ");
            }
            /// Takes users input for next menu options.
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


        /// <summary>
        /// This function provides a menu with options for the user.
        /// </summary>
        public static void MemberMenu()
        {
            /// Formatting and set up
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine();
            string menu ="-------------- Member Menu --------------";
            Console.WriteLine(PV.header);
            Console.WriteLine();
            Console.WriteLine(menu);
            Console.WriteLine(PV.memberOptions);
            Console.WriteLine();
            Console.WriteLine(PV.spacer);
            Console.WriteLine();
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1 - 5, or 0 to return to log out: ");
            /// Takes the input from the user
            char input = Console.ReadKey(true).KeyChar;
            /// If the user wishes to log out, provides a confirmation page to log out
            if (input == '0')
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("       Are you sure you want to log out?");
                Console.WriteLine("");
                Console.Write("       Y/N:");
                char i = Console.ReadKey(true).KeyChar;
                if(i == 'y' || i == 'Y')
                {
                    Console.WriteLine();
                    Console.WriteLine("Logging off...");
                    Thread.Sleep(1000);
                    WelcomeMenu();
                }
                if(i == 'n' || i == 'N')
                {
                    MemberMenu();
                }

            }
            /// Takes the input options and runs function of relation
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
            /// Otherwise just keeps member on same menu
            else { MemberMenu(); }
        }

        /// <summary>
        /// This function provides a menu that displays the top 3 most borrowed tools.
        /// </summary>
        public static void ListTop3()
        {
            /// Formatting
            Console.Clear();
            Console.WriteLine("-------- Top Three Most Borrowed --------");
            /// Runs the system function
            system.displayTopTHree();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit to main menu.");
            Console.ReadKey();
            MemberMenu();

        }

        /// <summary>
        /// This function displays a menu of tools the member is borrowing
        /// </summary>
        public static void ListToolsIAmBorrowing()
        {
            /// Formatting
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---- Tools that you currently borrow ----");
            Console.WriteLine();
            /// Retrieves the member object of the logged in member using a linear search: O(n) time complexity
            Member newMember = memberCollect.toArray().First(x => (x.LastName, x.FirstName) == (currentMember.LastName, currentMember.FirstName));
            /// Retrieves the string array within the member
            string[] memberTools = newMember.Tools;
            /// Writes the tools to console.
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

        /// <summary>
        /// This function allows a Member to return a tool through the menu
        /// </summary>
        public static void ReturnATool()
        {
            /// Formatting
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------- Return a Tool -------");
            Console.WriteLine();
            /// Retrieves the current tools the member is borrowings
            string[] memberTools = currentMember.Tools;
            Console.Write("Currently Borrowed: ");
            /// Prints the currents tools borrowed to console.
            foreach (string t in memberTools)
            {
                Console.Write(t + " | ");
            }
            /// Takes user input for tool they wish to return
            Console.WriteLine();
            Console.Write("Enter the name of the tool: ");
            string input = Console.ReadLine();
            /// Retrieves the tool array
            Tool[] tempTools = toolCollect.toArray();
            /// If the current members borrowed tools contains the input name
            if (memberTools.Contains(input))
            {
                /// Foreach tool name in the users borrowed tools
                foreach (string t in memberTools)
                {
                    /// If the tool name is the same as the input name
                    if (t == input)
                    {
                        try
                        {
                            /// Retrieves the tool object from the array with the same name
                            Tool returnTool = tempTools.First(x => x.Name == t);
                            try
                            {   /// Uses the system return tool function to return the tool.
                                system.returnTool(currentMember, returnTool);
                            }catch(Exception e) { Console.WriteLine(e.Message); break; }

                            Console.WriteLine("Tool has been returned.");
                            /// Once tool has been found, breaks out of loop as the function is complete
                            break;
                        }
                        catch { }
                    }
                    /// If the tool name isn't the searched tool, just continue the loop
                    else
                    {
                        continue;
                    }
                }
            }
            /// If the tool doesn't exist within the members tools, provide error
            else
            {
                Console.WriteLine("You have not borrowed that tool.");
            }
            /// Take user input for next menu options.
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


        /// <summary>
        /// This function provides a menu for the member to borrow a tool from a category and type choice.
        /// </summary>
        public static void BorrowATool()
        {
            /// Formatting 
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------------------ Borrow a Tool --------------------");
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category between 1-9, or 0 to return to main menu.");
            /// Take the input for the category and type the member wishes to borrow from.
            char cat = Console.ReadKey().KeyChar;
            if (charChoices.Contains(cat))
            {
                choices.CAT = Int32.Parse(cat.ToString());
            }
            Console.Clear();
            catDisplay(cat);
            if (cat == '0')
            {
                MemberMenu();
            }
            char type = Console.ReadKey().KeyChar;
            if (charChoices.Contains(type))
            {
                choices.TYPE = Int32.Parse(type.ToString());
            }
            Console.Clear();
            Console.WriteLine();
            string[] toolNames = {};
            /// Takes the input choices and refers to the index of catType, which holds a string with the names of tools in that type,
            /// that are divided by a '/' tool. It splits the string by the names and holds them within a string[] 
            try
            {
                toolNames = catType[choices.CAT - 1, choices.TYPE - 1].Split('/');
            }
            catch { }
            choices.clear();
            Console.WriteLine();
            Console.WriteLine("------------------ Borrow a Tool --------------------");
            Console.WriteLine();
            /// Grab the tool array
            Tool[] tempTools = toolCollect.toArray();
            /// If there is at least one tool
            if (toolNames.Length != 0)
            {
                /// For each string (name of tool in that type) within the type
                foreach (string t in toolNames)
                {
                    try
                    {
                        /// Retrieves the tool object from the array: O(n) time complexity for the first tool
                        /// The time complexity reduces by 1 for each string within the loop, for e.g. a type
                        /// with 3 tools within, the time complexity is: O(n) + O(n-1) + O(n-2) as there are no
                        /// duplicate tool names, once a tool has been found in the worst case, the n search will
                        /// be reduced by 1.
                        Tool memberTools = tempTools.First(x => x.Name == t);
                        /// Prints the tool to console.
                        memberTools.printTool();
                    }
                    catch { }
                }
                /// Prompts the user for input
                Console.WriteLine();
                Console.Write("Enter the name of the tool: ");
                string input = Console.ReadLine();
                bool exists = false;
                /// Searches the array of names for th input tool name
                foreach (string name in toolNames)
                {
                    if (name == input)
                    {
                        /// If the tool is found
                        exists = true;
                        try
                        {
                            /// Retrieves the tool object from the system: O(n)
                            Tool borrowingTool = tempTools.First(x => x.Name == name);
                            try
                            {
                                /// Uses the system function to borrow tool
                                system.borrowTool(currentMember, borrowingTool);
                                
                            }
                            catch (Exception e) { Console.WriteLine(e.Message);}
                            Console.WriteLine();
                            Console.WriteLine("You are now borrowing the current tools:");
                            foreach (string t in currentMember.Tools)
                            {
                                Console.Write(t + " ");
                            }
                            Console.WriteLine();
                            break;
                        }
                        catch { }
                    }
                    else
                    {
                        continue;
                    }
                }
                /// If the input name of tool doesn't exist, provide error.
                if (!exists)
                {
                    Console.WriteLine("That tool is not in the system.");
                }
            }
            /// If there are no tools within the type, provide information.
            else
            {
                Console.WriteLine("No tools available.");
            }
            /// Provide input for user
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            MemberMenu();
        }

        /// <summary>
        /// This function allows the user to access a menu that display the
        /// tools of a type from their input.
        /// </summary>
        public static void DisplayToolsOfType()
        {
            /// Formatting
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-------- Display Tools of a Type --------");
            Console.WriteLine(PV.categories);
            Console.WriteLine("Select a category between 1-9, or 0 to return to main menu.");
            /// Take user input for the category they wish to view
            char cat = Console.ReadKey().KeyChar;
            if (charChoices.Contains(cat))
            {
                choices.CAT = Int32.Parse(cat.ToString());
            }
            else
            {
                Console.WriteLine("This is not a valid input.");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                DisplayToolsOfType();
            }
            /// Clears the console, prints out the types of that category
            Console.Clear();
            catDisplay(cat);
            /// Returns them to menu
            if (cat == '0')
            {
                MemberMenu();
            }
            /// Takes the type input
            char type = Console.ReadKey().KeyChar;
            if (charChoices.Contains(type))
            {
                choices.TYPE = Int32.Parse(type.ToString());
            }
            /// Clear the console
            Console.Clear();
            Console.WriteLine();
            string[] toolNames = {};
            /// Retrieves all the string of tools within that type and splits them into an array
            try
            {
                toolNames = catType[choices.CAT - 1, choices.TYPE - 1].Split('/');
            }
            catch { }
            choices.clear();
            /// Grabs the array of tool objects
            Tool[] tempTools = toolCollect.toArray();
            /// If there is at least 1 tool
            if (toolNames.Length != 0)
            {
                /// For all the names within that type
                foreach (string t in toolNames)
                {
                    try
                    {
                        /// Retrieves the tool object from the array
                        Tool memberTools = tempTools.First(x => x.Name == t);

                        if (memberTools.Name != "null")
                        {
                            /// Prints the tool information to console.
                            memberTools.printTool();
                        }
                    }
                    catch { }
                }
            }
            else
            {
                Console.WriteLine("No tools available.");
            }
            /// Prompts user with input to return to menu.
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu.");

            Console.ReadKey();
            MemberMenu();

        }

        /// <summary>
        /// This function takes a character value, and under the condition of
        /// which character is input, prints the types under the character of correlating
        /// category. This function was created to stop recurring if statements within menu
        /// functions for displaying category types.
        /// </summary>
        /// <param name="cat"> A character from 1-9 (categories 1 - 9) </param>
        public static void catDisplay(char cat)
        {
            /// If the category input is 1, refers to the first category, prints the header and types under gardening tools
            if (cat == '1')
            {
                Console.WriteLine("---------- Gardening Tools ----------");
                Console.WriteLine(PV.gardeningTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            /// This continues for all categories.
            if (cat == '2')
            {
                Console.WriteLine("---------- Flooring Tools ----------");
                Console.WriteLine(PV.flooringTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '3')
            {
                Console.WriteLine("---------- Fencing Tools ----------");
                Console.WriteLine(PV.fencingTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '4')
            {
                Console.WriteLine("---------- Measuring Tools ----------");
                Console.WriteLine(PV.measuringTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '5')
            {
                Console.WriteLine("---------- Cleaning Tools ----------");
                Console.WriteLine(PV.cleaningTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '6')
            {
                Console.WriteLine("---------- Painting Tools ----------");
                Console.WriteLine(PV.paintingTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
            if (cat == '7')
            {
                Console.WriteLine("---------- Electronic Tools ----------");
                Console.WriteLine(PV.electronicTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '8')
            {
                Console.WriteLine("---------- Electricity Tools ----------");
                Console.WriteLine(PV.electricityTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-5, or 0 to return to previous menu");
            }
            if (cat == '9')
            {
                Console.WriteLine("---------- Automotive Tools ----------");
                Console.WriteLine(PV.automotiveTools);
                Console.WriteLine();
                Console.WriteLine("Select a type of tool 1-6, or 0 to return to previous menu");
            }
        }

        static void Main(string[] args)
        {
            /// Starts the program by passing the user the first welcome menu.
            WelcomeMenu();
        }
    }
}