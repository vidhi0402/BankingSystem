using BankingSystem.IServices;
using BankingSystem.Models;
using BankingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IAccountTypeService accountService;
        private readonly IBankAccountService bankAccountService;
        private readonly IConfiguration configuration;
        public BankAccountController(IAccountTypeService accountService, IBankAccountService bankAccountService, IConfiguration configuration)
        {
            this.accountService = accountService;
            this.bankAccountService = bankAccountService;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBankAccounts()
        {
            var response = new JsonResponseModel<List<BankAccountView>>();
            response = await bankAccountService.GetAllBankAccounts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccount(Guid id)
        {
            var response = new JsonResponseModel<BankAccountView>();
            response = await bankAccountService.GetBankAccount(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankAccount()
        {
            var response = new JsonResponseModel<List<BankAccountView>>();
            int numberOfAccounts = int.Parse(configuration["AppSettings:NumberOfDummyBankAccounts"]);
            List<AccountTypeView> accountTypes = (await accountService.GetAllAccountTypes()).Result;
            response = await bankAccountService.GenerateBankAccounts(numberOfAccounts, accountTypes);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(Guid id, BankAccount updatedBankAccount)
        {
            var response = new JsonResponseModel<bool>();
            response = await bankAccountService.UpdateBankAccount(id, updatedBankAccount);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            response = await bankAccountService.DeleteBankAccount(id);
            return Ok(response);
        }
    }
}
