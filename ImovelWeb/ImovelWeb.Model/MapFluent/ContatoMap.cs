using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Model.MapFluent
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato"); 
            HasKey(c => c.ContatoID);
            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Email).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            Property(c => c.Comentario).HasColumnType("varchar").HasMaxLength(200).HasColumnName("Comentário");
            Property(c => c.Assunto).HasColumnType("varchar").HasMaxLength(10);


        }
    }
}

