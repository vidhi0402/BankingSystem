using BankingSystem.DataBase;
using BankingSystem.DataBase.Models;
using BankingSystem.Repository.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository.Repository
{
    public class BankAccountPostingRepo : IBankAccountPostingRepo
    {
        private readonly ApplicationDbContext dbContext;

        public BankAccountPostingRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<BankAccountPosting>> GetAllBankAccountPostings()
        {
            List<BankAccountPosting> result = await dbContext.BankAccountPostings.ToListAsync();
            return result;
        }
        public async Task<BankAccountPosting> GetBankAccountPostingById(Guid id)
        {
            return await dbContext.BankAccountPostings.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddBankAccountPosting(BankAccountPosting bankAccountPosting)
        {
            await dbContext.BankAccountPostings.AddAsync(bankAccountPosting);
        }
        public async Task DeleteBankAccountPosting(BankAccountPosting bankAccountPostingToDelete)
        {
            dbContext.BankAccountPostings.Remove(bankAccountPostingToDelete);       
        }
    }
}
