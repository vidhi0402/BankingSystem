using BankingSystem.Business.EnumConstant;
using BankingSystem.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.DataBase
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasData(
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.AccountType.Liability.ToString()
                },
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.AccountType.Asset.ToString()
                }
            );
        }
    }

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.PaymentType.Cash.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.PaymentType.Cheque.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.PaymentType.NEFT.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.PaymentType.RTGS.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.PaymentType.Other.ToString()
                }
            );
        }
    }
}
