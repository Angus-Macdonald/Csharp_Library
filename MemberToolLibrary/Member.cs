using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace MemberToolLibrary
{
    /// <summary>
    /// This class contains the information of a Member and inherits it's values from the
    /// iMember.cs interface . This information is entered during the creation of an instance
    /// of this member, including the members first name, last name, contact number and log-in password.
    /// This object will also hold the names of tools the member is currently holding.
    /// The member object also holds functionality to add a tool and remove a tool
    /// from the stored borrowed tools, with the input of a Tool object.
    /// </summary>
    public class Member : iMember
    {
        /// A private variable to store the first name of a member.
        private string firstName;
        /// A private variable to store the last name of a member.
        private string lastName;
        /// A private variable to store the contact number of a member.
        private string mobile;
        /// A private variable to store the password of a member.
        private string pin;
        /// A private variable that stores an array of strings reffering to the names of tools a member has borrowed.
        private string[] tools = new string[3];
        /// A private variable that stores the amount of tools that the member is borrowing.
        private int numBorrowed = 0;

        /// A function that returns the first name of the member, or sets the value of a first name.
        public string FirstName { get => firstName; set => firstName = value; }
        /// A function that returns the last name of the member, or sets the value of a last name.
        public string LastName { get => lastName; set => lastName = value; }
        /// A function that returns the contact number of the member, or sets the value of a contact number.
        public string ContactNumber { get => mobile; set => mobile = value; }
        /// A function that returns the password of the member, or sets the value of a password.
        public string PIN { get => pin; set => pin = value; }
        /// A function that returns an array of strings that contains the names of tools the member is borrowing.
        public string[] Tools => tools;

        /// <summary>
        /// A constructor object for the Member class.
        /// </summary>
        /// <param name="first"> The first name of a member. </param>
        /// <param name="last"> The last name of a member. </param>
        /// <param name="mob"> The contact number of a member. </param>
        /// <param name="pin"> The password of a member. </param>
        public Member(string first, string last, string mob, string pin)
        {
            FirstName = first;
            LastName = last;
            ContactNumber = mob;
            PIN = pin;
        }

        /// <summary>
        /// This function takes a tool type object. Is the member is already borrowing
        /// 3 tools, it will return an error that the user is at their limited borrowing capacity.
        /// Otherwise, the function adds the name of the tool to the last position within the
        /// tool[] string array.
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        public void addTool(Tool aTool)
        {
            /// If the number of tools currently borrowed by user is 3
            if (numBorrowed == 3)
            {
                /// Returns an error that the user is at their maximum borrowing capacity.
                throw new InvalidOperationException("Users are limited to borrowing a maximum of three tools.");
            }
            /// If the user is borrowing a value that is not 3 (less than 3).
            else
            {
                /// Insert the name of the param Tool into the last free position of the array.
                tools[numBorrowed] = aTool.Name;
                /// Increase the number of tools borrowed.
                numBorrowed += 1;
            }
        }

        /// <summary>
        /// This function takes a Tool type object and removes the name of the
        /// tool from the borrowed tools. If the number of tools borrowed is 0,
        /// then the system returns an error that the member has not borrowed any tools.
        /// Otherwise, the function finds the name of the param tool within the array,
        /// then moves the name after it, into the position (overriding the name). It
        /// loops this through the rest of the array until all names have been moved.
        /// It then states the last value as null, updates the number of tools borrowed,
        /// then breaks out of the searching loops. If the loop does not find the tool,
        /// it returns and error that the user has not borrowed that tool.
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        public void deleteTool(Tool aTool)
        {
            /// Is the user has borrowed no tools.
            if(numBorrowed == 0)
            {
                /// Returns an error that the member has borrowed no tools.
                throw new InvalidOperationException("You have not borrowed any tools.");
            }

            /// Loops through the array of Tool names.
            for (int i = 0; i < tools.Length; i++)
            {
                /// If the current tool name is the same as the delete tool.
                if (tools[i] == aTool.Name)
                {
                    /// Move all the tool names ahead of it over the one before.
                    for(int j = i; j < tools.Length - 1; j++)
                    {
                        tools[j] = tools[j + 1];
                    }
                    /// Assign the last tool name to null.
                    tools[tools.Length -1 ] = null;
                    /// Update the number of tools borrowed.
                    numBorrowed -= 1;
                    /// Break out of the initial search loop.
                    break;
                }

                /// If the loops reaches the last position, and it is not the removed tool.
                if(i == tools.Length - 1)
                {
                    /// Return an error that the member has not borrowed that tool.
                    throw new InvalidOperationException("You have not borrowed that tool.");
                }
            }
            
        }
    }
}
