namespace BankingSystem.EnumConstant
{
    public class EnumConstant
    {
        public enum AccountType
        {
            Liability,
            Asset
        }
        public enum PaymentType
        {
            Cash,
            Cheque,
            NEFT,
            RTGS,
            Other
        }
        public enum TransactionType
        {
            Credit,
            Debit
        }
        public enum Category
        {
            OpeningBalance,
            BankInterest,
            BankCharges,
            NormalTransactions
        }

    }
}
