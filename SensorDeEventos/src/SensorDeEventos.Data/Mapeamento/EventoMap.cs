using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorDeEventos.Domain.Enums;
using SensorDeEventos.Domain.Models;
using System;

namespace SensorDeEventos.Data.Mapeamento
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
                builder.Property(x => x.Tag)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Valor)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(x => x.TimeStamp)
              .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion(s => s.ToString(),
                e => Enum.Parse<Status>(e))
                .HasColumnType("varchar(10)");

        }
    }
}
