using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models;

public class Person {
    [Required, MinLength(3)]
    public string? FirstName { get; set; }

    [Required, MinLength(3)]
    public string? LastName { get; set; }

    [Required]
    public string? MiddleName { get; set; }

    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
}