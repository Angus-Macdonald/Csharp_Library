using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace MemberToolLibrary
{
    public class MemberCollection : Interfaces.iMemberCollection
    {
        public List<Member> ListOfMembers = new List<Member> { };

        public int Number => ListOfMembers.Count;

        public void add(Member aMember)
        {
            ListOfMembers.Add(aMember);
        }

        public void delete(Member aMember)
        {
            ListOfMembers.Remove(aMember);
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
