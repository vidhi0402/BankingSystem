using AutoMapper;
using BankingSystem.IRepository;
using BankingSystem.IServices;
using BankingSystem.Models;
using BankingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static BankingSystem.EnumConstant.EnumConstant;
using System.Net;

namespace BankingSystem.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepo paymentRepository;
        private readonly IMapper mapper;

        public PaymentMethodService(IPaymentMethodRepo paymentRepository, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        public async Task<JsonResponseModel<List<PaymentMethodView>>> GetAllPaymentMethods()
        {
            var response = new JsonResponseModel<List<PaymentMethodView>>();
            try
            {
                List<Models.PaymentMethod> paymentMethods = await paymentRepository.GetAllPaymentMethods();
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
                Models.PaymentMethod paymentMethod = await paymentRepository.GetPaymentMethodById(id);
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
