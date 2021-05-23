﻿using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;


namespace MemberToolLibrary
{
    /// <summary>
    /// A class that holds a ToolCollection and MemberCollection of all tools and members in the system.
    /// This class allows ease of use between the two collections within 1 central object to create for the
    /// main system.
    /// </summary>
    public class ToolLibrarySystem : iToolLibrarySystem
    {
        /// A private variable to store all tools within the library system.
        private ToolCollection tools = new ToolCollection();
        /// A private variable to store all the members within the library system.
        private MemberCollection members = new MemberCollection();
        /// A function that returns a ToolCollection of the current tools within the library.
        public ToolCollection Tools { get => tools; set => tools = value; }
        /// A function that returns a MemberCollection of the current members within the library.
        public MemberCollection Members { get => members; set => members = value; }

        /// A constructor object that takes a ToolCollection and MemberCollection 
        public ToolLibrarySystem(ToolCollection tool, MemberCollection member)
        {
            this.Tools = tool;
            this.Members = member;
        }

        /// <summary>
        /// Adds a Tool object to the system
        /// </summary>
        /// <param name="aTool"> A tool type object. </param>
        public void add(Tool aTool)
        {
            tools.add(aTool);

        }

        /// <summary>
        /// Adds more pieces of an existing Tool to the system.
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        /// <param name="quantity"> An amount of which to add quantity to the aTool. </param>
        public void add(Tool aTool, int quantity)
        {
            /// The tools.add function adds quantity to a pre-existing tool, doing the function
            /// in the quantity amount will add that many to the system.
            for (int q = 0; q < quantity; q++)
            {
                tools.add(aTool);
            }
        }


        /// <summary>
        /// This function adds a Member type object ot the member collection.
        /// </summary>
        /// <param name="aMember"> A Member type object. </param>
        public void add(Member aMember)
        {
            members.add(aMember);
        }


        /// <summary>
        /// This function updates a member and a tool by adding both to each other.
        /// </summary>
        /// <param name="aMember"> The borrowing member. </param>
        /// <param name="aTool"> The tool in which is borrowed. </param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            /// Checks the member exists within the system.
            if (members.search(aMember))
            {
                /// Checks the tool exists within the system.
                if (tools.search(aTool))
                {
                    /// If the tool isn't already being borrowed by the current member.
                    if (!aTool.GetBorrowers.toArray().Contains<Member>(aMember))
                    {
                        try
                        {
                            /// Adds tool name to the member.
                            aMember.addTool(aTool);
                            /// Adds member to the tool.
                            aTool.addBorrower(aMember);

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    }
                    else
                    {
                        /// Return an error that the member already borrows this tool. 
                        throw new InvalidOperationException("You are already borrowing this tool.");
                    }
                } /// Return an error that the tool is not in the system.
                else { throw new InvalidOperationException("This tool is not in the system."); }
            } /// Return an error that the member does not exist.
            else { throw new InvalidOperationException("Member does not exist."); }
        }

