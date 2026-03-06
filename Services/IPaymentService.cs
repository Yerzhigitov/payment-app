using PaymentApp.DTOs;
using PaymentApp.Models;

namespace PaymentApp.Services;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(CreatePaymentDto dto);
    Task<List<Payment>> GetPaymentsAsync();
    Task<PaymentStatsDto> GetStatsAsync();
}