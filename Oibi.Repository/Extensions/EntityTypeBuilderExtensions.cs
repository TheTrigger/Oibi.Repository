﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oibi.Repository.Interfaces;
using Oibi.Repository.ValueGenerator;
using System;

namespace Oibi.Repository.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, ITimestampedEntity
    {
        entity.Property(d => d.CreatedAt).HasValueGenerator<DateTimeOffsetValueGenerator>().HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        entity.Property(d => d.UpdatedAt).HasValueGenerator<DateTimeOffsetValueGenerator>().HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();

        return entity;
    }

    public static EntityTypeBuilder<TEntity> UseAutoGeneratedId<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, IEntity<Guid>
    {
        entity.Property(d => d.Id).HasValueGenerator<SecureGuidValueGenerator>().ValueGeneratedOnAdd();

        return entity;
    }
}