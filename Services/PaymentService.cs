using Microsoft.EntityFrameworkCore;
using PaymentApp.Data;
using PaymentApp.DTOs;
using PaymentApp.Models;

namespace PaymentApp.Services;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;

    public PaymentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> CreatePaymentAsync(CreatePaymentDto dto)
    {
        var payment = new Payment
        {
            WalletNumber = dto.WalletNumber,
            Account = dto.Account,
            Email = dto.Email,
            Phone = dto.Phone,
            Amount = dto.Amount,
            Currency = dto.Currency.ToUpper(),
            Comment = dto.Comment,
            Status = dto.Amount > 0 ? "Created" : "Rejected",
            CreatedAt = DateTime.UtcNow
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task<List<Payment>> GetPaymentsAsync()
    {
        return await _context.Payments
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<PaymentStatsDto> GetStatsAsync()
    {
        var payments = await _context.Payments.ToListAsync();

        var stats = new PaymentStatsDto
        {
            TotalAmount = payments.Sum(p => p.Amount),
            TotalCount = payments.Count,
            DailyStats = payments
                .GroupBy(p => p.CreatedAt.Date)
                .Select(g => new DailyPaymentStatsDto
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    Count = g.Count(),
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Date)
                .ToList()
        };

        return stats;
    }
}