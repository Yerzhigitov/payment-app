using System.ComponentModel.DataAnnotations;

namespace PaymentApp.DTOs;

public class CreatePaymentDto
{
    [Required]
    public string WalletNumber { get; set; } = string.Empty;

    [Required]
    public string Account { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? Phone { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public string Currency { get; set; } = string.Empty;

    public string? Comment { get; set; }
}