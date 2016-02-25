namespace ImovelWeb.DDD.Test.ValueObject.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImovelWeb : DbContext
    {
        public ImovelWeb()
            : base("name=ImovelWeb")
        {
        }

        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Corretor> Corretor { get; set; }
        public virtual DbSet<Empreendimento> Empreendimento { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }
        public virtual DbSet<NivelUsuario> NivelUsuario { get; set; }
        public virtual DbSet<Porcentagem> Porcentagem { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VendaImovel> VendaImovel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Assunto)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Comentário)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Matricula)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.NomeCorretor)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Corretor>()
                .HasMany(e => e.Empreendimento)
                .WithRequired(e => e.Corretor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Corretor>()
                .HasMany(e => e.Registro)
                .WithRequired(e => e.Corretor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Corretor>()
                .HasMany(e => e.VendaImovel)
                .WithRequired(e => e.Corretor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empreendimento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Empreendimento>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Empreendimento>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Empreendimento>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Empreendimento>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Empreendimento>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.Empreendimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Foto>()
                .Property(e => e.NomeFoto)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.NomeImovel)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.Foto)
                .WithRequired(e => e.Imovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imovel>()
                .HasMany(e => e.VendaImovel)
                .WithRequired(e => e.Imovel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NivelUsuario>()
                .Property(e => e.Perfil)
                .IsUnicode(false);

            modelBuilder.Entity<NivelUsuario>()
                .HasMany(e => e.Corretor)
                .WithRequired(e => e.NivelUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NivelUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.NivelUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Porcentagem>()
                .Property(e => e.Desconto)
                .IsUnicode(false);

            modelBuilder.Entity<Porcentagem>()
                .HasMany(e => e.Imovel)
                .WithRequired(e => e.Porcentagem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.VendaImovel)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendaImovel>()
                .Property(e => e.OrdemCompra)
                .IsUnicode(false);
        }
    }
}
