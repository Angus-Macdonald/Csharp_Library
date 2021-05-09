using System;
using System.Collections.Generic;

namespace MemberToolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu.WelcomeMenu();
            MemberCollection members = new MemberCollection();
            Member angus = new Member("Angus", "Macdonald", "0417675508", "PIN");
            members.add(angus);

            Tool a = new Tool("A", 5, 3, 2);
            Tool b = new Tool("B", 5, 3, 2);
            Tool c = new Tool("C", 5, 3, 2);
            Tool d = new Tool("D", 5, 3, 2);

            angus.addTool(a);
            angus.addTool(b);
            angus.addTool(c);
            angus.addTool(d);

            for(int i = 0; i < angus.Tools.Length; i++)
            {
                Console.WriteLine(angus.Tools[i]);
            }

        }
    }
}