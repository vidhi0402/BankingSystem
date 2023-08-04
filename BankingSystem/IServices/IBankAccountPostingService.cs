using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.IServices
{
    public interface IBankAccountPostingService
    {
        Task<JsonResponseModel<List<BankAccountPostingView>>> GetAllBankAccountPostings();
        Task<JsonResponseModel<BankAccountPostingView>> GetBankAccountPosting(Guid id);
        Task<JsonResponseModel<bool>> DeleteBankAccountPosting(Guid id);
    }
}
