using System.ComponentModel.DataAnnotations;

namespace EmpoyeesApp.Web.Models;

public class Employee
{
    public int Id { get; set; }
    [Display]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "Enter a email")]
    public string? Email { get; set; }
}
