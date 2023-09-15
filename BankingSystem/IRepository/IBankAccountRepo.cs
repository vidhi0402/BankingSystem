using BankingSystem.DataBase.Models;

namespace BankingSystem.IRepository
{
    public interface IBankAccountRepo
    {
        Task<List<BankAccount>> GetAllBankAccounts();
        Task<BankAccount> GetBankAccountById(Guid id);
        Task AddBankAccount(BankAccount bankAccount);
        Task UpdateBankAccount(BankAccount updatedBankAccount);
        Task DeleteBankAccount(BankAccount bankAccountToDelete);

    }
}
