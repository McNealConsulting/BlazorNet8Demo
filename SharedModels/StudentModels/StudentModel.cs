using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.StudentModels;
public class StudentModel
{
    public int Id { get; set; } = 0;

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First Name has a maximum length of 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last Name has a maximum length of 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Email has a Minimum length of 5, and a Maximum length of 50 characters.")]
    [EmailAddress]
    public string? Email { get; set; }

    [Display(Name = "Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Birthdate")]
    [Required(ErrorMessage = "Birthdate is required.")]
    //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly BirthDate { get; set; }


    // Moved to VM
    //public string FullName => $"{FirstName} {MiddleName?.Trim() ?? ""} {LastName}";

    //public override string ToString()
    //{
    //    return $"{FirstName} {MiddleName?.Trim() ?? ""} {LastName}";
    //}

}
