using Athena.BuildingBlocks.Domain.ValueObjects;

namespace Athena.Stocks.Domain.Stocks
{
    public class MoneyValue : ValueObject
    {
        public decimal? Value { get; }

        public string Currency { get; }

        public static MoneyValue Of(decimal value, string currency)
        {
            return new MoneyValue(value, currency);
        }

        private MoneyValue(decimal? value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public static MoneyValue operator *(int left, MoneyValue right)
        {
            return new MoneyValue(right.Value * left, right.Currency);
        }
    }
}