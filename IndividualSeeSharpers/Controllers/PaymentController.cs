﻿using Microsoft.AspNetCore.Mvc;

namespace IndividualSeeSharpers.Controllers
{
    public class PaymentController : Controller
    {

        [HttpGet]
        /*public async Task<IActionResult> Index()
        {
            IPaymentClient paymentClient = new PaymentClient("test_kaN7VyneuvgknQKDjn9kmSJExTDux2");
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, 100.00m),
                Description = "Test payment of the example project",
                RedirectUrl = "https://google.com",
                Method = Mollie.Api.Models.Payment.PaymentMethod.Ideal
            };

            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);
            
            return View(paymentResponse.Links.Checkout);
        }*/

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Paid()
        {
            return View();
        }
    }
}
