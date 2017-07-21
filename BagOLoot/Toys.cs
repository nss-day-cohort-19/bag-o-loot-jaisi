using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Toys
    {
        public int ToyID;
        public string ToyName;
        public int ChildID;
        public Toys(int toyid,string toyname, int childid)
        {
            ToyID = toyid;
            ToyName = toyname;
            ChildID = childid;

        }
    }
}