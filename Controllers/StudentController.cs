using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_opreation_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> Students = new List<Student>
{
new Student {
Id = 1,
Name = "potato"
},
new Student {
Id =2,
Name = "mohammad"
}
};
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Student>>> Get()
        {

            return Ok(await _context.Students.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> Get(int id)
        {
            // Use the Where() method to find the student
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return BadRequest("student not found");

            // Define the Students variable

            // Return the Students variable
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateUser(Student request)
        {
            // Use the Where() method to find the student
            var studenttest = await _context.Students.FindAsync(request.Id);
            if (studenttest == null)
                return BadRequest("student not found");
            studenttest.Id = request.Id;
            studenttest.Name = request.Name;
            // Define the Students variable
            await _context.SaveChangesAsync();
            // Return the Students variable
            return Ok(await _context.Students.ToListAsync()
        
);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteUser(int id)
        {
            // Use the Where() method to find the student
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return BadRequest("student not found");

            // Define the Students variable
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            // Return the Students variable
            return Ok(await _context.Students.ToListAsync());
        }
    }
}
