using BankingSystem.DataBase.Models;
using BankingSystem.Business.ViewModels;

namespace BankingSystem.IServices
{
    public interface IBankAccountPostingService
    {
        Task<JsonResponseModel<List<BankAccountPostingView>>> GetAllBankAccountPostings();
        Task<JsonResponseModel<BankAccountPostingView>> GetBankAccountPosting(Guid id);
        Task<JsonResponseModel<bool>> DeleteBankAccountPosting(Guid id);
    }
}
