namespace PaymentApp.DTOs;

public class PaymentStatsDto
{
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
    public List<DailyPaymentStatsDto> DailyStats { get; set; } = new();
}

public class DailyPaymentStatsDto
{
    public string Date { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal TotalAmount { get; set; }
}