using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.IServices
{
    public interface IAccountTypeService
    {
        Task<JsonResponseModel<List<AccountTypeView>>> GetAllAccountTypes();
        Task<JsonResponseModel<AccountTypeView>> GetAccountType(Guid id);
        Task<JsonResponseModel<bool>> DeleteAccountType(Guid id);
        Task<JsonResponseModel<bool>> UpdateAccountType(Guid id, Models.AccountType updatedAccountType);
    }
}
