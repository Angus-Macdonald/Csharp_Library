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
1. Display all the tools of a tool type
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


        public const string flooringTools = @"
1. Scrapers
2. Floor Lasers
3. Floor Levelling Tools
4. Floor Levelling Materials
5. Floor Hand Tools
6. Tiling Tools";

        public const string fencingTools = @"
1. Hand Tools
2. Electric Fencing
3. Steel Fencing Tools
4. Power Tools
5. Fencing Accessories";

        public const string measuringTools = @"
1. Distance Tools
2. Laser Measurer
3. Measuring Jugs
4. Temperature & Humidity Tools
5. Levelling Tools
6. Markers
";
        public const string cleaningTools = @"
1. Draining
2. Car Cleaning
3. Vacuum
4. Pressure Cleaners
5. Pool Cleaning
6. Floor Cleaning
";
        public const string paintingTools = @"
1. Sanding Tools
2. Brushes
3. Rollers
4. Paint Removal Tools
5. Paint Scrapers
6. Sprayers
";
        public const string electronicTools = @"
1. Voltage Tester
2. Oscilloscopes
3. Thermal Imaging
4. Data Test Tool
5. Insulation Testers
";

        public const string electricityTools = @"
1. Test Equipment
2. Safety Equipment
3. Basic Hand Tools
4. Circiut Protection
5. Cable Tools
";
        public const string automotiveTools = @"
1. Jacks
2. Air Compressors
3. Battery Chargers
4. Socket Tools
5. Braking
6. Drivetrain
";
    }
}
