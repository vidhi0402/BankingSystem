using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;
using BankingSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionController : ControllerBase
    {
        private readonly IBankTransactionService bankTransactionService;
        private readonly IBankAccountService bankAccountService;
        private readonly IPaymentMethodService paymentMethodService;
        private readonly IConfiguration configuration;
        public BankTransactionController(IBankTransactionService bankTransactionService, IBankAccountService bankAccountService, IPaymentMethodService paymentMethodService, IConfiguration configuration)
        {
            this.bankTransactionService = bankTransactionService;
            this.bankAccountService = bankAccountService;
            this.paymentMethodService = paymentMethodService;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBankTransactions()
        {
            JsonResponseModel<List<BankTransactionView>> response = await bankTransactionService.GetAllBankTransactions();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankTransaction(Guid id)
        {
            JsonResponseModel<BankTransactionView> response = await bankTransactionService.GetBankTransaction(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBankTransactionByAccountId")]
        public async Task<IActionResult> GetBankTransactionByAccountId(Guid bankAccountId)
        {
            JsonResponseModel<List<BankTransactionView>> response = await bankTransactionService.GetBankTransactionByAccountId(bankAccountId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankTransaction()
        {
            int numberOfTransaction = int.Parse(configuration["AppSettings:NumberOfDummyBankAccounts"]);
            List<BankAccountView> bankAccounts = (await bankAccountService.GetAllBankAccounts()).Result;
            List<PaymentMethodView> paymentMethods = (await paymentMethodService.GetAllPaymentMethods()).Result;
            JsonResponseModel<List<BankTransactionView>> response = await bankTransactionService.GenerateBankTransactions(numberOfTransaction, bankAccounts, paymentMethods);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankTransaction(Guid id, BankTransaction updatedBankTransaction)
        {
            JsonResponseModel<bool> response = await bankTransactionService.UpdateBankTransaction(id, updatedBankTransaction);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankTransaction(Guid id)
        {
            JsonResponseModel<bool> response = await bankTransactionService.DeleteBankTransaction(id);
            return Ok(response);
        }

    }
}

