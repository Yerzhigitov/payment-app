using Microsoft.AspNetCore.Mvc;
using PaymentApp.DTOs;
using PaymentApp.Services;


namespace PaymentApp.Controllers;

public class PaymentsController : Controller
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        await _paymentService.CreatePaymentAsync(dto);
        TempData["Success"] = "Платёж успешно создан";
        return RedirectToAction(nameof(History));
    }

    [HttpGet]
    public async Task<IActionResult> History()
    {
        var payments = await _paymentService.GetPaymentsAsync();
        return View(payments);
    }

    [HttpGet]
    public async Task<IActionResult> Stats()
    {
        var stats = await _paymentService.GetStatsAsync();
        return View(stats);
    }
}