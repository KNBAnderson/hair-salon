using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Specialty.ClearAll();
      Stylist.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;port=8889;database=katlin_anderson_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("bowlcuts");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_SpecialtyList()
    {
      //Arrange
      List<Specialty> newList = new List<Specialty> { };

      //Act
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsSpecialties_SpecialtyList()
    {
      //Arrange
      Specialty newSpecialty1 = new Specialty("waxing");
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty("bowlcuts");
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

      //Act
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //   testSpecialty.Save();
    //
    //   //Act
    //   Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());
    //
    //   //Assert
    //   Assert.AreEqual(testSpecialty, foundSpecialty);
    // }
    //
    // [TestMethod]
    // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Specialty()
    // {
    //   // Arrange, Act
    //   Specialty firstSpecialty = new Specialty("Mow the lawn");
    //   Specialty secondSpecialty = new Specialty("Mow the lawn");
    //
    //   // Assert
    //   Assert.AreEqual(firstSpecialty, secondSpecialty);
    // }
    //
    // [TestMethod]
    // public void Save_SavesToDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //
    //   //Act
    //   testSpecialty.Save();
    //   List<Specialty> result = Specialty.GetAll();
    //   List<Specialty> testList = new List<Specialty>{testSpecialty};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //
    //   //Act
    //   testSpecialty.Save();
    //   Specialty savedSpecialty = Specialty.GetAll()[0];
    //
    //   int result = savedSpecialty.GetId();
    //   int testId = testSpecialty.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesSpecialtyInDatabase_String()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Walk the Dog");
    //   testSpecialty.Save();
    //   string secondDescription = "Mow the lawn";
    //
    //   //Act
    //   testSpecialty.Edit(secondDescription);
    //   string result = Specialty.Find(testSpecialty.GetId()).GetDescription();
    //
    //   //Assert
    //   Assert.AreEqual(secondDescription, result);
    // }
    //
    // [TestMethod]
    // public void GetCategories_ReturnsAllSpecialtyCategories_CategoryList()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //   testSpecialty.Save();
    //   Category testCategory1 = new Category("Home stuff");
    //   testCategory1.Save();
    //   Category testCategory2 = new Category("Work stuff");
    //   testCategory2.Save();
    //
    //   //Act
    //   testSpecialty.AddCategory(testCategory1);
    //   List<Category> result = testSpecialty.GetCategories();
    //   List<Category> testList = new List<Category> {testCategory1};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void AddCategory_AddsCategoryToSpecialty_CategoryList()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //   testSpecialty.Save();
    //   Category testCategory = new Category("Home stuff");
    //   testCategory.Save();
    //
    //   //Act
    //   testSpecialty.AddCategory(testCategory);
    //
    //   List<Category> result = testSpecialty.GetCategories();
    //   List<Category> testList = new List<Category>{testCategory};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   Category testCategory = new Category("Home stuff");
    //   testCategory.Save();
    //   string testDescription = "Mow the lawn";
    //   Specialty testSpecialty = new Specialty(testDescription);
    //   testSpecialty.Save();
    //
    //   //Act
    //   testSpecialty.AddCategory(testCategory);
    //   testSpecialty.Delete();
    //   List<Specialty> resultCategorySpecialtys = testCategory.GetSpecialtys();
    //   List<Specialty> testCategorySpecialtys = new List<Specialty> {};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testCategorySpecialtys, resultCategorySpecialtys);
    // }

  }
}
