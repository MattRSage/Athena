using Athena.Stocks.Domain.StockExchanges;
using Athena.Stocks.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Stocks.Infrastructure.Domain.Stocks
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", "stocks");

            builder.HasKey(x => x.Id);
            builder.Property<StockExchangeId>("_stockExchangeId").HasColumnName("StockExchangeId");
            builder.Property<string>("_symbol").HasColumnName("Symbol").HasMaxLength(10).IsRequired();
            builder.Property<string>("_companyName").HasColumnName("CompanyName").HasMaxLength(250);
            builder.Property<decimal>("_forwardPeRatio").HasColumnName("ForwardPeRatio");

            builder.OwnsOne<MoneyValue>("_marketCap", b =>
            {
                b.Property(p => p.Value).HasColumnName("MarketCapValue");
                b.Property(p => p.Currency).HasColumnName("MarketCapCurrency").HasMaxLength(3);
            });

            builder.OwnsOne<MoneyValue>("_totalRevenue", b =>
            {
                b.Property(p => p.Value).HasColumnName("TotalRevenueValue");
                b.Property(p => p.Currency).HasColumnName("TotalRevenueCurrency").HasMaxLength(3);
            });

            builder.HasOne<StockExchange>().WithMany().HasForeignKey("_stockExchangeId").IsRequired();
        }
    }
}