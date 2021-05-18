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
        private int numBorrowed = 0;

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
                throw new InvalidOperationException("Users are limited to borrowing a maximum of three tools.");
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
                throw new InvalidOperationException("You have not borrowed any tools.");
            }

            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == aTool.Name)
                {
                    for(int j = i; j < tools.Length - 1; j++)
                    {
                        tools[j] = tools[j + 1];
                    }

                    tools[tools.Length -1 ] = null;
                    numBorrowed -= 1;
                    break;
                }

                if(i == tools.Length - 1)
                {
                    throw new InvalidOperationException("You have not borrowed that tool.");
                }
            }
            
        }
    }
}
