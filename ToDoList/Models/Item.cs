namespace ToDoList.Models
{
  public class Item
  {
    private string_description;

    public Item (string description)
    {
      _description = description;
    }

    public string GetDescription()
    {
      return _description;
    }

  }
}
