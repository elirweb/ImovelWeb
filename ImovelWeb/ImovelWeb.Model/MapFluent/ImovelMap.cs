using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class ImovelMap : EntityTypeConfiguration<Imovel>
    {
        public ImovelMap()
        {
            ToTable("Imovel");
            HasKey(c => c.ImovelID);
            Property(c => c.NomeImovel).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Descricao).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Endereco).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Numero).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.Estado).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.Cidade).HasColumnType("varchar").HasMaxLength(20);
            


        }
    }
}
