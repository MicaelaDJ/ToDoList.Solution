using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemControllerTest
  {

    // //test to check the datatype of the IActionResult returned from the action
    // [TestMethod]
    // public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    // {
    //   //Arrange
    //   ItemsController controller = new ItemsController();
    //   //Act
    //   IActionResult view = controller.Create("Walk the dog");
    //   //Assert
    //   Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    // }
    //
    // //test checks the name of the action that we redirect to
    // [TestMethod]
    // public void Create_RedirectsToCorrectAction_Index()
    // {
    //   //Arrange
    //   ItemsController controller = new ItemsController();
    //   RedirectToActionResult actionResult = controller.Create("Walk the dog") as RedirectToActionResult;
    //   //Act
    //   string result = actionResult.ActionName;
    //   //Assert
    //   Assert.AreEqual(result, "Index");
    // }

  }
}
