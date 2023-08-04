using Microsoft.EntityFrameworkCore;
using BankingSystem.Models;

namespace BankingSystem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<BankAccountPosting> BankAccountPostings { get; set; }


        // applying seed data to the database as part of migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.AccountType.Liability.ToString()
                },
                 new AccountType
                 {
                     Id = Guid.NewGuid(),
                     Name = EnumConstant.EnumConstant.AccountType.Asset.ToString()
                 }

            );
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.PaymentType.Cash.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.PaymentType.Cheque.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.PaymentType.NEFT.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.PaymentType.RTGS.ToString()
                },
                new PaymentMethod
                {
                    Id = Guid.NewGuid(),
                    Name = EnumConstant.EnumConstant.PaymentType.Other.ToString()
                }
             );
        }
    }

}
