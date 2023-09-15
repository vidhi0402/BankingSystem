using AutoMapper;
using BankingSystem.DataBase;
using BankingSystem.DataBase.Models;
using BankingSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private readonly ApplicationDbContext dbContext;

        public AccountTypeRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<AccountType>> GetAllAccountTypes()
        {
            List<AccountType> result = await dbContext.AccountTypes.ToListAsync();
            return result;
        }

        public async Task<AccountType> GetAccountTypeById(Guid id)
        {
            return await dbContext.AccountTypes.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAccountType(AccountType accountType)
        {
            await dbContext.AccountTypes.AddAsync(accountType);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateAccountType(AccountType updatedAccountType)
        {
            var existingAccountType = await dbContext.AccountTypes.FirstOrDefaultAsync(a => a.Id == updatedAccountType.Id);
            if (existingAccountType != null)
            {
                existingAccountType.Name = updatedAccountType.Name;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAccountType(AccountType accountTypeToDelete)
        {
            dbContext.AccountTypes.Remove(accountTypeToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
