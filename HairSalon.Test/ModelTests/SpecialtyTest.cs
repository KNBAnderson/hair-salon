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

    [TestMethod]
    public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Bowlcuts");
      testSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.Id);

      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
    {
      // Arrange, Act
      Specialty firstSpecialty = new Specialty("Cut and color");
      Specialty secondSpecialty = new Specialty("Cut and color");

      // Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Mullets");

      //Act
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Mullets");

      //Act
      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.Id;
      int testId = testSpecialty.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetStylists_ReturnsAllSpecialtyStylists_StylistList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Cut and color");
      testSpecialty.Save();
      Stylist testStylist1 = new Stylist("Bob", "all the time");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Gertrude", "Monday through Friday, before 2:00 pm");
      testStylist2.Save();

      //Act
      testSpecialty.AddStylist(testStylist1);
      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void AddStylist_AddsStylistToSpecialty_StylistList()
    // {
    //   //Arrange
    //   Specialty testSpecialty = new Specialty("Mow the lawn");
    //   testSpecialty.Save();
    //   Stylist testStylist = new Stylist("Home stuff");
    //   testStylist.Save();
    //
    //   //Act
    //   testSpecialty.AddStylist(testStylist);
    //
    //   List<Stylist> result = testSpecialty.GetStylists();
    //   List<Stylist> testList = new List<Stylist>{testStylist};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
    // {
    //   //Arrange
    //   Stylist testStylist = new Stylist("Home stuff");
    //   testStylist.Save();
    //   string testDescription = "Mow the lawn";
    //   Specialty testSpecialty = new Specialty(testDescription);
    //   testSpecialty.Save();
    //
    //   //Act
    //   testSpecialty.AddStylist(testStylist);
    //   testSpecialty.Delete();
    //   List<Specialty> resultStylistSpecialtys = testStylist.GetSpecialtys();
    //   List<Specialty> testStylistSpecialtys = new List<Specialty> {};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testStylistSpecialtys, resultStylistSpecialtys);
    // }

  }
}
