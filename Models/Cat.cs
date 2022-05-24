using System.ComponentModel.DataAnnotations;

namespace Petme.Models
{
  public class Cat
  {
    public string Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; set; }
    [Range(0, int.MaxValue)]
    public int Age { get; set; }
    public string Temperament { get; set; } = "Happy";

    // NO MORE CONSTRUCTORS AFTER TODAY (USING FOR MAKING FAKE DATA)
    public Cat(string name, int age, string temperament)
    {
      // fake random id
      Id = Guid.NewGuid().ToString();
      Name = name;
      Age = age;
      Temperament = temperament;
    }
  }
}