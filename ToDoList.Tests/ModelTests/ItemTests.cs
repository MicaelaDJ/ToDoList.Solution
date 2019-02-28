using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
    }

    //test confirming Item objects can be successfully created, and are of the Item type:
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      //Arrange
      Item newItem = new Item("test");
      //Assert
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    //test ensuring Item objects can hold a basic description, like "wash the car" or "do the dishes".
    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      //Act
      string result = newItem.GetDescription();
      //Assert
      Assert.AreEqual(description, result);
    }

    //test to make sure you can set new Item descriptions
    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      //Act
      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();
      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    // test to confirm that the list exists, and that its getter method can retrieve it
    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> { };
      //Act
      List<Item> result = Item.GetAll();
      // foreach (Item thisItem in result)
      // {
      //   Console.WriteLine("Output from empty list GetAll test: " + thisItem.GetDescription());
      // }
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    //test to ensure GetAll() can return a list full of recently created items, instead of an empty one
    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      //Act
      List<Item> result = Item.GetAll();
      // foreach (Item thisItem in result)
      // {
      //   Console.WriteLine("Output from second GetAll test: " + thisItem.GetDescription());
      // }
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //   //Act
    //   int result = newItem.GetId();
    //   //Assert
    //   Assert.AreEqual(1, result);
    // }

    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");
      testItem.Save();
      //Act
      Item foundItem = Item.Find(testItem.GetId());
      //Assert
      Assert.AreEqual(testItem, foundItem);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      //Arrange, Act
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");
      //Assert
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");
      //Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");
      //Act
      testItem.Save();
      Item savedItem = Item.GetAll()[0];

      int result = savedItem.GetId();
      int testId = testItem.GetId();
      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesItemInDatabase_String()
    {
      //Arrange
      string firstDescription = "Walk the Dog";
      Item testItem = new Item(firstDescription);
      testItem.Save();
      string secondDescription = "Mow the lawn";
      //Act
      testItem.Edit(secondDescription);
      string result = Item.Find(testItem.GetId()).GetDescription();
      //Assert
      Assert.AreEqual(secondDescription, result);
    }

  }
}
