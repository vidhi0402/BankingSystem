using BankingSystem.DataBase.Models;

namespace BankingSystem.Repository.Repository.IRepository
{
    public interface IBankTransactionRepo
    {
        Task<List<BankTransaction>> GetAllBankTransactions();
        Task<BankTransaction> GetBankTransactionById(Guid id);
        Task AddBankTransaction(BankTransaction bankTransaction);
        Task UpdateBankTransaction(BankTransaction updatedBankTransaction);
        Task DeleteBankTransaction(BankTransaction bankTransactionToDelete);
        Task<List<BankTransaction>> GetAllBankTransactionsByBankAccount(Guid bankAccountId);
        Task<List<BankTransaction>> GetBankTransactionByAccountId(Guid bankAccountId);


    }
}
