using Athena.Stocks.Domain.StockExchanges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Stocks.Infrastructure.EntityConfigurations
{
    public class StockExchangeEntityConfiguration : IEntityTypeConfiguration<StockExchange>
    {
        public void Configure(EntityTypeBuilder<StockExchange> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            
            builder.Ignore(x => x.DomainEvents);
        }
    }
}