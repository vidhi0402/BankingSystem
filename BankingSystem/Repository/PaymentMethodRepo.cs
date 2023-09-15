using BankingSystem.DataBase;
using BankingSystem.DataBase.Models;
using BankingSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repository
{
    public class PaymentMethodRepo : IPaymentMethodRepo
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentMethodRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethods()
        {
            List<PaymentMethod> result = await dbContext.PaymentMethods.ToListAsync();
            return result;
        }

        public async Task<PaymentMethod> GetPaymentMethodById(Guid id)
        {
            return await dbContext.PaymentMethods.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddPaymentMethod(PaymentMethod paymentMethod)
        {
            await dbContext.PaymentMethods.AddAsync(paymentMethod);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdatePaymentMethod(PaymentMethod updatedPaymentMethod)
        {
            var existingPaymentMethod = await dbContext.PaymentMethods.FirstOrDefaultAsync(p => p.Id == updatedPaymentMethod.Id);
            if (existingPaymentMethod != null)
            {
                existingPaymentMethod.Name = updatedPaymentMethod.Name;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentMethod(PaymentMethod paymentMethodToDelete)
        {
            dbContext.PaymentMethods.Remove(paymentMethodToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
