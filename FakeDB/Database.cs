using Petme.Models;

namespace Petme.FakeDB
{
  // THIS IS ONLY FOR TODAY
  public static class Database
  {
    public static List<Cat> Cats { get; set; } = new List<Cat>()
    {
        new Cat("Gopher", 2, "Clumsy"),
        new Cat("Ironman", 3, "Bitey"),
        new Cat("Dudley", 1, "Fierce")
    };
  }
}