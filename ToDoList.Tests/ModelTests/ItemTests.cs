using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest
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

  }
}
