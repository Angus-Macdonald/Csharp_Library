using System;
using Interfaces;

namespace MemberToolLibrary
{
    public class ToolCollection : iToolCollection
    {
        public int Number => throw new NotImplementedException();

        public Tool[] gardeningTool = new Tool[5];
        public Tool[] flooringTool = new Tool[6];
        public Tool[] fencingTool = new Tool[5];
        public Tool[] measuringTool = new Tool[6];
        public Tool[] cleaningTool = new Tool[6];
        public Tool[] paintingTool = new Tool[6];
        public Tool[] electronicTool = new Tool[5];
        public Tool[] electricityTool = new Tool[5];
        public Tool[] automotiveTool = new Tool[6];

        public void add(Tool aTool)
        {
            throw new NotImplementedException();
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
