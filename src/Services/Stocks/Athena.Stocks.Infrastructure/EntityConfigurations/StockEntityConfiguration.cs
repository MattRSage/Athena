using Athena.Stocks.Domain.StockExchanges;
using Athena.Stocks.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Stocks.Infrastructure.EntityConfigurations
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Symbol).HasMaxLength(10).IsRequired();
            builder.Property(x => x.CompanyName).HasMaxLength(250);
            builder.OwnsOne(x => x.MarketCap).Property(x => x.Value).HasColumnName("MarketCapValue");
            builder.OwnsOne(x => x.MarketCap).Property(x => x.Currency).HasColumnName("MarketCapCurrency");
            builder.OwnsOne(x => x.TotalRevenue).Property(x => x.Value).HasColumnName("TotalRevenueValue");
            builder.OwnsOne(x => x.TotalRevenue).Property(x => x.Currency).HasColumnName("TotalRevenueCurrency");
            builder.HasOne<StockExchange>().WithMany().HasForeignKey("StockExchangeId").IsRequired();
            builder.Property(x => x.ForwardPeRatio);
            
            builder.Ignore(x => x.DomainEvents);
        }
    }
}