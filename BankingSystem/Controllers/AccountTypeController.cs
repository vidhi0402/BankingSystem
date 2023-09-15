using BankingSystem.DataBase.Models;
using BankingSystem.Services.IServices;
using BankingSystem.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService accountTypeService;

        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            this.accountTypeService = accountTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            JsonResponseModel<List<AccountTypeView>> response = await accountTypeService.GetAllAccountTypes();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountType(Guid id)
        {
            JsonResponseModel<AccountTypeView> response = await accountTypeService.GetAccountType(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountType(Guid id, AccountType updatedAccountType)
        {
            JsonResponseModel<bool> response = await accountTypeService.UpdateAccountType(id, updatedAccountType);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(Guid id)
        {
            JsonResponseModel<bool> response = await accountTypeService.DeleteAccountType(id);
            return Ok(response);
        }

    }
}
