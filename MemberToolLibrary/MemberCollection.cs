using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace MemberToolLibrary
{
    public class MemberCollection : Interfaces.iMemberCollection
    {

        public int Number => throw new NotImplementedException();

        public void add(Member aMember) => throw new NotImplementedException();

        public void delete(Member aMember)
        {
            throw new NotImplementedException();
        }

        public bool search(Member aMember)
        {
            throw new NotImplementedException();
        }

        public Member[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
