using AutoMapper;
using BankingSystem.IRepository;
using BankingSystem.Models;
using BankingSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
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
            await dbContext.SaveChangesAsync();
        }       
        public async Task DeleteBankAccountPosting(BankAccountPosting bankAccountPostingToDelete)
        {
            dbContext.BankAccountPostings.Remove(bankAccountPostingToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
