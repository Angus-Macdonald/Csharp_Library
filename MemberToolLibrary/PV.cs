using System;
namespace MemberToolLibrary
{
    public static class PV
    {
        public const string header = "   Welcome to the Library Tool Rental System  ";
        public const string spacer = "###############################################";
        private const string staffUsername = "staff";
        private const string staffPassword = "today123";

        public static string Staff()
        {
            return staffUsername;
        }

        public static string Pass()
        {
            return staffPassword;
        }

        public const string categories = @"
1. Gardening Tools
2. Flooring Tools
3. Fencing Tools
4. Measuring Tools
5. Cleaning Tools
6. Painting Tools
7. Electronic Tools
8. Electricity Tools
9. Automotive Tools";

        public const string staffOptions = @"
1. Add a new tool
2. Add new pieces of an existing tool
3. Remove some pieces of a tool
4. Register a new member
5. Remove a member
6. Find the contact number of a member
0. Return to Main Menu";


        public const string memberOptions = @"
1.Display all the tools of a tool type
2. Borrow a tool
3. Return a tool
4. List all the tools that I am renting
5. Display the top three(3) most frequently rented tools
0. Return to Main Menu";


        public const string gardeningTools = @"
1. Line Trimmers
2. Lawn Mowers
3. Hand Tools
4. Wheelbarrows
5. Garden Power Tools";
    }

}
