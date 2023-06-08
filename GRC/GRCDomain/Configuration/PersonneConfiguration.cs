using GRC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Configuration;

public class PersonneConfiguration : IEntityTypeConfiguration<Personne>
{
    public void Configure(EntityTypeBuilder<Personne> builder)
    {
        builder
            .Property(o => o.Nom)
            .IsRequired();
        

    }
}