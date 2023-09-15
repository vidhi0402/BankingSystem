using AutoMapper;
using BankingSystem.Business.ViewModels;
using BankingSystem.DataBase.Models;

namespace BankingSystem.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IdEntityBase, IdEntityBaseView>().ReverseMap();
            CreateMap<NameEntityBase, NameEntityBaseView>().ReverseMap();
            CreateMap<AccountType, AccountTypeView>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodView>().ReverseMap();
            CreateMap<BankAccount, BankAccountView>().ReverseMap();
            CreateMap<BankTransaction, BankTransactionView>().ReverseMap();
            CreateMap<BankAccountPosting, BankAccountPostingView>().ReverseMap();
        }
    }
}
