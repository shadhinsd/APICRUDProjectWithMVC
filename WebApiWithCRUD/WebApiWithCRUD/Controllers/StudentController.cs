using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWithCRUD.Models;

namespace WebApiWithCRUD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly StudentDbContext dbContext;

		public StudentController(StudentDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
		[HttpGet]
		public async Task<ActionResult<List<Student>>> GetStudent()
		{
			var data = await dbContext.Students.ToListAsync();
			return Ok(data);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudent(long id)
		{
			var data=await dbContext.Students.FindAsync(id);
			if (data == null) return NotFound();
			return data;
		}
		[HttpPost]
		public async Task<ActionResult<Student>> CreateStudent(Student std)
		{
			await dbContext.Students.AddAsync(std);
			await dbContext.SaveChangesAsync();
			return Ok(std);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<Student>> UpdateStudent(long id, Student std)
		{
			if (id != std.Id) return BadRequest();
			dbContext.Entry(std).State = EntityState.Modified;
			await dbContext.SaveChangesAsync();
			return Ok(std);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Student>> DeleteStudent(long id)
		{
			var data = await dbContext.Students.FindAsync(id);
			if (data == null) return NotFound();
			dbContext.Students.Remove(data);
			await dbContext.SaveChangesAsync();
			return Ok(data);
		}
	}
}
