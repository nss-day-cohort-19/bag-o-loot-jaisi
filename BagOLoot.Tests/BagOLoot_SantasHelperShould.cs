using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class SantaHelperShould
    {
        private SantaHelper _helper;
        private ChildRegister _register;
        public SantaHelperShould()
        {
            _helper = new SantaHelper();
            _register = new ChildRegister();
        }

        //1
        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "Skateboard";
            //string child = "Aarti";
            int childid = 1;
            int toyId = _helper.AddToyToBag(toyName, childid);
            List<Toys> toys = _helper.GetChildsToys(childid);

            Assert.Contains(toyId, toys);
        }

        //2
        [Fact]
        public void RemoveToyFromChild()
        {
            int childId = 15;
            int toyId = 5;
            _helper.RemoveToyFromBag(toyId);
            List<Toys> childsToys = new List<Toys>();
            childsToys = _helper.GetChildsToys(childId);

            Assert.DoesNotContain(toyId, childsToys);
        }

        //3
        [Fact]
         public void GetChildrenWithToys()
         {

             List<Child> listOfChildren = new List<Child>();
            listOfChildren =  _register.GetChildren();

            Assert.IsType<List<Child>>(listOfChildren);
         }

        //4
        [Fact]
        public void GetListOfChildsToys()
        {
            int childId = 9;
            List<Toys> listOfToys = _helper.GetChildsToys(childId);

            Assert.True(listOfToys.Count >= 0);
        }

        //5
        //set delivered property of a child
         [Fact]
        public void SetDeliveredToChild()
        {
            int childId = 9;
            bool delivered = _helper.IsDelivered(childId);
            //if u are in this list, delivered is true
            Assert.True(delivered);
        }


    }
}