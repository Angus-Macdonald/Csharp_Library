using System;
using System.Collections.Generic;

namespace MemberToolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Member angus = new Member("Angus", "Macdonald", "0417675508", "0000");
            Member diquan = new Member("Diquan", "Jabbour", "0417675507", "0000");
            Member liam = new Member("Liam", "McDonnell", "0417675507", "0000");
            Member bryce = new Member("Bryce", "Halloran", "0417675507", "0000");
            Member andrew = new Member("Andrew", "Sagorski", "0417675507", "0000");

            MemberCollection members = new MemberCollection();

            members.add(angus);
            members.add(diquan);
            members.delete(angus);
            members.add(liam);
            members.add(bryce);
            members.add(andrew);

            members.InOrderTraverse();


        }
    }
}