using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BankingSystem.EnumConstant.EnumConstant;

namespace BankingSystem.Models
{
    public class BaseClassForId
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class BaseClassForName : BaseClassForId
    { 
        public string Name { get; set; }
    }
    // AccountType.cs
    public class AccountType : BaseClassForName
    { }

    // PaymentMethod.cs
    public class PaymentMethod : BaseClassForName
    { }

    // BankAccount.cs
    public class BankAccount : BaseClassForId
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$")]
        public string AccountNumber { get; set; }

        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        [ForeignKey("AccountType")]
        public Guid AccountType_FK { get; set; }
        public AccountType AccountType { get; set; }

        [NotMapped]
        public decimal TotalBalance { get; set; }
    }

    // BankTransaction.cs
    public class BankTransaction : BaseClassForId
    {
        public TransactionType TransactionType { get; set; }
        public Category Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        [ForeignKey("PaymentMethod")]
        public Guid PaymentMethod_FK { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("BankAccount")]
        public Guid BankAccount_FK { get; set; }
        public BankAccount BankAccount { get; set; }
    }

    // BankAccountPosting.cs
    public class BankAccountPosting : BaseClassForId
    {
        [ForeignKey("BankTransaction")]
        public Guid BankTransationId_FK { get; set; }
        public BankTransaction BankTransaction { get; set; }
    }

}

