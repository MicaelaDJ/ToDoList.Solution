using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

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

    //test to confirm that the list exists, and that its getter method can retrieve it
    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> { };
      //Act
      List<Item> result = Item.GetAll();
      foreach (Item thisItem in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisItem.GetDescription());
      }
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
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      //Act
      List<Item> result = Item.GetAll();
      foreach (Item thisItem in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisItem.GetDescription());
      }
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

  }
}
