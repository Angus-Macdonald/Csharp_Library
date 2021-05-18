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

        public ToolCollection Tools { get => tools; set => tools = value; }
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
            for (int q = 0; q < quantity; q++)
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
                    try
                    {
                        aMember.addTool(aTool);
                        aTool.addBorrower(aMember);
                    }
                    catch(InvalidOperationException) { throw; }
                }
                else { throw new InvalidOperationException("This tool is not in the system."); }
            }
            else { throw new InvalidOperationException("Member does not exist."); }
        }

        public void delete(Tool aTool)
        {
            try
            {
                tools.delete(aTool);
            }
            catch (InvalidOperationException) { throw; }

        }

        public void delete(Tool aTool, int quantity)
        {
            if (aTool.AvailableQuantity < quantity)
            {
                Console.WriteLine("There is a quantity of this tool currently borrowed.\n" +
                   "Please wait for the members to return the items, or remove a lesser amount.");
            }
            else
            {
                for (int q = 0; q < quantity; q++)
                {
                    try
                    {
                        tools.delete(aTool);
                    }
                    catch (InvalidOperationException) { throw; }
                }
            }
        }

        public void delete(Member aMember)
        {
            members.delete(aMember);
        }

        public void displayBorrowingTools(Member aMember)
        {
            string[] memberTools = aMember.Tools;

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
            Member[] tempArray = members.toArray();
            Member contact = tempArray.First(x => (x.LastName, x.FirstName) == (aMember.LastName, aMember.FirstName));
            return contact.ContactNumber;
        }

        public void displayTopTHree()
        {
            Tool[] toolSorted = tools.toArray();
            int max = 0;
            for (int i = 0; i < toolSorted.Length; i++)
            {
                Tool temp;
                if (toolSorted[i].NoBorrowings >= max)
                {
                    temp = toolSorted[i];
                    max = toolSorted[i].NoBorrowings;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        toolSorted[j + 1] = toolSorted[j];
                    }
                    toolSorted[0] = temp;
                }

            }
            Console.WriteLine();

            int printMax = 3;

            if (toolSorted.Length < printMax)
            {
                printMax = toolSorted.Length;
            }

            for (int k = 0; k < printMax; k++)
            {
                Console.WriteLine("Name: " + toolSorted[k].Name + "No.Borrowings: " + toolSorted[k].NoBorrowings);
            }
        }

        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            if (members.search(aMember))
            {
                if (tools.search(aTool))
                {

                    try
                    {
                        aTool.deleteBorrower(aMember);
                        aMember.deleteTool(aTool);
                    }
                    catch (InvalidOperationException) { throw; }

                }
                else
                {
                    throw new InvalidOperationException("This tool does not exist.");
                }

            }
            else { throw new InvalidOperationException("This member does not exist"); }
        }


    }
}