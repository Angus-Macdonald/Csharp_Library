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

        public void add(Tool aTool)
        {
            if (Array.Exists(tool, x => x.Name == aTool.Name))
            {
                foreach (Tool t in tool)
                {
                    if (t.Name == aTool.Name)
                    {
                        t.Quantity += 1;
                        t.AvailableQuantity += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
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
            if (Array.Exists(tool, x => x.Name == aTool.Name))
            {
                int index = IndexOf(tool, aTool);
                if (tool[index].AvailableQuantity == 0)
                {
                    throw new InvalidOperationException("The quantity of this tool has been fully booked. \n " +
                        "Please wait for one to be returned before removing it from the system.");

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
                        Console.WriteLine("This tool has been removed from the library.");
                    }
                    else
                    {
                        tool[index].AvailableQuantity -= 1;
                        tool[index].Quantity -= 1;
                    }
                }

            }
            else
            {
                throw new InvalidOperationException("This tool does not exist.");
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

        public int IndexOf(Tool[] toolCollection, Tool aTool)
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

        public Tool getTool(string toolName)
        {
            foreach (Tool heldTool in tool)
            {
                if (heldTool.Name == toolName)
                {
                    Tool returnTool = heldTool;
                    return returnTool;
                }
                else
                {
                    continue;
                }

            }
            throw new InvalidOperationException("Tool not found");
        }

        public void addMemberToTool(Member aMember, Tool aTool)
        {
            int index = IndexOf(tool, aTool);
            tool[index].addBorrower(aMember);
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            int index = IndexOf(tool, aTool);

            tool[index].AvailableQuantity += 1;
            tool[index].MembersBorrowing.delete(aMember);
        }
    }
}
