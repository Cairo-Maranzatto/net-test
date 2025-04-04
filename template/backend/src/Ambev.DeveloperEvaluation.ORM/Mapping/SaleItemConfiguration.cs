using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(i => i.Discount)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(i => i.TotalAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(i => i.IsCancelled)
                .IsRequired();

            builder.HasOne<Sale>()
                .WithMany(s => s.Items)
                .HasForeignKey("SaleId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 