using System;
using Interfaces;

namespace MemberToolLibrary
{
    public class Tool : iTool
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AvailableQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NoBorrowings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MemberCollection GetBorrowers => throw new NotImplementedException();


        public Tool(string name, int quantity, int available, int noborrowings)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.AvailableQuantity = available;
            this.NoBorrowings = noborrowings;
        }

        public void addBorrower(Member aMember)
        {
            throw new NotImplementedException();
        }

        public void deleteBorrower(Member aMember)
        {
            throw new NotImplementedException();
        }
    }
}
