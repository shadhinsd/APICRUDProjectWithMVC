using System.ComponentModel.DataAnnotations;

namespace WebApiWithMvcCrud.Models;
public class Student
{
	public long id { get; set; }
	[Required]
	public string name { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string phone { get; set; }
}
