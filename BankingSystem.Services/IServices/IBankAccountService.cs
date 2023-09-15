using BankingSystem.DataBase.Models;
using BankingSystem.Business.ViewModels;

namespace BankingSystem.Services.IServices
{
    public interface IBankAccountService
    {
        Task<JsonResponseModel<List<BankAccountView>>> GetAllBankAccounts();
        Task<JsonResponseModel<BankAccountView>> GetBankAccount(Guid id);
        Task<JsonResponseModel<List<BankAccountView>>> GenerateBankAccounts(int numberOfAccounts, List<AccountTypeView> accountTypes);
        Task<JsonResponseModel<bool>> UpdateBankAccount(Guid id, BankAccount updatedBankAccount);
        Task<JsonResponseModel<bool>> DeleteBankAccount(Guid id);
    }
}
