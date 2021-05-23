using System;
namespace MemberToolLibrary
{
    /// <summary>
    /// This class is used as a contructor to hold the input values of category and type choices made
    /// by a user. This is developed so the object can be called within any function within the main
    /// program, and the information can be stored within an instance of the entire system starting.
    /// Ultimately this class could just be altered to 2 variables within the Program class in the
    /// Program.cs, but for ease of use and protection of choices, I opted creating this object.
    /// </summary>
    public class Index
    {
        /// A private variable to store the category choice of a user.
        private int cat;
        /// A private variable to store the type choice of a user.
        private int type;
        /// A getter and setter for the cat variable.
        public int CAT { get => cat; set => cat = value; }
        /// A getter and setter for the type variable.
        public int TYPE { get => type; set => type = value; }

        /// A fuction that changes the category and type choices to invalid values, thus the "clear"
        /// method just ensures that once the users choices have been made, they are cleared and further
        /// choices aren't mistake.
        public void clear()
        {
            CAT = -1;
            TYPE = -1;
        }
    }
}
