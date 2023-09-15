using BankingSystem.DataBase.Models;
using BankingSystem.Services.IServices;
using BankingSystem.Business.ViewModels;
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
            JsonResponseModel<List<BankAccountView>> response = await bankAccountService.GetAllBankAccounts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccount(Guid id)
        {
            JsonResponseModel<BankAccountView> response = await bankAccountService.GetBankAccount(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankAccount()
        {
            int numberOfAccounts = int.Parse(configuration["AppSettings:NumberOfDummyBankAccounts"]);
            List<AccountTypeView> accountTypes = (await accountService.GetAllAccountTypes()).Result;
            JsonResponseModel<List<BankAccountView>> response = await bankAccountService.GenerateBankAccounts(numberOfAccounts, accountTypes);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(Guid id, BankAccount updatedBankAccount)
        {
            JsonResponseModel<bool> response = await bankAccountService.UpdateBankAccount(id, updatedBankAccount);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(Guid id)
        {
            JsonResponseModel<bool> response = await bankAccountService.DeleteBankAccount(id);
            return Ok(response);
        }
    }
}
