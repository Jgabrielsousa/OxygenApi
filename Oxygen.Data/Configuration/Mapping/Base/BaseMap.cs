using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxygen.Domain.Entities.Base;

namespace Oxygen.Data.Configuration.Mapping.Base
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : EntityBase<T>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        }
    }
}
