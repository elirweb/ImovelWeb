using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class NivelUsuarioMap : EntityTypeConfiguration<NivelUsuario>
    {
        public NivelUsuarioMap()
        {
            ToTable("NivelUsuario");
                HasKey(c => c.ID);
            Property(c => c.Perfil).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}

