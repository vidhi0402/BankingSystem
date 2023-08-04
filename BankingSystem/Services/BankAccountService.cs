using AutoMapper;
using BankingSystem.IRepository;
using BankingSystem.IServices;
using BankingSystem.Models;
using BankingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankingSystem.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepo bankAccountRepository;
        private readonly IMapper mapper;

        public BankAccountService(IBankAccountRepo bankAccountRepository, IMapper mapper)
        {
            this.bankAccountRepository = bankAccountRepository;
            this.mapper = mapper;
        }
        public async Task<JsonResponseModel<List<BankAccountView>>> GetAllBankAccounts()
        {
            var response = new JsonResponseModel<List<BankAccountView>>();
            try
            {
                List<BankAccount> bankAccounts = await bankAccountRepository.GetAllBankAccounts();
                response.Result = mapper.Map<List<BankAccountView>>(bankAccounts);
                response.Message = "List of Accounts";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public async Task<JsonResponseModel<BankAccountView>> GetBankAccount(Guid id)
        {
            var response = new JsonResponseModel<BankAccountView>();
            try
            {
                var bankAccount = await bankAccountRepository.GetBankAccountById(id);
                response.Result = mapper.Map<BankAccountView>(bankAccount);
                response.Message = "Details of BankAccount";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<JsonResponseModel<List<BankAccountView>>> GenerateBankAccounts(int numberOfAccounts, List<AccountTypeView> accountTypes)
        {
            var response = new JsonResponseModel<List<BankAccountView>>();
            try
            {
                var bankAccounts = new List<BankAccount>();
                var random = new Random();
                for (int i = 0; i < numberOfAccounts; i++)
                {
                    var accountType = accountTypes[random.Next(accountTypes.Count)];

                    var bankAccount = new BankAccount
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Vidhi" + i,
                        MiddleName = "MiddleName" + i,
                        LastName = "Mehta" + i,
                        AccountNumber = random.Next(10000000, 99999999).ToString(),
                        OpeningDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                        ClosingDate = random.Next(0, 10) < 2 ? (DateTime?)DateTime.Now.AddDays(random.Next(1, 365)) : null,
                        AccountType_FK = accountType.Id
                    };
                    await bankAccountRepository.AddBankAccount(bankAccount);
                    bankAccounts.Add(bankAccount);
                }
                response.Result = mapper.Map<List<BankAccountView>>(bankAccounts);
                response.Message = "BankAccounts generated successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;

        }

        public async Task<JsonResponseModel<bool>> UpdateBankAccount(Guid id, BankAccount updatedBankAccount)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var existingBankAccount = await bankAccountRepository.GetBankAccountById(id);
                if (existingBankAccount == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    // Update the properties of the existing BankAccount
                    existingBankAccount.FirstName = updatedBankAccount.FirstName;
                    existingBankAccount.MiddleName = updatedBankAccount.MiddleName;
                    existingBankAccount.LastName = updatedBankAccount.LastName;
                    existingBankAccount.AccountNumber = updatedBankAccount.AccountNumber;
                    existingBankAccount.OpeningDate = updatedBankAccount.OpeningDate;
                    existingBankAccount.ClosingDate = updatedBankAccount.ClosingDate;
                    existingBankAccount.AccountType_FK = updatedBankAccount.AccountType_FK;
                    await bankAccountRepository.UpdateBankAccount(existingBankAccount);
                    response.Result = true;
                    response.Message = "Account updated successfully";
                    response.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public async Task<JsonResponseModel<bool>> DeleteBankAccount(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var bankAccountToDelete = await bankAccountRepository.GetBankAccountById(id);
                if (bankAccountToDelete == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    await bankAccountRepository.DeleteBankAccount(bankAccountToDelete);
                    response.Result = true;
                    response.Message = "Account deleted successfully";
                    response.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
