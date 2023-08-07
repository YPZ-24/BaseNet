using IntranetCorrespondencia.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntranetCorrespondencia.Repository.EFCore.Configurations.Base
{
    public abstract class EntityBaseConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt)
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            builder.Property(x => x.CreatedAt)
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt)
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            builder.Property(x => x.UpdatedAt)
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

        }
    }
}
