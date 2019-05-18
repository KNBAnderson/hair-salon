using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;port=8889;database=katlin_anderson_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      DateTime newDateTime = new DateTime(2001);
      Client newClient = new Client("Martha", 1, newDateTime);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
//Not sure why this one is failing
    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      DateTime newDateTime = new DateTime(2001);
      Client newClient1 = new Client("Martha", 1, newDateTime);
      newClient1.Save();
      Client newClient2 = new Client("Barbara", 2, newDateTime);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };
      //Act
      List<Client> result = Client.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      DateTime newDateTime = new DateTime(2001);
      Client testClient = new Client("Sally", 1, newDateTime);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.Id);
      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      // Arrange, Act
      DateTime newDateTime = new DateTime(2001);
      Client firstClient = new Client("Sally", 1, newDateTime);
      Client secondClient = new Client("Sally", 1, newDateTime);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    // [TestMethod]
    // public void Save_SavesToDatabase_ClientList()
    // {
    //   //Arrange
    //   Client testClient = new Client("Mow the lawn");
    //
    //   //Act
    //   testClient.Save();
    //   List<Client> result = Client.GetAll();
    //   List<Client> testList = new List<Client>{testClient};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   //Arrange
    //   Client testClient = new Client("Mow the lawn");
    //
    //   //Act
    //   testClient.Save();
    //   Client savedClient = Client.GetAll()[0];
    //
    //   int result = savedClient.GetId();
    //   int testId = testClient.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }
    //
    // [TestMethod]
    // public void Edit_UpdatesClientInDatabase_String()
    // {
    //   //Arrange
    //   Client testClient = new Client("Walk the Dog");
    //   testClient.Save();
    //   string secondName = "Mow the lawn";
    //
    //   //Act
    //   testClient.Edit(secondName);
    //   string result = Client.Find(testClient.GetId()).GetName();
    //
    //   //Assert
    //   Assert.AreEqual(secondName, result);
    // }
    //
    // [TestMethod]
    // public void GetCategories_ReturnsAllClientCategories_StylistList()
    // {
    //   //Arrange
    //   Client testClient = new Client("Mow the lawn");
    //   testClient.Save();
    //   Stylist testStylist1 = new Stylist("Home stuff");
    //   testStylist1.Save();
    //   Stylist testStylist2 = new Stylist("Work stuff");
    //   testStylist2.Save();
    //
    //   //Act
    //   testClient.AddStylist(testStylist1);
    //   List<Stylist> result = testClient.GetCategories();
    //   List<Stylist> testList = new List<Stylist> {testStylist1};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void AddStylist_AddsStylistToClient_StylistList()
    // {
    //   //Arrange
    //   Client testClient = new Client("Mow the lawn");
    //   testClient.Save();
    //   Stylist testStylist = new Stylist("Home stuff");
    //   testStylist.Save();
    //
    //   //Act
    //   testClient.AddStylist(testStylist);
    //
    //   List<Stylist> result = testClient.GetCategories();
    //   List<Stylist> testList = new List<Stylist>{testStylist};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }
    //
    // [TestMethod]
    // public void Delete_DeletesClientAssociationsFromDatabase_ClientList()
    // {
    //   //Arrange
    //   Stylist testStylist = new Stylist("Home stuff");
    //   testStylist.Save();
    //   string testName = "Mow the lawn";
    //   Client testClient = new Client(testName);
    //   testClient.Save();
    //
    //   //Act
    //   testClient.AddStylist(testStylist);
    //   testClient.Delete();
    //   List<Client> resultStylistClients = testStylist.GetClients();
    //   List<Client> testStylistClients = new List<Client> {};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testStylistClients, resultStylistClients);
    // }

  }
}
