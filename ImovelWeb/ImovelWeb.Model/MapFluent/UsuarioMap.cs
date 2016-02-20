
using System.Data.Entity.ModelConfiguration;
namespace ImovelWeb.Model.MapFluent
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {

            ToTable("Usuario");
                HasKey(c => c.UsuarioID);
            Property(c => c.Email).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar").HasMaxLength(50);
            Property(c => c.Login).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Senha).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Endereco).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Cidade).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Estado).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.Sexo).HasColumnType("varchar").HasMaxLength(10);



        }
    }
}

