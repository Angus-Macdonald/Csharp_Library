using System;
using System.Collections;
using System.Linq;
using Interfaces;

namespace MemberToolLibrary
{
    public class ToolCollection : iToolCollection
    {
        private Tool[] tool = new Tool[0];
        public string[,] catType = new string[9, 6];
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

        public int IndexOf(ToolCollection toolCollection, Tool aTool)
        {
            for (int i = 0; i < toolCollection.Number; i++)
            {
                if(toolCollection.toArray()[i].Name == aTool.Name)
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

        public void delete(Tool aTool)
        {
            if (Array.Exists(tool, x => x.Name == aTool.Name))
            {
                int index = Array.IndexOf(tool, aTool);
                if (tool[index].AvailableQuantity == 0)
                {
                    Console.WriteLine("The quantity of this tool has been fully booked.");
                    Console.WriteLine("Please wait for one to be returned before removing it from the system.");
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
                Console.WriteLine("This tool does not exist.");
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

            return new Tool("null", 0, 0, 0);
        }

        public void addMemberToTool(Member aMember, Tool aTool)
        {
            int index = Array.IndexOf(tool, aTool);

            tool[index].addBorrower(aMember);
        }

        public Tool[] toArray()
        {
            return tool;
        }
    }
}
