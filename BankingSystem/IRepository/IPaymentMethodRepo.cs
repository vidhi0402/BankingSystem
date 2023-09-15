using BankingSystem.DataBase.Models;

namespace BankingSystem.IRepository
{
    public interface IPaymentMethodRepo
    {
        Task<List<PaymentMethod>> GetAllPaymentMethods();
        Task<PaymentMethod> GetPaymentMethodById(Guid id);
        Task AddPaymentMethod(PaymentMethod paymentMethod);
        Task UpdatePaymentMethod(PaymentMethod updatedPaymentMethod);
        Task DeletePaymentMethod(PaymentMethod paymentMethodToDelete);

    }
}
