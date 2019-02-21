using Microsoft.AspNetCore.Mvs;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controllers
  {

    [Route("/")]
    public ActionResult Index()
    {
      Item starterItem = new Item("Add first item to To Do List");
      return View(starterItem);
    }
    
  }
}
