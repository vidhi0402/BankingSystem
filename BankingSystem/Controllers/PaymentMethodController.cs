using BankingSystem.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.Models;
using BankingSystem.IServices;
using BankingSystem.ViewModels;
using BankingSystem.Services;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService paymentMethodService;
        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        { 
            this.paymentMethodService = paymentMethodService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var response = new JsonResponseModel<List<PaymentMethodView>>();
            response = await paymentMethodService.GetAllPaymentMethods();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMethod(Guid id)
        {
            var response = new JsonResponseModel<PaymentMethodView>();
            response = await paymentMethodService.GetPaymentMethod(id);
            return Ok(response);          
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(Guid id, PaymentMethod updatedPaymentMethod)
        {
            var response = new JsonResponseModel<bool>();
            response = await paymentMethodService.UpdatePaymentMethod(id, updatedPaymentMethod);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            response = await paymentMethodService.DeletePaymentMethod(id);
            return Ok(response);
        }
    }
}
