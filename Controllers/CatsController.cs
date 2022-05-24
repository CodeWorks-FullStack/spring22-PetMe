using Microsoft.AspNetCore.Mvc;
using Petme.Models;
using Petme.Services;

namespace Petme.Controllers
{
  [ApiController]
  // Node: super('api/cats')
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {
    private readonly CatsService _cs;

    public CatsController(CatsService cs)
    {
      _cs = cs;
    }

    [HttpGet] // the method right below this flag is treated as this "TYPE" 
    public ActionResult<List<Cat>> Get()
    {
      try
      {
        List<Cat> cats = _cs.Get();
        return Ok(cats);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")] // equivalent to /:id 
    // there is no 'req'
    public ActionResult<Cat> Get(string id)
    {
      try
      {
        Cat cat = _cs.Get(id);
        return Ok(cat);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // post
    [HttpPost]
    // NO REQ: FromBody creates a class from the body object
    public ActionResult<Cat> Create([FromBody] Cat catData)
    {
      try
      {
        Cat newCat = _cs.Create(catData);
        return Ok(newCat);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // put
    [HttpPut("{id}")]
    public ActionResult<Cat> Edit(string id, [FromBody] Cat catData)
    {
      try
      {
        catData.Id = id;
        Cat updated = _cs.Edit(catData);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // delete
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {
      try
      {
        _cs.Delete(id);
        return Ok("Adopted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}