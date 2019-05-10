using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class CategoryTests : IDisposable
    {
        public CategoryTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;port=8889;database=katlin_anderson_test;default command timeout=50;";
        }

        [TestMethod]
        public void GetAll_CategoriesEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Category()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Bob", "Monday, Wednesday, and Friday");
            Stylist secondStylist = new Stylist("Bob", "Monday, Wednesday, and Friday");

            //Assert
            Assert.AreEqual(firstStylist, secondStylist);
        }
        //
        // [TestMethod]
        // public void Save_SavesCategoryToDatabase_CategoryList()
        // {
        //     //Arrange
        //     Stylist testCategory = new Stylist("Household chores");
        //     testCategory.Save();
        //
        //     //Act
        //     List<Stylist> result = Stylist.GetAll();
        //     List<Stylist> testList = new List<Stylist>{testCategory};
        //
        //     //Assert
        //     CollectionAssert.AreEqual(testList, result);
        // }
        //
        // [TestMethod]
        // public void Save_DatabaseAssignsIdToCategory_Id()
        // {
        //     //Arrange
        //     Stylist testCategory = new Stylist("Household chores");
        //     testCategory.Save();
        //
        //     //Act
        //     Stylist savedCategory = Stylist.GetAll()[0];
        //
        //     int result = savedCategory.GetId();
        //     int testId = testCategory.GetId();
        //
        //     //Assert
        //     Assert.AreEqual(testId, result);
        // }
        //
        // [TestMethod]
        // public void Find_FindsCategoryInDatabase_Category()
        // {
        //     //Arrange
        //     Stylist testCategory = new Stylist("Household chores");
        //     testCategory.Save();
        //
        //     //Act
        //     Stylist foundCategory = Stylist.Find(testCategory.GetId());
        //
        //     //Assert
        //     Assert.AreEqual(testCategory, foundCategory);
        // }
        //
        // [TestMethod]
        // public void GetItems_RetrievesAllItemsWithCategory_ItemList()
        // {
        //     //Arrange, Act
        //     DateTime itemDueDate =  new DateTime(1999, 12, 24);
        //     Stylist testCategory = new Stylist("Household chores");
        //     testCategory.Save();
        //     Item firstItem = new Item("Mow the lawn", itemDueDate, testCategory.GetId());
        //     firstItem.Save();
        //     Item secondItem = new Item("Do the dishes", itemDueDate, testCategory.GetId());
        //     secondItem.Save();
        //     List<Item> testItemList = new List<Item> {firstItem, secondItem};
        //     List<Item> resultItemList = testCategory.GetItems();
        //
        //     //Assert
        //     CollectionAssert.AreEqual(testItemList, resultItemList);
        // }

      public void Dispose()
      {
          // Item.ClearAll();
          // Stylist.DeleteAll();
      }

    }
  }
