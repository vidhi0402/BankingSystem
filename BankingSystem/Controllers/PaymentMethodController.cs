using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;
using BankingSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
            JsonResponseModel<List<PaymentMethodView>> response = await paymentMethodService.GetAllPaymentMethods();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMethod(Guid id)
        {
            JsonResponseModel<PaymentMethodView> response = await paymentMethodService.GetPaymentMethod(id);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(Guid id, PaymentMethod updatedPaymentMethod)
        {
            JsonResponseModel<bool> response = await paymentMethodService.UpdatePaymentMethod(id, updatedPaymentMethod);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(Guid id)
        {
            JsonResponseModel<bool> response = await paymentMethodService.DeletePaymentMethod(id);
            return Ok(response);
        }
    }
}
