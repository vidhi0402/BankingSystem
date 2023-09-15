using BankingSystem.DataBase.Models;
using BankingSystem.Business.ViewModels;

namespace BankingSystem.Services.IServices
{
    public interface IAccountTypeService
    {
        Task<JsonResponseModel<List<AccountTypeView>>> GetAllAccountTypes();
        Task<JsonResponseModel<AccountTypeView>> GetAccountType(Guid id);
        Task<JsonResponseModel<bool>> DeleteAccountType(Guid id);
        Task<JsonResponseModel<bool>> UpdateAccountType(Guid id, DataBase.Models.AccountType updatedAccountType);
    }
}