        /// <summary>
        /// Function that removes a tool from the library.
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        public void delete(Tool aTool)
        {
            try
            {
                tools.delete(aTool);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        /// <summary>
        /// Function that removes a quantity of a tool that already exists within the system.
        /// If the entered quantity is larger than the the available quantity, returns an error.
        /// If the removed amount would delete the tool from the system, prints the message.
        /// </summary>
        /// <param name="aTool"> A Tool type object to delete pieces. </param>
        /// <param name="quantity"> The amount to remove. </param>
        public void delete(Tool aTool, int quantity)
        {
            /// If the quantity to remove is larger than the available quantity.
            if (quantity > aTool.AvailableQuantity)
            {
                /// Returns an error that there is not enough available to be removed. 
                throw new InvalidOperationException("There is not enough available to remove from system.\n" +
                   "Please enter a value that is equal or less than available amount.");
            }
            /// If the removal quantity is less than available quantity.
            if (quantity <= aTool.AvailableQuantity)
            {
                /// For the amount of quantity.
                for (int q = 0; q < quantity; q++)
                {
                    try
                    {
                        /// Remove the tool from system
                        tools.delete(aTool);
                    }
                    catch (Exception e)
                    {
                        /// If the the quantity returns down to 0, prints the error message.
                        if (e.Message == "The tool has been removed from the system.")
                        { Console.WriteLine(e.Message); }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a member from the MemberCollection.
        /// </summary>
        /// <param name="aMember"> A Member type object to remove. </param>
        public void delete(Member aMember)
        {
            members.delete(aMember);
        }

        /// <summary>
        /// This function iterates through a members borrowed tools and prints them to console.
        /// </summary>
        /// <param name="aMember"> A Member type object. </param>
        public void displayBorrowingTools(Member aMember)
        {
            /// Gets the members borrowed Tool names
            string[] memberTools = aMember.Tools;

            /// Iterates through the list
            for (int i = 0; i < memberTools.Length; i++)
            {
                /// If the name of the tool is null
                if (memberTools[i] == null)
                {
                    /// Breaks the loop
                    break;

                }
                /// Print the name of the Tool out to console. 
                Console.WriteLine(memberTools[i]);
            }
        }

        public void displayTools(string aToolType)
        {
        }

        /// <summary>
        /// A function that returns the contact number of a member within the system.
        /// </summary>
        /// <param name="aMember"> A Member Type object to search for contact number. </param>
        /// <returns> A string of a users contact number. </returns>
        public string getContact(Member aMember)
        {
            /// Gets the members within the system into an array.
            Member[] tempArray = members.toArray();
            /// Finds the first member that has the same last and first name as the searched member and puts it within a new Member object.
            /// Finds the member in worst case O(n) time. 
            Member contact = tempArray.First(x => (x.LastName, x.FirstName) == (aMember.LastName, aMember.FirstName));
            /// Returns the contact number of the found member.
            return contact.ContactNumber; 
        }


        /// <summary>
        /// A function that prints to console the 3 most borrowed tools within the system. 
        /// </summary>
        public void displayTopTHree()
        {
            /// Gets all the tools in the toolcollection into an array.
            Tool[] toolSorted = tools.toArray();

            Console.WriteLine();

            HeapSort(toolSorted);

            for (int index = toolSorted.Length - 1; index >= toolSorted.Length - 3; index--)
            {
                Console.WriteLine("Name:" + toolSorted[index].Name +  " No. Borrows:" + toolSorted[index].NoBorrowings);
            }
            /// A variable that stores the current maximum of a borrowings.
            //int max = 0;
            ///// Loops through the array of stored tools.
            //for (int i = 0; i < toolSorted.Length; i++)
            //{
            //    /// Creates a temporary tool object.
            //    Tool temp;
            //    /// If the current interatable tool borrowings is equal or larger than the current max borrowings.
            //    if (toolSorted[i].NoBorrowings >= max)
            //    {
            //        /// Store the greater max tool into the temp object
            //        temp = toolSorted[i];
            //        /// Update the current max no borrowings
            //        max = toolSorted[i].NoBorrowings;

            //        /// Iterates backwards throughout the tool array from the max tool, moving the tool before it into its position.
            //        for (int j = i - 1; j >= 0; j--)
            //        {
            //            toolSorted[j + 1] = toolSorted[j];
            //        }
            //        toolSorted[0] = temp;
            //    }
            //}
            //Console.WriteLine();

            //int printMax = 3;

            //if (toolSorted.Length < printMax)
            //{
            //    printMax = toolSorted.Length;
            //}

            //for (int k = 0; k < printMax; k++)
            //{
            //    Console.WriteLine("Name: " + toolSorted[k].Name + "  No.Borrowings: " + toolSorted[k].NoBorrowings);
            //}
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
                    catch (Exception e) { Console.WriteLine(e.Message); }

                }
                else
                {
                    throw new InvalidOperationException("This tool does not exist.");
                }

            }
            else { throw new InvalidOperationException("This member does not exist"); }
        }

        private void HeapBottomUp(Tool[] tools)
        {
            int n = tools.Length;
            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                int k = i;
                Tool v = tools[i];
                bool heap = false;
                while ((!heap) && ((2 * k + 1) <= (n - 1)))
                {
                    int j = 2 * k + 1;  //the left child of k
                    if (j < (n - 1))   //k has two children
                        if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                            j = j + 1;  //j is the larger child of k
                    if (v.NoBorrowings >= tools[j].NoBorrowings)
                        heap = true;
                    else
                    {
                        tools[k] = tools[j];
                        k = j;
                    }
                }
                tools[k] = v;
            }
        }

        private void HeapSort(Tool[] tools)
        {
            //Use the HeapBottomUp procedure to convert the array, data, into a heap
            HeapBottomUp(tools);


            //repeatly remove the maximum key from the heap and then rebuild the heap
            for (int i = 0; i <= tools.Length - 2; i++)
            {
                MaxKeyDelete(tools, tools.Length - i);
            }
        }


        private void MaxKeyDelete(Tool[] tools, int size)
        {
            Tool temp = tools[0];
            tools[0] = tools[size - 1];
            tools[size - 1] = temp;

            int n = size - 1;

            bool heap = false;
            int k = 0;
            Tool v = tools[0];
            while ((!heap) && ((2 * k + 1) <= (n - 1)))
            {
                int j = 2 * k + 1; //the left child of k
                if (j < (n - 1))   //k has two children
                    if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                        j = j + 1;  //j is the larger child of k
                if (v.NoBorrowings >= tools[j].NoBorrowings)
                    heap = true;
                else
                {
                    tools[k] = tools[j];
                    k = j;
                }
            }
            tools[k] = v;
        }


    }
}