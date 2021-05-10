using System;
using System.Collections;
using System.Linq;
using Interfaces;

namespace MemberToolLibrary
{
    public class ToolCollection : iToolCollection
    {
        public Tool[] tool = new Tool[0];
        public int numTools;
        public int Number => numTools;
       
        public void add(Tool aTool)
        {
            Array.Resize(ref tool, numTools + 1);
            tool[numTools] = aTool;
            tool[numTools].COLLECTIONINDEX = numTools;
            numTools += 1;
            tool = tool.OrderBy(x => x.INDEX).ToArray();
        }

        public void delete(Tool aTool)
        {
            int index = aTool.COLLECTIONINDEX;
            tool = tool.OrderBy(x => x.COLLECTIONINDEX).ToArray();
            tool[index] = new Tool("null", 0, 0, 0);
            tool[index].COLLECTIONINDEX = numTools;
            tool = tool.OrderBy(x => x.COLLECTIONINDEX).ToArray();
            Array.Resize(ref tool, numTools - 1);
            for(int i = 0; i < tool.Length; i++)
            {
                tool[i].COLLECTIONINDEX = i;
            }
            numTools -= 1;
            
        }

        public bool search(Tool aTool)
        {
            if(Array.Exists(tool, x => x.Name == aTool.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tool[] toArray()
        {
            return tool;
        }
    }
}
