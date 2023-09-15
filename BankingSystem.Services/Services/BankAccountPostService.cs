using AutoMapper;
using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;
using BankingSystem.Repository.Repository.IRepository;
using BankingSystem.Services.IServices;
using System.Net;

namespace BankingSystem.Services.Services
{
    public class BankAccountPostService : IBankAccountPostingService
    {
        private readonly IBankAccountPostingRepo bankAccountPostingRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BankAccountPostService(IBankAccountPostingRepo bankAccountPostingRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.bankAccountPostingRepository = bankAccountPostingRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<JsonResponseModel<List<BankAccountPostingView>>> GetAllBankAccountPostings()
        {
            var response = new JsonResponseModel<List<BankAccountPostingView>>();
            try
            {
                List<BankAccountPosting> bankAccountPostings = await bankAccountPostingRepository.GetAllBankAccountPostings();
                response.Result = mapper.Map<List<BankAccountPostingView>>(bankAccountPostings);
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

        public async Task<JsonResponseModel<BankAccountPostingView>> GetBankAccountPosting(Guid id)
        {
            var response = new JsonResponseModel<BankAccountPostingView>();
            try
            {
                var bankAccountPosting = await bankAccountPostingRepository.GetBankAccountPostingById(id);
                response.Result = mapper.Map<BankAccountPostingView>(bankAccountPosting);
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
        public async Task<JsonResponseModel<bool>> DeleteBankAccountPosting(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var bankAccountPostingToDelete = await bankAccountPostingRepository.GetBankAccountPostingById(id);
                if (bankAccountPostingToDelete == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    await bankAccountPostingRepository.DeleteBankAccountPosting(bankAccountPostingToDelete);
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
