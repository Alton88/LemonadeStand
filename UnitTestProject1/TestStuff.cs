using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLemonadeStand
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLemonCheckout()
        {
            //Arrange
            int amount = 1;
            double price = 0.50;
            bool result = false;
            Inventory inventory = new Inventory();
            Player player = new Human("Tester");
            Store store = new Store();
            //Act
            result = store.LemonCheckout(amount, price, inventory, player);
            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestSugarCheckout()
        {
            //Arrange
            int amount = 1;
            double price = 0.50;
            bool result = false;
            Inventory inventory = new Inventory();
            Player player = new Human("Tester");
            Store store = new Store();
            //Act
            result = store.SugarCheckout(amount, price, inventory, player);
            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestIceCheckout()
        {
            //Arrange
            int amount = 1;
            double price = 0.50;
            bool result = false;
            Inventory inventory = new Inventory();
            Player player = new Human("Tester");
            Store store = new Store();
            //Act
            result = store.IceCheckout(amount, price, inventory, player);
            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestIsEmpty()
        {
            //Arrange
            bool result = false;
            Pitcher pitcher = new Pitcher("Tart", 0);
            //Act
            result = pitcher.IsEmpty();
            //Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestIsNotEmpty()
        {
            //Arrange
            bool result = false;
            Pitcher pitcher = new Pitcher("Tart", 12);
            //Act
            result = pitcher.IsEmpty();
            //Assert
            Assert.AreEqual(false, result);
        }
        
    }
}
