using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;


namespace MemberToolLibrary
{
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        private ToolCollection tools = new ToolCollection();
        private MemberCollection members = new MemberCollection();

        public ToolCollection Tools { get => tools; set => tools = value;}
        public MemberCollection Members { get => members; set => members = value; }

        public ToolLibrarySystem(ToolCollection tool, MemberCollection member)
        {
            this.Tools = tool;
            this.Members = member;
        }

        public void add(Tool aTool)
        {
            tools.add(aTool);

        }

        public void add(Tool aTool, int quantity)
        {
            for(int q = 0; q < quantity; q++)
            {
                tools.add(aTool);
            }
        }

        public void add(Member aMember)
        {
            members.add(aMember);
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            if (members.search(aMember))
            {
                if (tools.search(aTool))
                {
                    members.addToolToMember(aMember, aTool);
                    tools.addMemberToTool(aMember, aTool);
                }
            }
        
        }

        public void delete(Tool aTool)
        {
            tools.delete(aTool);
        }

        public void delete(Tool aTool, int quantity)
        {
            if (tools.search(aTool))
            {
                for (int q = 0; q < quantity; q++)
                {
                    tools.delete(aTool);
                }
            }

            else
            {
                Console.WriteLine("This tool does not exist.");
            }
        }

        public void delete(Member aMember)
        {
            members.delete(aMember);
        }

        public void displayBorrowingTools(Member aMember)
        {
            string[] memberTools = members.getMember(aMember).Tools;

            for (int i = 0; i < memberTools.Length; i++)
            {
                if (memberTools[i] == null)
                {
                    break;

                }

                Console.WriteLine(memberTools[i]);
            }
        }

        public void displayTools(string aToolType)
        {
        }

        public string getContact(Member aMember)
        {
            return members.getMember(aMember).ContactNumber;
        }

        public void displayTopTHree()
        {
            throw new NotImplementedException();
        }

        public string[] listTools(Member aMember)
        {
            return members.getMember(aMember).Tools;
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            throw new NotImplementedException();
        }
    }
}
