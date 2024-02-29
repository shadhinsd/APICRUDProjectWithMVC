using Microsoft.EntityFrameworkCore;

namespace WebApiWithCRUD.Models;

public class StudentDbContext:DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
    {
        
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
	}
	public DbSet<Student> Students { get; set; }

}
