using System;
using System.Collections;
using System.Linq;
using Interfaces;

namespace MemberToolLibrary
{
    /// <summary>
    /// A class that stores an array of Tool type objects. The class has the ability to
    /// add a tool to the collection, delete a tool from the collection, search if a
    /// tool exists within the collection, and turn the Collection into an array.
    /// The class stores the number of tools it contains, and contains a private function
    /// to find the index of a Tool within the colleciton.
    /// </summary>
    public class ToolCollection : iToolCollection
    {
        /// A private variable that stores an array of Tool type objects.
        private Tool[] tool = new Tool[0];
        /// A private variable that stores the number of Tools within the collection.
        private int numTools = 0;
        /// A public function that returns the number of Tools within the collection.
        public int Number => numTools;

        /// <summary>
        /// This function adds a Tool type object to the collection, or if it already exists
        /// it will add more pieces to the existing tool.
        /// 
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        /// <pre-condition> The tool collection may or may not contain a Tool. </pre-condition>
        /// <post-condition> The tool collection now contains the Tool, or additional pieces of a Tool. </post-condition>
        public void add(Tool aTool)
        {
            /// Uses the private function to find the index of a Tool in the collection.
            int index = IndexOf(tool, aTool);
            /// If the function returns a value that indicates the tool already exists.
            if (index != (-1))
            {
                /// Increase the quantity of tool by 1.
                tool[index].Quantity += 1;
                /// Increase the available quantity by 1.
                tool[index].AvailableQuantity += 1;
            }
            /// If the private function does not find the tool.
            else
            {
                /// Resizes the array to a size greater than the current by 1.
                Array.Resize(ref tool, numTools + 1);
                /// Places the param tool into the last position of the collection.
                tool[numTools] = aTool;
                /// Increases the number of tools in the system by 1.
                numTools += 1;
            }
        }

        /// <summary>
        /// This function removes a Tool type object in the collection, if available quantity
        /// is 0, returns an error that the tool is currently borrowed. If the removing 1 from the
        /// total quantity, it will remove the entire Tool type object from the collection, otherwise
        /// it will remove 1 from the available quantity and total quantity.
        ///
        /// This function has been developed that if the user wants to remove the a certain quantity of a tool from the system,
        /// it will update the values stored within. If you call this function that would remove the total quantity to 0,
        /// it removes the tool from the system completely.
        /// 
        /// </summary>
        /// <param name="aTool"> A Tool type object. </param>
        /// <pre-condition> The tool collection contains a Tool. </pre-condition>
        /// <post-condition> The tool collection has removed the Tool, or 1 quantity of the Tool. </post-condition>
        public void delete(Tool aTool)
        {
            /// Private function that finds the index of a tool.
            int index = IndexOf(tool, aTool);

            /// If the tool does not exist within the collection
            if (index == -1)
            {
                /// Returns an error that the tool does not exist.
                throw new InvalidOperationException("This tool does not exist.");
            }

            /// If the available quantity equal 0
            if (tool[index].AvailableQuantity == 0)
            {
                /// Returns an error that the quantity is currently being borrowed by a member.
                throw new InvalidOperationException("There is a quantity of this tool currently borrowed.\n" +
                    "Please wait for the member to return the item, or remove a lesser amount.");

            }
            /// If the tool exists, and does have an available quantity.
            else
            {
                /// If the quantity -1 would equal 0
                if (tool[index].Quantity - 1 == 0)
                {
                    /// Moves all the tools after the found tool into the position before it.
                    for (int i = index; i < tool.Length - 1; i++)
                    {
                        tool[i] = tool[i + 1];
                    }
                    /// Updates the number of tools within the collection.
                    numTools -= 1;
                    /// Resizes the array to the correct number of tools.
                    Array.Resize(ref tool, numTools);
                    /// Returns an 'error' that the tool has been removed from the system.
                    throw new InvalidOperationException("The tool has been removed from the system.");
                }
                /// If removing 1 from the quantity doesn't equal 0.
                else
                {
                    /// Updates the quantities of the tool within the system.
                    tool[index].AvailableQuantity -= 1;
                    tool[index].Quantity -= 1;
                }
            }

        }

        /// <summary>
        /// This function searches for a Tool type object within the system,
        /// if it exists, will return true, otherwise false.
        /// </summary>
        /// <param name="aTool"> A Tool Type object. </param>
        /// <pre-condition> A tool collection contains a Tool. </pre-condition>
        /// <post-condition> A Tool object is found by its name. </post-condition>
        /// <returns > A Boolean Value: True/False </returns>
        public bool search(Tool aTool)
        {
            /// Using Microsoft functionality, searches the tool collection if the name of an object is the same as the searched tool
            if (Array.Exists(tool, x => x.Name == aTool.Name))
            {
                /// Returns true, runs in O(n) time.
                return true;
            }
            /// If the tool name is not found
            else
            {
                /// Returns false
                return false;
            }
        }

        /// <summary>
        /// This function returns an array of Tool type objects.
        /// </summary>
        /// <returns> The tool collection. </returns>
        public Tool[] toArray()
        {
            /// Returns the tool[] tool.
            return tool;
        }

        /// <summary>
        /// This function returns and index of a Tool object within a Tool[].
        /// </summary>
        /// <param name="toolCollection"> An array of Tool objects</param>
        /// <param name="aTool"> A tool object to find the index. </param>
        /// <returns></returns>
        private int IndexOf(Tool[] toolCollection, Tool aTool)
        {
            /// Iterates throughout the tool[]
            for (int i = 0; i < toolCollection.Length; i++)
            {
                /// If the name of a current tool is equal to the searched tool name.
                if (toolCollection[i].Name == aTool.Name)
                {
                    /// Returns the number of iterations to find it
                    return i;
                }
                /// If the tool name isn't matching, continues the iterations.
                else
                {
                    continue;
                }
            }
            /// If the search completes the array and hasn't returned an index (Tool isn't found).
            /// It returns -1.
            return -1;
        }
    }
}
