using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;
using BankingSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountPostingController : ControllerBase
    {
        private readonly IBankAccountPostingService bankAccountPostingService;
        public BankAccountPostingController(IBankAccountPostingService bankAccountPostingService)
        {
            this.bankAccountPostingService = bankAccountPostingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBankAccountPostings()
        {
            JsonResponseModel<List<BankAccountPostingView>> response = await bankAccountPostingService.GetAllBankAccountPostings();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccountPosting(Guid id)
        {
            JsonResponseModel<BankAccountPostingView> response = await bankAccountPostingService.GetBankAccountPosting(id);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccountPosting(Guid id)
        {
            JsonResponseModel<bool> response = await bankAccountPostingService.DeleteBankAccountPosting(id);
            return Ok(response);
        }
    }
}
