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
            Console.WriteLine ("Assign toy to which child?");
            int counter = 1;
            foreach(var child in mylist)
            {
                Console.WriteLine(counter + ". " + child.ChildName);
                //var newlist = new Tuple<int,int,string>(counter,child.Key,child.Value);
                counter++;

            }
            Console.Write ("> ");
            int assignedchild = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter toy to add to " +  mylist[assignedchild-1].ChildName + "'s Bag o' Loot");
            Console.Write ("> ");
            string toytobeadded = Console.ReadLine();
            myhelper.AddToyToBag(toytobeadded, mylist[assignedchild-1].ChildID);      
        }

        public void RemoveToy()
        {
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mylist = new List<Child>();
            mylist = registry.GetChildren();
            Console.WriteLine("Remove toy from which child?");
            int counter1 = 1;
            foreach(var child in mylist)
            {
                Console.WriteLine(counter1 + ". " + child.ChildName);
                counter1++;
            }
            Console.Write ("> ");
            int badchild = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose toy to revoke from " + mylist[badchild-1].ChildName + "'s Bagaloot");
            List<Toys> listoftoys = new List<Toys>();
            listoftoys = myhelper.GetChildsToys(mylist[badchild-1].ChildID);    
            
            int counter = 1;
            foreach(var toy in listoftoys)
            {
                Console.WriteLine(counter + ". " + toy.ToyName);
                counter++;
            }
            Console.WriteLine("> ");
            int toytoremove = int.Parse(Console.ReadLine());
            myhelper.RemoveToyFromBag(listoftoys[toytoremove-1].ToyID);   
        }

        public void ReviewToyListOfChild()
        {
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mychildlist = new List<Child>();
            List<Toys> mytoylist = new List<Toys>();
            mychildlist = registry.GetChildren();
            Console.WriteLine("View Bag o' Loot for which child?");
            int counter = 1;
            foreach(var child in mychildlist)
            {
                Console.WriteLine(counter + ". " + child.ChildName);
                counter++;
            }
            Console.Write ("> ");
            int goodchild = int.Parse(Console.ReadLine());
            var listoftoys = myhelper.GetChildsToys(mychildlist[goodchild-1].ChildID);
            int counter1 = 1;
            foreach(var toy in listoftoys)
            {
                Console.WriteLine(counter1 + ". " + toy.ToyName);
                counter1++;
            }
                  
               
            
            
            
         
        }

        public void DeliveryComplete()
        {
            Console.WriteLine("Which child has all of their toys delivered?");
            ChildRegister registry = new ChildRegister();
            SantaHelper myhelper = new SantaHelper();
            List<Child> mylist = new List<Child>();
           
            mylist = registry.GetChildren();
           
            int counter = 1;
            foreach(var child in mylist)
            {
                //Console.WriteLine(child.ChildName + " " + child.Delivered);
                
                    Console.WriteLine(counter + ". " + child.ChildName);
                    counter++;
                
            }
            Console.Write ("> ");
            int childwithdeliverycomplete = int.Parse(Console.ReadLine());
            myhelper.IsDelivered(mylist[childwithdeliverycomplete-1].ChildID);
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