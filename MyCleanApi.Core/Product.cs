using System.ComponentModel.DataAnnotations;

namespace MyCleanApi.Core;

public sealed class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    [Required]
    public required string ProductName { get; set; }

    [Range(0.0001, double.MaxValue)]
    public required double Price { get; set; }
}