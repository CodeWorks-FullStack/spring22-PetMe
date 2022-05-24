using Petme.FakeDB;
using Petme.Models;

namespace Petme.Services
{
  public class CatsService
  {
    internal List<Cat> Get()
    {
      // This layer will change
      return Database.Cats;
    }

    internal Cat Get(string id)
    {
      // Unique to FakeDb
      Cat cat = Database.Cats.Find(c => c.Id == id);
      if (cat == null)
      {
        throw new Exception("Invalid Cat Id");
      }

      return cat;
    }

    internal Cat Create(Cat catData)
    {
      Database.Cats.Add(catData);
      return catData;
    }

    internal Cat Edit(Cat catData)
    {
      Cat original = Get(catData.Id);
      // original.Name = catData.Name != null ? catData.Name : original.Name;
      original.Name = catData.Name ?? original.Name;
      original.Age = catData.Age;
      original.Temperament = catData.Temperament ?? original.Temperament;

      // send update to database

      return original;
    }

    internal void Delete(string id)
    {
      Cat found = Get(id);
      Database.Cats.Remove(found);
    }


  }

}