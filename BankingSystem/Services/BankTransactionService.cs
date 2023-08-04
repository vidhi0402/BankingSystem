using AutoMapper;
using BankingSystem.IRepository;
using BankingSystem.IServices;
using BankingSystem.Models;
using BankingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using static BankingSystem.EnumConstant.EnumConstant;

namespace BankingSystem.Services
{
    public class BankTransactionService : IBankTransactionService
    {
        private readonly IBankTransactionRepo bankTransactionRepository;
        private readonly IBankAccountPostingRepo bankAccountPostingRepo;
        private readonly IBankAccountRepo bankAccountRepo;
        private readonly IMapper mapper;

        public BankTransactionService(IBankTransactionRepo bankTransactionRepository, IBankAccountPostingRepo bankAccountPostingRepo, IBankAccountRepo bankAccountRepo, IMapper mapper)
        {
            this.bankTransactionRepository = bankTransactionRepository;
            this.bankAccountPostingRepo = bankAccountPostingRepo;
            this.bankAccountRepo = bankAccountRepo;
            this.mapper = mapper;
        }
        public async Task<JsonResponseModel<List<BankTransactionView>>> GetAllBankTransactions()
        {
            var response = new JsonResponseModel<List<BankTransactionView>>();
            try
            {
                List<BankTransaction> bankTransactions = await bankTransactionRepository.GetAllBankTransactions();
                response.Result = mapper.Map<List<BankTransactionView>>(bankTransactions);
                response.Message = "List of BankTransaction";
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

        public async Task<JsonResponseModel<BankTransactionView>> GetBankTransaction(Guid id)
        {
            var response = new JsonResponseModel<BankTransactionView>();
            try
            {                
                var bankTransaction = await bankTransactionRepository.GetBankTransactionById(id);
                response.Result = mapper.Map<BankTransactionView>(bankTransaction);
                response.Message = "Details of BankTransaction";
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

        public async Task<JsonResponseModel<List<BankTransactionView>>> GenerateBankTransactions(int numberOfTransactions, List<BankAccountView> bankAccounts, List<PaymentMethodView> paymentMethods)
        {
            var response = new JsonResponseModel<List<BankTransactionView>>();
            try
            {
                var bankTransactions = new List<BankTransaction>();
                var random = new Random();
                var categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

                foreach (var bankAccount in bankAccounts)
                {
                    BankAccount bankAccountData = await bankAccountRepo.GetBankAccountById(bankAccount.Id);
                    for (int i = 0; i < numberOfTransactions; i++)
                    {
                        var paymentMethod = paymentMethods[random.Next(paymentMethods.Count)];
                        // Generate a random transaction amount (credit or debit)
                        var amount = (decimal)random.NextDouble() * random.Next(1, 1000000);
                        TransactionType transactionType = (TransactionType)random.Next(0, 2);
                        if (transactionType == TransactionType.Debit)
                        {
                            decimal totalBalance = await checkbalance(bankAccountData.Id);
                            if (amount >= totalBalance)
                            {
                                continue;
                            }
                        }
                        var bankTransaction = new BankTransaction
                        {
                            Id = Guid.NewGuid(),
                            TransactionType = transactionType,
                            Category = categories[random.Next(categories.Count)],
                            Amount = amount,
                            TransactionDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                            PaymentMethod_FK = paymentMethod.Id,
                            BankAccount_FK = bankAccount.Id
                        };

                        await bankTransactionRepository.AddBankTransaction(bankTransaction);
                        bankTransactions.Add(bankTransaction);

                        if (bankTransaction.Category == Category.BankInterest || bankTransaction.Category == Category.BankCharges)
                        {
                            var bankAccountPosting = new BankAccountPosting
                            {
                                Id = Guid.NewGuid(),
                                BankTransationId_FK = bankTransaction.Id
                            };
                            await bankAccountPostingRepo.AddBankAccountPosting(bankAccountPosting);
                        }
                    }

                }
                response.Result = mapper.Map<List<BankTransactionView>>(bankTransactions);
                response.Message = "BankAccount Transactions generated successfully";
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
        private async Task<decimal> checkbalance(Guid id)
        {
            var allTransactions = (await bankTransactionRepository.GetAllBankTransactionsByBankAccount(id));
            decimal totalBalance = 0;
            foreach (var transaction in allTransactions)
            {
                if (transaction.TransactionType == TransactionType.Credit)
                {
                    totalBalance += transaction.Amount;
                }
                else if (transaction.TransactionType == TransactionType.Debit)
                {
                    totalBalance -= transaction.Amount;
                }
            }
            return totalBalance;
        }

        public async Task<JsonResponseModel<bool>> UpdateBankTransaction(Guid id, BankTransaction updatedBankTransaction)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var existingBankTransaction = await bankTransactionRepository.GetBankTransactionById(id);
                if (existingBankTransaction == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    // Update the properties of the existing BankTransaction
                    existingBankTransaction.TransactionType = updatedBankTransaction.TransactionType;
                    existingBankTransaction.Category = updatedBankTransaction.Category;
                    existingBankTransaction.Amount = updatedBankTransaction.Amount;
                    existingBankTransaction.TransactionDate = updatedBankTransaction.TransactionDate;
                    existingBankTransaction.PaymentMethod_FK = updatedBankTransaction.PaymentMethod_FK;
                    existingBankTransaction.BankAccount_FK = updatedBankTransaction.BankAccount_FK;

                    await bankTransactionRepository.UpdateBankTransaction(existingBankTransaction);
                    response.Result = true;
                    response.Message = "Account Transaction updated successfully";
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

        public async Task<JsonResponseModel<bool>> DeleteBankTransaction(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var bankTransactionToDelete = await bankTransactionRepository.GetBankTransactionById(id);
                if (bankTransactionToDelete == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    await bankTransactionRepository.DeleteBankTransaction(bankTransactionToDelete);
                    response.Result = true;
                    response.Message = "Account Transaction deleted successfully";
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
