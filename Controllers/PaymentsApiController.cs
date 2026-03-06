using Microsoft.AspNetCore.Mvc;
using PaymentApp.DTOs;
using PaymentApp.Services;

namespace PaymentApp.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsApiController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsApiController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var payment = await _paymentService.CreatePaymentAsync(dto);
        return Ok(payment);
    }

    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        var payments = await _paymentService.GetPaymentsAsync();
        return Ok(payments);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _paymentService.GetStatsAsync();
        return Ok(stats);
    }
}