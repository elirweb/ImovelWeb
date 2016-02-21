namespace ImovelWeb.DDD.ValueObject.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ImovelWeb : DbContext
    {
        public ImovelWeb()
            : base("name=ImovelWeb")
        {
            Configuration.LazyLoadingEnabled = false;
            
        }

        public virtual DbSet<Contato> Contatoes { get; set; }
        public virtual DbSet<Corretor> Corretors { get; set; }
        public virtual DbSet<Empreendimento> Empreendimentoes { get; set; }
        public virtual DbSet<Foto> Fotoes { get; set; }
        public virtual DbSet<Imovel> Imovels { get; set; }
        public virtual DbSet<NivelUsuario> NivelUsuarios { get; set; }
        public virtual DbSet<Porcentagem> Porcentagems { get; set; }
        public virtual DbSet<Registro> Registroes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VendaImovel> VendaImovels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    
        
    }
}
