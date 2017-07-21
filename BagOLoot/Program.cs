using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.Check();
            db.CheckBag();
            MenuBuilder mymenu = new MenuBuilder();
            ChildRegister registry = new ChildRegister();
            int choice = mymenu.ShowMainMenu();
            List<Child> mylist = new List<Child>();
            mylist = registry.GetChildren();
            SantaHelper myhelper = new SantaHelper();
            Actions myactions = new Actions();
                switch (choice)
                {
                        // Menu option 1: Register a child
                        case 1:
                            myactions.Register();
                            break;

                        // Menu option 2: Assign toy to child
                        case 2:
                            myactions.AssignToy();
                            break;
                        
                        //Revoke toy from child
                        case 3:
                            myactions.RemoveToy();
                            break;
                        
                        //Review child's toy list
                        case 4:
                            myactions.ReviewToyListOfChild();
                            break;

                        //Child toy delivery complete
                        case 5:
                            myactions.DeliveryComplete();
                            break;
                        
                        //Yuletide delivery report
                        case 6:
                            myactions.YuletimeDeliveryReport();
                            break;
                        case 7:
                            break;
                }
               

            
        }
    }
}
