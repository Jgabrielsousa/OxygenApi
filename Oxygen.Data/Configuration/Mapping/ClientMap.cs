using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxygen.Data.Configuration.Mapping.Base;
using Oxygen.Domain.Entities;
using System;

namespace Oxygen.Data.Configuration.Mapping
{
    public class ClientMap : BaseMap<Client>, IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(80)
            .IsUnicode(false);

            builder.Property(e => e.Idade)
           .HasColumnName("Idade")
           .HasColumnType("int")
           .IsUnicode(false);
        }
    }
}
