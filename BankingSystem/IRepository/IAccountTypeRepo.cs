using BankingSystem.DataBase.Models;

namespace BankingSystem.IRepository
{
    public interface IAccountTypeRepo
    {
        Task<List<AccountType>> GetAllAccountTypes();
        Task<AccountType> GetAccountTypeById(Guid id);
        Task AddAccountType(AccountType accountType);
        Task UpdateAccountType(AccountType updatedAccountType);
        Task DeleteAccountType(AccountType accountTypeToDelete);

    }
}
