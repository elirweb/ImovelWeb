using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class PorcentagemMap : EntityTypeConfiguration<Porcentagem>
    {
        public PorcentagemMap()
        {
            ToTable("Porcentagem");
            HasKey(c => c.PorcentagemID);
            Property(c => c.Desconto).HasColumnType("varchar").HasMaxLength(20);
        }
    }
}

