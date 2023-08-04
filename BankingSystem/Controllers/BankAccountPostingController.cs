using BankingSystem.IRepository;
using BankingSystem.IServices;
using BankingSystem.Models;
using BankingSystem.ViewModels;
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
            var response = new JsonResponseModel<List<BankAccountPostingView>>();
            response = await bankAccountPostingService.GetAllBankAccountPostings();
            return Ok(response);          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccountPosting(Guid id)
        {
            var response = new JsonResponseModel<BankAccountPostingView>();
            response = await bankAccountPostingService.GetBankAccountPosting(id);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccountPosting(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            response = await bankAccountPostingService.DeleteBankAccountPosting(id);
            return Ok(response);            
        }
    }
}
