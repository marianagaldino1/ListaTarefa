using ListaTarefasAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VShop.ProductInfrastructure.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {

            builder

                .HasKey(c => c.Id_Tarefa);

            builder

               .Property(c => c.CustoTarefa)
               .HasPrecision(12, 2);

            builder

               .Property(c => c.NomeTarefa)
               .HasMaxLength(255)
               .IsRequired();

            builder
                .Property(c => c.Ordem)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.DataLimite)
                .IsRequired();



        }
    }
}
