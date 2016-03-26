using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ImovelWeb.Model.MapFluent;
namespace ImovelWeb.Model
{
    public class Contexto:DbContext
        
    {
        DbSet<Usuario> Usuario  {get;set;}
        DbSet<NivelUsuario> NivelUsuario { get; set; }
        DbSet<Registro> Registro { get; set; }
        DbSet<Corretor> Corretor { get; set; }
        DbSet<Empreendimento> Empreendimento { get; set; }
        DbSet<Foto> Foto { get; set; }
        DbSet<Imovel> Imovel { get; set; }
        DbSet<Contato> Contato { get; set; }
        DbSet<Porcentagem> Porcentagem { get;set; }
        DbSet<VendaImovel> VendaImovel { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            modelBuilder.Configurations.Add(new  UsuarioMap());
            modelBuilder.Configurations.Add(new CorretorMap());
            modelBuilder.Configurations.Add(new EmpreendimentoMap());
            modelBuilder.Configurations.Add(new FotoMap());
            modelBuilder.Configurations.Add(new NivelUsuarioMap());
            modelBuilder.Configurations.Add(new ImovelMap());
            modelBuilder.Configurations.Add(new RegistroMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new PorcentagemMap());
            modelBuilder.Configurations.Add(new VendaImovelMap());

        }
    }
}


