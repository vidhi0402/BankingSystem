using Microsoft.EntityFrameworkCore;
using BankingSystem.DataBase.Models;
using BankingSystem.Business.EnumConstant;

namespace BankingSystem.DataBase
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
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
        }
    }

}
