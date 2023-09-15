using BankingSystem.DataBase;
using BankingSystem.DataBase.Models;
using BankingSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class BankTransactionRepo : IBankTransactionRepo
    {
        private readonly ApplicationDbContext dbContext;

        public BankTransactionRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BankTransaction>> GetAllBankTransactions()
        {
            List<BankTransaction> result = await dbContext.BankTransactions.ToListAsync();
            return result;
        }
        public async Task<List<BankTransaction>> GetAllBankTransactionsByBankAccount(Guid bankAccountId)
        {
            return await dbContext.BankTransactions.Where(t => t.BankAccount_FK == bankAccountId).ToListAsync();
        }
        public async Task<BankTransaction> GetBankTransactionById(Guid id)
        {
            return await dbContext.BankTransactions.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddBankTransaction(BankTransaction bankTransaction)
        {
            await dbContext.BankTransactions.AddAsync(bankTransaction);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateBankTransaction(BankTransaction updatedBankTransaction)
        {
            var existingBankTransaction = await dbContext.BankTransactions.FirstOrDefaultAsync(b => b.Id == updatedBankTransaction.Id);
            if (existingBankTransaction != null)
            {
                existingBankTransaction.TransactionType = updatedBankTransaction.TransactionType;
                existingBankTransaction.Category = updatedBankTransaction.Category;
                existingBankTransaction.Amount = updatedBankTransaction.Amount;
                existingBankTransaction.TransactionDate = updatedBankTransaction.TransactionDate;
                existingBankTransaction.PaymentMethod_FK = updatedBankTransaction.PaymentMethod_FK;
                existingBankTransaction.BankAccount_FK = updatedBankTransaction.BankAccount_FK;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteBankTransaction(BankTransaction bankTransactionToDelete)
        {
            dbContext.BankTransactions.Remove(bankTransactionToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
