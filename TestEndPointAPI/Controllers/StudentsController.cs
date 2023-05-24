using Microsoft.AspNetCore.Mvc;
using TestEndPointAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestEndPointAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> _studentsList;

    static StudentsController()
    {
        _studentsList = new List<Student>()
        {
            new()
            {
                Id = 1,
                Name = "John",
                Email = "guy@gmail.com"
            },
            new()
            {
                Id = 2,
                Name = "Jane",
                Email = "talmi@gmail.com"
            },
            new()
            {
                Id = 3,
                Name = "Jack",
                Email = "ggg@gmail.com`"
            }
        };
    }

    // GET: api/<StudentsController>
    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return _studentsList;
    }

    // GET api/<StudentsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var findStudent = _studentsList.FirstOrDefault(s => s.Id == id);

        if (findStudent == null)
        {
            return NotFound();
        }

        return Ok(findStudent);
    }

    // POST api/<StudentsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Student value)
    {
        value.Id = _studentsList.Count + 1;
        _studentsList.Add(value);

        return Ok(value);
    }

    // PUT api/<StudentsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<StudentsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
