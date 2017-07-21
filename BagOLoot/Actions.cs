using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Actions
    {
        public void Register()
        {
            ChildRegister registry = new ChildRegister();
            List<Child> mylist = new List<Child>();
            mylist = registry.GetChildren();
            Console.WriteLine ("Enter child name");
            Console.Write ("> ");
            string childName = Console.ReadLine();
            int childId = registry.AddChild(childName);
            Console.WriteLine(childId);
        }

        public void AssignToy()
        {
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mylist = new List<Child>();
            mylist = registry.GetChildren();
            Console.WriteLine ("Assign toy to which child? Enter child name exactly as it appears on the list");
            int counter = 1;
            foreach(var child in mylist)
            {
                Console.WriteLine(counter + ". " + child.ChildName);
                counter++;

            }
            Console.Write ("> ");
            string assignedchild = Console.ReadLine();
            Console.WriteLine("Enter toy to add to " +  assignedchild + "'s Bag o' Loot");
            Console.Write ("> ");
            string toytobeadded = Console.ReadLine();
            foreach(var child in mylist)
            {
                if (child.ChildName == assignedchild)
                {
                    //int assignedid = child.ChildID;
                    myhelper.AddToyToBag(toytobeadded, child.ChildID); 
                }
            }

        
             
        }

        public void RemoveToy()
        {
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mylist = new List<Child>();
            mylist = registry.GetChildren();
            Console.WriteLine("Remove toy from which child? Enter child name exactly as it appears on the list");
            foreach(var child in mylist)
            {
                Console.WriteLine(child.ChildName);
            }
            Console.Write ("> ");
            string badchild = Console.ReadLine();
            Console.WriteLine("Choose toy to revoke from " + badchild + "'s Bagaloot");
            List<Toys> listoftoys = new List<Toys>();
            foreach(var child in mylist)
            {
                if(child.ChildName == badchild)
                {
                    listoftoys = myhelper.GetChildsToys(child.ChildID);
                }
            }
            int counter = 1;
            foreach(var toy in listoftoys)
            {
                Console.WriteLine(counter + ". " + toy.ToyName);
                counter++;
            }
            Console.WriteLine("> ");
            string toytoremove = Console.ReadLine();
            foreach(var toy in listoftoys)
            {
                if(toy.ToyName == toytoremove)
                {
                    myhelper.RemoveToyFromBag(toy.ToyID);
                }
            }
            
        }

        public void ReviewToyListOfChild()
        {
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mychildlist = new List<Child>();
            List<Toys> mytoylist = new List<Toys>();
            mychildlist = registry.GetChildren();
            Console.WriteLine("View Bag o' Loot for which child? Enter child name exactly as it appears on the list");
            int counter = 1;
            foreach(var child in mychildlist)
            {
                Console.WriteLine(counter + ". " + child.ChildName);
                counter++;
            }
            Console.Write ("> ");
            string goodchild = Console.ReadLine();
            foreach(var child in  mychildlist)
            {
                if(child.ChildName == goodchild)
                {
                    var listoftoys = myhelper.GetChildsToys(child.ChildID);
                    int counter1 = 1;
                    foreach(var toy in listoftoys)
                    {
                        Console.WriteLine(counter1 + ". " + toy.ToyName);
                        counter1++;
                    }
                  
                }
            }
            
            
            
         
        }

        public void DeliveryComplete()
        {
            Console.WriteLine("Which child had all of their toys delivered?");
            ChildRegister registry = new ChildRegister();
       
            List<Child> mylist = new List<Child>();
           
            mylist = registry.GetChildren();
           
            int counter = 1;
            foreach(var child in mylist)
            {
                //Console.WriteLine(child.ChildName + " " + child.Delivered);
                if(child.Delivered == 1)
                {
                    Console.WriteLine(counter + ". " + child.ChildName);

                    counter++;
                }
            }
        }

        public void YuletimeDeliveryReport()
        {
            Console.WriteLine("Yuletime Delivery Report");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%");
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mychildlist = new List<Child>();
            List<Toys> mytoylist = new List<Toys>();
            mychildlist = registry.GetChildren();
            int childcounter = 1;
            int toycounter = 1;
            foreach(var child in mychildlist)
            {
                if(child.Delivered == 1)
                {
                    Console.WriteLine(childcounter + ". " + child.ChildName);
                
                    mytoylist = myhelper.GetChildsToys(child.ChildID);
                    foreach(var toy in mytoylist)
                    {
                        if(child.ChildID == toy.ChildID)
                        {
                            Console.WriteLine("  " + toycounter + ". " + toy.ToyName);
                            toycounter++;
                        }
                    }
                    childcounter++;
                }
            }
        }

        

        
    }
}