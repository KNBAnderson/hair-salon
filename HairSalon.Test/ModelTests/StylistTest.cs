using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;port=8889;database=katlin_anderson_test;default command timeout=50;";
        }

        // [TestMethod]
        // public void GetAll_CategoriesEmptyAtFirst_0()
        // {
        //     //Arrange, Act
        //     int result = Stylist.GetAll().Count;
        //
        //     //Assert
        //     Assert.AreEqual(0, result);
        // }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Bob", "Monday, Wednesday, and Friday");
            Stylist secondStylist = new Stylist("Bob", "Monday, Wednesday, and Friday");

            //Assert
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Sally", "Saturday and Suday");
            testStylist.Save();

            //Act
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
            //Arrange
            Stylist testStylist = new Stylist("Eric", "Monday, Tuesday, and Wednesday");
            testStylist.Save();

            //Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.Id;
            int testId = testStylist.Id;

            //Assert
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("Linda", "Once a year");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.Id);

            //Assert
            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void GetSpecialties_GetSpecialtiesOfStylistInDatabase_StylistList()
        {
            //Arrange
            Stylist testStylist = new Stylist("Linda", "Once a year");
            testStylist.Save();

            //Act
            Specialty firstSpecialty = new Specialty("Haircuts");
            firstSpecialty.Save();
            testStylist.AddSpecialty(firstSpecialty);
            Specialty secondSpecialty = new Specialty("Ombre dye");
            secondSpecialty.Save();
            testStylist.AddSpecialty(secondSpecialty);
            List<Specialty> testSpecialtyList = new List<Specialty> {firstSpecialty, secondSpecialty};
            List<Specialty> resultSpecialtyList = testStylist.GetSpecialties();

            //Assert
            CollectionAssert.AreEqual(testSpecialtyList, resultSpecialtyList);
        }

        [TestMethod]
        public void Test_AddSpecialty_AddsSpecialtyToStylist()
        {
            //Arrange
            Stylist testStylist = new Stylist("Fernando", "Never");
            testStylist.Save();
            Specialty testSpecialty = new Specialty("Bowl cuts");
            testSpecialty.Save();
            Specialty testSpecialty2 = new Specialty("Mohawks");
            testSpecialty2.Save();

            //Act
            testStylist.AddSpecialty(testSpecialty);
            testStylist.AddSpecialty(testSpecialty2);
            List<Specialty> result = testStylist.GetSpecialties();
            List<Specialty> testList = new List<Specialty>{testSpecialty, testSpecialty2};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }


      public void Dispose()
      {
          Stylist.ClearAll();
      }

    }
  }
