using AutoMapper;
using BankingSystem.Models;
using BankingSystem.ViewModels;

namespace BankingSystem.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BaseClassForId, ViewBaseClassForId>().ReverseMap();
            CreateMap<BaseClassForName, ViewBaseClassForName>().ReverseMap();
            CreateMap<AccountType, AccountTypeView>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodView>().ReverseMap();
            CreateMap<BankAccount, BankAccountView>().ReverseMap();
            CreateMap<BankTransaction, BankTransactionView>().ReverseMap();
            CreateMap<BankAccountPosting, BankAccountPostingView>().ReverseMap();
        }
    }
}
