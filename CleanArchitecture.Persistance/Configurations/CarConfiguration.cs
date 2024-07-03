using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Configurations
{
    //DbSet yazmak yerine bu şekilde yazarak, veritabanı tablolarının oluşturulmasını sağlayabiliriz.
    public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.Id);
            builder.HasIndex(p => p.Name);
            //Indexleme: Veritabanında arama yaparken hızlı bir şekilde arama yapılmasını sağlar.
        }
    }
}
