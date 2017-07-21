using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Child
    {
        public int ChildID ;
        public string ChildName;
        public int Delivered;

        public Child(int childid, string childname, int delivered)
        {
            ChildID = childid;
            ChildName = childname;
            Delivered = delivered;
        }
    }
}