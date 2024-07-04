﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using F2.Repository.Extensions;

namespace F2.Repository.Demo.Models.Configurations;

public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.UseAutoGeneratedId();
		builder.UseTimestampedProperty();

        builder.HasMany(a => a.Books).WithMany(b => b.Authors);

        // There are no triggered ValueGenerator at migration step, no way ...
        //builder.HasData(new Author { Id = Guid.NewGuid(), Name = "From Seeding", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
    }
}