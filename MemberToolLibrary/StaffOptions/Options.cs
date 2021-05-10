using System;
namespace MemberToolLibrary.StaffOptions
{
    public class Options
    {
        public Index choices = new Index();

        public void AddTool()
        {
            Console.Clear();
            Console.SetWindowSize(47, 20);
            Console.WriteLine("");
            Console.WriteLine(PV.categories);
            Console.WriteLine("");
            Console.WriteLine("Select a category of tool 1-9, or 0 to return to previous menu");
            char input = Console.ReadKey(true).KeyChar;
            choices.CAT = input;


        }
    }
}
