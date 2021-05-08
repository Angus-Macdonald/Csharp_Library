using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace MemberToolLibrary
{
    public class Member : iMember
    {

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string[] Tools => throw new NotImplementedException();

        public Member(string first, string last, string number, string pin)
        {
            this.FirstName = first;
            this.LastName = last;
            this.ContactNumber = number;
            this.PIN = pin;
        }
       

        public void addTool(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public void deleteTool(Tool aTool)
        {
            throw new NotImplementedException();
        }
    }
}
