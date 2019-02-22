using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class HomeControllerTest
  {

    //test to verify that the index() method on the HomeController, referred to as todolist.homecontroller.index(), returns a view properly
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      HomeController controller = new HomeController();
      //Act
      ActionResult indexView = controller.Index();
      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    //test to make sure the model contains a list of items
    [TestMethod]
    public void Index_HasCorrectModelType_ItemList()
    {
      //Arrange
      ViewResult indexView = new HomeController().Index() as ViewResult;
      //Act
      var result = indexView.ViewData.Model;
      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Item>));
    }

  }
}
