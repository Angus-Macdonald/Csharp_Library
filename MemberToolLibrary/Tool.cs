using System;
using System.Collections.Generic;
using Interfaces;

namespace MemberToolLibrary
{
    /// <summary>
    /// This class inherits the provided iTool.cs interface provided.
    /// The purpose of this class is to further generate instances of type Tool,
    /// in which we can use the constructor to store the name, quantity,
    /// available quantity and number of time borrowed. This object will also
    /// inherit 2 functions, in which the Tool object is able to store a Member
    /// instance within it, allowing it to add and remove such Member.
    /// </summary>
    public class Tool : iTool
    {
        //A private variable to store the name of the tool.
        private string name;
        //A private variable to store the total quantity of the tool.
        private int quantity;
        //A private variable to store the available quantity of the tool (currently not borrowed).
        private int availablequantity;
        //A private variable to store the number of times this tool has been borrowed.
        private int noborrowings;
        /// A private collections of Member type objects, used to store the members that are borrowing this tool.
        private MemberCollection MembersBorrowing = new MemberCollection();

        /// A get/set function to retrieve or set the private variable "name".
        public string Name { get => name; set => name = value; }
        /// A get/set function to retrieve or set the private variable "quantity".
        public int Quantity { get => quantity; set => quantity = value; }
        /// A get/set function to retrieve or set the private variable "availablequantity".
        public int AvailableQuantity { get => availablequantity; set => availablequantity = value; }
        /// A get/set function to retrieve or set the private variable "noborrowings".
        public int NoBorrowings { get => noborrowings; set => noborrowings = value; }
        /// A function that returns the MemberCollection of current borrowing members.
        public MemberCollection GetBorrowers => MembersBorrowing;

        /// <summary>
        /// Constructor object for the class.
        /// </summary>
        /// <param name="n"> Takes the name of a Tool. </param>
        /// <param name="quant"> Takes the quantity of a Tool. </param>
        /// <param name="available"> Takes the availale number of a time. </param>
        /// <param name="noborrow"> Takes a number of times borrowed. </param>
        public Tool(string n, int quant, int available, int noborrow)
        {
            Name = n;
            Quantity = quant;
            AvailableQuantity = available;
            NoBorrowings = noborrow;
        }


        /// <summary>
        /// This function will take the input Member and add it to the MemberCollection.
        /// If the available quantity is 0, it will throw an error with message detailing
        /// that the tool is at maximum booking capacity.
        /// Otherwise, the function adds the Member to the local MemberCollection object,
        /// then updates the available quantity by -1, and the number of borrowings by +1.
        /// (To update available quantity by -1, to show there is 1 less available piece of this tool.)
        /// </summary>
        /// <param name="aMember"> A Member type object. </param>
        public void addBorrower(Member aMember)
        {
            if (availablequantity != 0)
            {
                MembersBorrowing.add(aMember);
                availablequantity -= 1;
                noborrowings += 1;
            }
            else
            {
                throw new InvalidOperationException("This tool is fully booked.");
            }
        }

        public void deleteBorrower(Member aMember)
        {
            if (MembersBorrowing.search(aMember))
            {
                MembersBorrowing.delete(aMember);
                availablequantity += 1;
            }
            else
            {
                throw new InvalidOperationException("This tool is not being borrowed by member");
            }
        }
    }
}
