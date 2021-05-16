using System;
namespace MemberToolLibrary
{
    public class Index
    {
        private int cat;
        private int type;
        public int CAT { get => cat; set => cat = value; }
        public int TYPE { get => type; set => type = value; }

        public void clear()
        {
            CAT = -1;
            TYPE = -1;
        }
    }
}
