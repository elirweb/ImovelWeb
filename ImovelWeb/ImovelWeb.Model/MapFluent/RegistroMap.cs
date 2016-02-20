using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class RegistroMap : EntityTypeConfiguration<Registro>
    {
        public RegistroMap()
        {
            ToTable("Registro");
            HasKey(c => c.RegistroID);

        }
    }
}
