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

        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int AvailableQuantity { get => availablequantity; set => availablequantity = value; }
        public int NoBorrowings { get => noborrowings; set => noborrowings = value; }

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
            MembersBorrowing.add(aMember);
        }

        public void deleteBorrower(Member aMember)
        {
            MembersBorrowing.add(aMember);
        }
    }
}
