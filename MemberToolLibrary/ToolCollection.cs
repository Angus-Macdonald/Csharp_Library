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
                int index = Array.IndexOf(tool, aTool);
                tool[index].Quantity += 1;
                tool[index].AvailableQuantity += 1;
            }

            else
            {

                Array.Resize(ref tool, numTools + 1);
                tool[numTools] = aTool;
                tool[numTools].Quantity += 1;
                tool[numTools].AvailableQuantity += 1;
                numTools += 1;

            }
        }

        public void delete(Tool aTool)
        {
            if (Array.Exists(tool, x => x.Name == aTool.Name))
            {
                int index = Array.IndexOf(tool, aTool);

                if(tool[index].Quantity - 1 == 0)
                {
                    for (int i = index; i < tool.Length - 1; i++)
                    {
                        tool[i] = tool[i + 1];
                    }
                    numTools -= 1;
                    Array.Resize(ref tool, numTools);
                }

                else
                {
                    if(tool[index].AvailableQuantity == 0)
                    {
                        Console.WriteLine("The quantity of this tool has been fully booked.");
                        Console.WriteLine("Please wait for one to be returned before removing it from the system.");
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
