using AutoMapper;
using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;
using BankingSystem.Repository.Repository.IRepository;
using BankingSystem.Services.IServices;
using System.Net;

namespace BankingSystem.Services.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepo paymentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentMethodService(IPaymentMethodRepo paymentRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<JsonResponseModel<List<PaymentMethodView>>> GetAllPaymentMethods()
        {
            var response = new JsonResponseModel<List<PaymentMethodView>>();
            try
            {
                List<DataBase.Models.PaymentMethod> paymentMethods = await paymentRepository.GetAllPaymentMethods();
                response.Result = mapper.Map<List<PaymentMethodView>>(paymentMethods);
                response.Message = "List of PaymentMethods";
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

        public async Task<JsonResponseModel<PaymentMethodView>> GetPaymentMethod(Guid id)
        {
            var response = new JsonResponseModel<PaymentMethodView>();
            try
            {
                DataBase.Models.PaymentMethod paymentMethod = await paymentRepository.GetPaymentMethodById(id);
                response.Result = mapper.Map<PaymentMethodView>(paymentMethod);
                response.Message = "Details of Payment";
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
        public async Task<JsonResponseModel<bool>> UpdatePaymentMethod(Guid id, PaymentMethod updatedPaymentMethod)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var existingPaymentMethod = await paymentRepository.GetPaymentMethodById(id);
                if (existingPaymentMethod == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    existingPaymentMethod.Name = updatedPaymentMethod.Name;
                    await paymentRepository.UpdatePaymentMethod(existingPaymentMethod);
                    await unitOfWork.SaveChangesAsync();
                    response.Result = true;
                    response.Message = "Payment type updated successfully";
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

        public async Task<JsonResponseModel<bool>> DeletePaymentMethod(Guid id)
        {
            var response = new JsonResponseModel<bool>();
            try
            {
                var paymentMethodToDelete = await paymentRepository.GetPaymentMethodById(id);
                if (paymentMethodToDelete == null)
                {
                    response.Result = false;
                    response.Message = "No account found";
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                await paymentRepository.DeletePaymentMethod(paymentMethodToDelete);
                await unitOfWork.SaveChangesAsync();
                response.Result = true;
                response.Message = "Payment type deleted successfully";
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
    }
}
