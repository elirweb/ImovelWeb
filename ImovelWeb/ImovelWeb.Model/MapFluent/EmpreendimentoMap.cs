
using System.Data.Entity.ModelConfiguration;
namespace ImovelWeb.Model.MapFluent
{
    public class EmpreendimentoMap : EntityTypeConfiguration<Empreendimento>
    {
        public EmpreendimentoMap()
        {
            ToTable("Empreendimento");HasKey(c => c.EmpreendimentoID);
            Property(c => c.NomeEmpreendimento).HasColumnType("varchar").HasMaxLength(100).HasColumnName("Nome");
            Property(c => c.Endereco).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Numero).HasColumnType("varchar").HasMaxLength(50);
            Property(c => c.Estado).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.Cidade).HasColumnType("varchar").HasMaxLength(20);


        }
    }
}

