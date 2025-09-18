using System.ComponentModel.DataAnnotations;

namespace TreineMais.Domain.ValueObject;

public enum Gender
{
    [Display(Name = "Male")]
    Male,
    [Display(Name = "Female")]
    Female,
    [Display(Name = "Other")]
    Other
}