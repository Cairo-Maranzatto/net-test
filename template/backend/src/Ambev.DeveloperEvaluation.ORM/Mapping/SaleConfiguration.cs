using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.CustomerId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.BranchId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.BranchName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.TotalAmount)
                .HasPrecision(18, 2);

            builder.Property(s => s.IsCancelled)
                .IsRequired();

            builder.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey("SaleId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 