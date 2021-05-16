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
        public MemberCollection GetBorrowers => MembersBorrowing;

        public Tool(string n, int quant, int available, int noborrow)
        {
            Name = n;
            Quantity = quant;
            AvailableQuantity = available;
            NoBorrowings = noborrow;
        }
       
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
