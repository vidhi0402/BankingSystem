using BankingSystem.DataBase.Models;

namespace BankingSystem.IRepository
{
    public interface IBankTransactionRepo
    {
        Task<List<BankTransaction>> GetAllBankTransactions();
        Task<BankTransaction> GetBankTransactionById(Guid id);
        Task AddBankTransaction(BankTransaction bankTransaction);
        Task UpdateBankTransaction(BankTransaction updatedBankTransaction);
        Task DeleteBankTransaction(BankTransaction bankTransactionToDelete);
        Task<List<BankTransaction>> GetAllBankTransactionsByBankAccount(Guid bankAccountId);

    }
}
