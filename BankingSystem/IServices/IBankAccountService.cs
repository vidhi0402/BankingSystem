﻿using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.IServices
{
    public interface IBankAccountService
    {
        Task<JsonResponseModel<List<BankAccountView>>> GetAllBankAccounts();
        Task<JsonResponseModel<BankAccountView>> GetBankAccount(Guid id);
        Task<JsonResponseModel<List<BankAccountView>>> GenerateBankAccounts(int numberOfAccounts, List<AccountTypeView> accountTypes);
        Task<JsonResponseModel<bool>> UpdateBankAccount(Guid id, BankAccount updatedBankAccount);
        Task<JsonResponseModel<bool>> DeleteBankAccount(Guid id);
    }
}
