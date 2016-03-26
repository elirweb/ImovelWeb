using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class FotoMap : EntityTypeConfiguration<Foto>
    {
        public FotoMap()
        {
            ToTable("Foto");
            HasKey(c => c.FotoID);
            Property(c => c.NomeFoto).HasColumnType("varchar").HasMaxLength(100);

        }
    }
}
