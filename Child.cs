using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Child
    {
        public int ChildID ;
        public string ChildName;
        public bool Deliverd;

        public Child(int childid, string childname, bool delivered)
        {
            ChildID = childid;
            ChildName = childname;
            Deliverd = delivered;
        }
    }
}