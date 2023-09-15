using BankingSystem.DataBase.Models;

namespace BankingSystem.Repository.Repository.IRepository
{
    public interface IBankAccountPostingRepo
    {
        Task<List<BankAccountPosting>> GetAllBankAccountPostings();
        Task<BankAccountPosting> GetBankAccountPostingById(Guid id);
        Task AddBankAccountPosting(BankAccountPosting bankAccountPosting);
        Task DeleteBankAccountPosting(BankAccountPosting bankAccountPostingToDelete);

    }
}
