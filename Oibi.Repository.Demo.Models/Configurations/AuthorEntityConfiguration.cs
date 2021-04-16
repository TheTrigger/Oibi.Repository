﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oibi.Repository.Extensions;

namespace Oibi.Repository.Demo.Models.Configurations
{
	public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.UseAutoGeneratedId();
			builder.UseTimestampedProperty();

			builder.HasMany(s => s.Books).WithMany(s => s.Authors);
		}
	}
}