using System.Data.Entity.ModelConfiguration;

namespace ImovelWeb.Model.MapFluent
{
    public class CorretorMap : EntityTypeConfiguration<Corretor>
    {
        public CorretorMap()
        {
            ToTable("Corretor");
            HasKey(c => c.CorretorID);
            Property(c => c.Login).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Matricula).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.NomeCorretor).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Senha).HasColumnType("varchar").HasMaxLength(200);
            Property(c => c.Sexo).HasColumnType("varchar").HasMaxLength(10);
            Property(c => c.Telefone).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Cidade).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.Email).HasColumnType("varchar").IsRequired().HasMaxLength(50).IsUnicode();
            Property(c => c.Endereco).HasColumnType("varchar").HasMaxLength(100);
            Property(c => c.Estado).HasColumnType("varchar").HasMaxLength(10);

        }
    }
}

