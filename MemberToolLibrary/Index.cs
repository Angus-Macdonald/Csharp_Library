using System;
namespace MemberToolLibrary
{
    public class Index
    {
        private int function;
        private int cat;
        private int type;

        public int CAT { get => cat; set => cat = value; }
        public int TYPE { get => type; set => type = value; }
        public int FUNCTION { get => function; set => function = value; }

        public void clear()
        {
            CAT = -1;
            TYPE = -1;
            FUNCTION = 0;
        }
    }
}
