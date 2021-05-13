using System;
using System.Collections.Generic;

namespace MemberToolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Member angus = new Member("Angus", "A", "0417675508", "0000");
            Member diquan = new Member("Diquan", "J", "0417675507", "0000");
            Member liam = new Member("Liam", "T", "0417675507", "0000");
            Member bryce = new Member("Bryce", "J", "0417675507", "0000");
            Member andrew = new Member("Andrew", "Z", "0417675507", "0000");
            Tool a = new Tool("Sander", 0, 0, 0);

            MemberCollection members = new MemberCollection();

            members.add(angus);
            members.add(diquan);
            members.add(liam);
            members.add(bryce);
            members.add(andrew);

            members.addToolToMember(bryce, a);
            string[] bryceTools = members.returnTools(bryce);
            for(int i = 0; i < bryceTools.Length; i++)
            {
                Console.WriteLine(bryceTools[i]);
            }
            Console.ReadKey();

        }
    }
}