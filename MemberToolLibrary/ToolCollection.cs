using System;
using System.Collections;
using System.Linq;
using Interfaces;

namespace MemberToolLibrary
{
    public class ToolCollection : iToolCollection
    {
        private Tool[] tool = new Tool[0];
        private int numTools = 0;
        public int Number => numTools;

        public Tool[] Tools { get => tool; set => tool = value;}

        public void add(Tool aTool)
        {
            int index = IndexOf(tool, aTool);
            if (index != (-1))
            {
                tool[index].Quantity += 1;
                tool[index].AvailableQuantity += 1;
            }
            else
            {
                Array.Resize(ref tool, numTools + 1);
                tool[numTools] = aTool;
                numTools += 1;
            }
        }

        public void delete(Tool aTool)
        {
            int index = IndexOf(tool, aTool);
            if (tool[index].AvailableQuantity == 0)
            {
                throw new InvalidOperationException("There is a quantity of this tool currently borrowed.\n" +
                    "Please wait for the member to return the item, or remove a lesser amount.");

            }
            else
            {
                if (tool[index].Quantity - 1 == 0)
                {
                    for (int i = index; i < tool.Length - 1; i++)
                    {
                        tool[i] = tool[i + 1];
                    }
                    numTools -= 1;
                    Array.Resize(ref tool, numTools);
                    throw new InvalidOperationException("The tool has been removed from the system.");
                }
                else
                {
                    tool[index].AvailableQuantity -= 1;
                    tool[index].Quantity -= 1;
                }
            }

        }

        public bool search(Tool aTool)
        {
            if (Array.Exists(tool, x => x.Name == aTool.Name))
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

        private int IndexOf(Tool[] toolCollection, Tool aTool)
        {
            for (int i = 0; i < toolCollection.Length; i++)
            {
                if (toolCollection[i].Name == aTool.Name)
                {
                    return i;
                }
                else
                {
                    continue;
                }

            }

            return -1;
        }
    }
}
