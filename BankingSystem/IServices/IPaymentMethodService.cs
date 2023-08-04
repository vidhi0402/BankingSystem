﻿using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.IServices
{
    public interface IPaymentMethodService
    {
        Task<JsonResponseModel<List<PaymentMethodView>>> GetAllPaymentMethods();
        Task<JsonResponseModel<PaymentMethodView>> GetPaymentMethod(Guid id);
        Task<JsonResponseModel<bool>> UpdatePaymentMethod(Guid id, PaymentMethod updatedPaymentMethod);
        Task<JsonResponseModel<bool>> DeletePaymentMethod(Guid id);

    }
}
