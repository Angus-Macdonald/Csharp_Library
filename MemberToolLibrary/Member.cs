using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace MemberToolLibrary
{
    public class Member : iMember
    {
        private string firstName;
        private string lastName;
        private string mobile;
        private string pin;
        private string[] tools = new string[3];
        public int numBorrowed = 0;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string ContactNumber { get => mobile; set => mobile = value; }
        public string PIN { get => pin; set => pin = value; }

        public string[] Tools => tools;

        public Member(string first, string last, string mob, string pin)
        {
            FirstName = first;
            LastName = last;
            ContactNumber = mob;
            PIN = pin;
        }


        public void addTool(Tool aTool)
        {
            if (numBorrowed == 3)
            {
                Console.WriteLine("You have reached your borrowing capacity."); 
            }
            else
            {
                tools[numBorrowed] = aTool.Name;
                numBorrowed += 1;
            }
        }

        public void deleteTool(Tool aTool)
        {
            if(numBorrowed == 0)
            {
                Console.WriteLine("You have not borrowed any tools.");
                return;
            }

            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == aTool.Name)
                {
                    tools[i] = null;
                    numBorrowed -= 1;
                    Array.Sort(tools);
                    break;
                }

                if(i == tools.Length - 1)
                {
                   Console.WriteLine("You have not borrowed that tool.");
                }
            }
            
        }
    }
}
