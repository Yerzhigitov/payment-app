using System.ComponentModel.DataAnnotations;

namespace PaymentApp.Models;

public class Payment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string WalletNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Account { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    [MaxLength(10)]
    public string Currency { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Comment { get; set; }

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Created";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}