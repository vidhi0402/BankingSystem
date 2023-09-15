using BankingSystem.DataBase.Models;

namespace BankingSystem.IRepository
{
    public interface IBankAccountPostingRepo
    {
        Task<List<BankAccountPosting>> GetAllBankAccountPostings();
        Task<BankAccountPosting> GetBankAccountPostingById(Guid id);
        Task AddBankAccountPosting(BankAccountPosting bankAccountPosting);
        Task DeleteBankAccountPosting(BankAccountPosting bankAccountPostingToDelete);

    }
}
