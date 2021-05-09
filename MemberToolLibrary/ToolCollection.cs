using System;
using Interfaces;

namespace MemberToolLibrary
{
    public class ToolCollection : iToolCollection
    {
        public int num = 0;
        public Tool[] tools = new Tool[0];

        public int Number => throw new NotImplementedException();

        public void add(Tool aTool)
        {
            num += 1;
            tools = new Tool[num];
            tools[num] = aTool;
        }

        public void delete(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public bool search(Tool aTool)
        {
            throw new NotImplementedException();
        }

        public Tool[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
