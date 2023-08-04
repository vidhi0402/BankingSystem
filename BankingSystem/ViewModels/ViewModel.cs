using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BankingSystem.EnumConstant.EnumConstant;

namespace BankingSystem.ViewModels
{
    public class ViewBaseClassForId
    {
        public Guid Id { get; set; }
    }
    public class ViewBaseClassForName : ViewBaseClassForId
    {
        public string Name { get; set; }
    }
    // AccountTypeView.cs
    public class AccountTypeView : ViewBaseClassForName
    { }

    // PaymentMethodView.cs
    public class PaymentMethodView : ViewBaseClassForName
    { }

    // BankAccountView.cs
    public class BankAccountView : ViewBaseClassForId
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public Guid AccountType_FK { get; set; }
        public decimal TotalBalance { get; set; }
    }

    // BankTransactionView.cs
    public class BankTransactionView : ViewBaseClassForId
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
    public class BankAccountPostingView : ViewBaseClassForId
    {
        public Guid BankTransationId_FK { get; set; }
    }

}

