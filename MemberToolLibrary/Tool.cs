using System;
using System.Collections.Generic;
using Interfaces;

namespace MemberToolLibrary
{
    public class Tool : iTool
    {
        private string name;
        private int quantity;
        private int availablequantity;
        private int noborrowings;

        private int index;
        private int collectionindex;

     
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int AvailableQuantity { get => availablequantity; set => availablequantity = value; }
        public int NoBorrowings { get => noborrowings; set => noborrowings = value; }

        public int INDEX { get => index; set => index = value; }
        public int COLLECTIONINDEX { get => collectionindex; set => collectionindex = value; }
        public MemberCollection MembersBorrowing = new MemberCollection();

        public Tool(string n, int quant, int available, int noborrow)
        {
            Name = n;
            Quantity = quant;
            AvailableQuantity = available;
            NoBorrowings = noborrow;
        }

        public MemberCollection GetBorrowers => MembersBorrowing;

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
                Console.WriteLine("We are sorry "+ aMember.FirstName + " our supply of " + name + " is fully booked.");
            }
        }

        public void deleteBorrower(Member aMember)
        {
            MembersBorrowing.delete(aMember);
        }
    }
}
