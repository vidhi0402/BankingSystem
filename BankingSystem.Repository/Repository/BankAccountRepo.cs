using BankingSystem.DataBase;
using BankingSystem.DataBase.Models;
using BankingSystem.Repository.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository.Repository
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private readonly ApplicationDbContext dbContext;

        public BankAccountRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<BankAccount>> GetAllBankAccounts()
        {
            List<BankAccount> result = await dbContext.BankAccounts.ToListAsync();
            return result;
        }

        public async Task<BankAccount> GetBankAccountById(Guid id)
        {
            return await dbContext.BankAccounts.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddBankAccount(BankAccount bankAccount)
        {
            await dbContext.BankAccounts.AddAsync(bankAccount);
        }
        public async Task UpdateBankAccount(BankAccount updatedBankAccount)
        {
            var existingBankAccount = await dbContext.BankAccounts.FirstOrDefaultAsync(b => b.Id == updatedBankAccount.Id);
            if (existingBankAccount != null)
            {
                existingBankAccount.FirstName = updatedBankAccount.FirstName;
                existingBankAccount.MiddleName = updatedBankAccount.MiddleName;
                existingBankAccount.LastName = updatedBankAccount.LastName;
                existingBankAccount.AccountNumber = updatedBankAccount.AccountNumber;
                existingBankAccount.OpeningDate = updatedBankAccount.OpeningDate;
                existingBankAccount.ClosingDate = updatedBankAccount.ClosingDate;
                existingBankAccount.AccountType_FK = updatedBankAccount.AccountType_FK;
            }
        }
        public async Task DeleteBankAccount(BankAccount bankAccountToDelete)
        {
            dbContext.BankAccounts.Remove(bankAccountToDelete);
        }
    }
}
