using AutoMapper;
using BankingSystem.DataBase.Models;
using BankingSystem.Repository.Repository.IRepository;
using BankingSystem.Services.IServices;
using BankingSystem.Business.ViewModels;
using System.Net;


namespace BankingSystem.Services.Services

{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepo accountRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountTypeService(IAccountTypeRepo accountRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<JsonResponseModel<List<AccountTypeView>>> GetAllAccountTypes()
        {
            var response = new JsonResponseModel<List<AccountTypeView>>();
            try
            {
                List<DataBase.Models.AccountType> accountTypes = await accountRepository.GetAllAccountTypes();
                response.Result = mapper.Map<List<Business.ViewModels.AccountTypeView>>(accountTypes);
                response.Message = "List of AccountType";
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


        public async Task<JsonResponseModel<AccountTypeView>> GetAccountType(Guid id)
        {
            var response = new JsonResponseModel<AccountTypeView>();
            try
            {
                DataBase.Models.AccountType accountType = await accountRepository.GetAccountTypeById(id);
                response.Result = mapper.Map<AccountTypeView>(accountType);
                response.Message = "Details of AccountType";
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

        public async Task<JsonResponseModel<bool>> UpdateAccountType(Guid id, DataBase.Models.AccountType updatedAccountType)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var existingAccountType = await accountRepository.GetAccountTypeById(id);
                if (existingAccountType == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    existingAccountType.Name = updatedAccountType.Name;
                    await accountRepository.UpdateAccountType(existingAccountType);
                    await unitOfWork.SaveChangesAsync();
                    response.Result = true;
                    response.Message = "Account type updated successfully";
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


        public async Task<JsonResponseModel<bool>> DeleteAccountType(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var accountTypeToDelete = await accountRepository.GetAccountTypeById(id);
                if (accountTypeToDelete == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    await accountRepository.DeleteAccountType(accountTypeToDelete);
                    await unitOfWork.SaveChangesAsync();
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
