using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.IServices
{
    public interface IBankTransactionService
    {
        Task<JsonResponseModel<List<BankTransactionView>>> GetAllBankTransactions();
        Task<JsonResponseModel<BankTransactionView>> GetBankTransaction(Guid id);
        Task<JsonResponseModel<List<BankTransactionView>>> GenerateBankTransactions(int numberOfTransactions, List<BankAccountView> bankAccounts, List<PaymentMethodView> paymentMethods);
        Task<JsonResponseModel<bool>> UpdateBankTransaction(Guid id, BankTransaction updatedBankTransaction);
        Task<JsonResponseModel<bool>> DeleteBankTransaction(Guid id);

    }
}
