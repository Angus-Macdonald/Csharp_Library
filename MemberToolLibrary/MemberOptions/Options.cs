using System;
namespace MemberToolLibrary.MemberOptions
{
    public class Options
    {
        public static Index choices = new Index();

        public static void DisplayTools()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.categories);
            Console.WriteLine("");
            Console.WriteLine("Select a category of tool 1-9, or 0 to return to previous menu");
            char i = Console.ReadKey().KeyChar;
            choices.CAT = i;
            if(i == '1'){
                DisplayGardening();
            }
        }

        public static void DisplayGardening()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.gardeningTools);
            Console.WriteLine("");
            Console.WriteLine("Select a type tool 1-5, or 0 to return to previous menu.");
            char i = Console.ReadKey().KeyChar;
            choices.TYPE = i;
            if(i == '1')
            {
              
            }

        }  
    }
}
