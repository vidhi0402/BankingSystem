using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BankingSystem.Business.EnumConstant.EnumConstant;

namespace BankingSystem.Business.ViewModels
{
    public class IdEntityBaseView
    {
        public Guid Id { get; set; }
    }
    public class NameEntityBaseView : IdEntityBaseView
    {
        public string Name { get; set; }
    }

    public class PersonEntityView : IdEntityBaseView
    { 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    // AccountTypeView.cs
    public class AccountTypeView : NameEntityBaseView
    { }

    // PaymentMethodView.cs
    public class PaymentMethodView : NameEntityBaseView
    { }

    // BankAccountView.cs
    public class BankAccountView : PersonEntityView
    {
        public string AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public Guid AccountType_FK { get; set; }
        public decimal TotalBalance { get; set; }
    }

    // BankTransactionView.cs
    public class BankTransactionView : PersonEntityView
    {
        public TransactionType TransactionType { get; set; }
        public Category Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid PaymentMethod_FK { get; set; }
        public Guid BankAccount_FK { get; set; }
    }

    // BankAccountPostingView.cs
    public class BankAccountPostingView : IdEntityBaseView
    {
        public Guid BankTransationId_FK { get; set; }
    }

}

