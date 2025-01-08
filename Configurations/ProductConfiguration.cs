﻿using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name)
				   .IsRequired()
				   .HasMaxLength(150);
			builder.Property(p => p.Description)
				   .HasMaxLength(500);
			builder.Property(p => p.Price)
				   .IsRequired()
				   .HasColumnType("decimal(18,2)");
			builder.Property(p => p.Stock)
				   .IsRequired();

			builder.HasOne(p => p.Category)
				   .WithMany(c => c.Products)
				   .HasForeignKey(p => p.CategoryId);
		}
	}
}