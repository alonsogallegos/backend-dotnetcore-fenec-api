﻿using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name)
				   .IsRequired()
				   .HasMaxLength(100);

			builder.HasMany(c => c.Products)
				   .WithOne(p => p.Category)
				   .HasForeignKey(p => p.CategoryId);
		}
	}
}
