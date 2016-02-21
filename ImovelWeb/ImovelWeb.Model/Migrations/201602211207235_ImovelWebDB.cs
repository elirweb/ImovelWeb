namespace ImovelWeb.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImovelWebDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 20, unicode: false),
                        Assunto = c.String(maxLength: 10, unicode: false),
                        Comentário = c.String(maxLength: 200, unicode: false),
                        Newsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoID);
            
            CreateTable(
                "dbo.Corretor",
                c => new
                    {
                        CorretorID = c.Int(nullable: false, identity: true),
                        Matricula = c.String(maxLength: 20, unicode: false),
                        NomeCorretor = c.String(maxLength: 100, unicode: false),
                        Login = c.String(maxLength: 20, unicode: false),
                        Senha = c.String(maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sexo = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 20, unicode: false),
                        Estado = c.String(maxLength: 10, unicode: false),
                        Telefone = c.String(maxLength: 20, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        NivelUsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CorretorID)
                .ForeignKey("dbo.NivelUsuario", t => t.NivelUsuarioID)
                .Index(t => t.NivelUsuarioID);
            
            CreateTable(
                "dbo.Empreendimento",
                c => new
                    {
                        EmpreendimentoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 50, unicode: false),
                        Estado = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 20, unicode: false),
                        CorretorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpreendimentoID)
                .ForeignKey("dbo.Corretor", t => t.CorretorID)
                .Index(t => t.CorretorID);
            
            CreateTable(
                "dbo.NivelUsuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Perfil = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        FotoID = c.Int(nullable: false, identity: true),
                        NomeFoto = c.String(maxLength: 100, unicode: false),
                        ImovelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FotoID)
                .ForeignKey("dbo.Imovel", t => t.ImovelID)
                .Index(t => t.ImovelID);
            
            CreateTable(
                "dbo.Imovel",
                c => new
                    {
                        ImovelID = c.Int(nullable: false, identity: true),
                        NomeImovel = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 10, unicode: false),
                        Estado = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 20, unicode: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorcentagemID = c.Int(nullable: false),
                        EmpreendimentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImovelID)
                .ForeignKey("dbo.Empreendimento", t => t.EmpreendimentoID)
                .ForeignKey("dbo.Porcentagem", t => t.PorcentagemID)
                .Index(t => t.EmpreendimentoID)
                .Index(t => t.PorcentagemID);
            
            CreateTable(
                "dbo.Porcentagem",
                c => new
                    {
                        PorcentagemID = c.Int(nullable: false, identity: true),
                        Desconto = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.PorcentagemID);
            
            CreateTable(
                "dbo.Registro",
                c => new
                    {
                        RegistroID = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CorretorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistroID)
                .ForeignKey("dbo.Corretor", t => t.CorretorID)
                .Index(t => t.CorretorID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 20, unicode: false),
                        Senha = c.String(maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sexo = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 20, unicode: false),
                        Estado = c.String(maxLength: 10, unicode: false),
                        Telefone = c.String(),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        NivelUsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.NivelUsuario", t => t.NivelUsuarioID)
                .Index(t => t.NivelUsuarioID);
            
            CreateTable(
                "dbo.VendaImovel",
                c => new
                    {
                        VendaImovelID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        ImovelID = c.Int(nullable: false),
                        CorretorID = c.Int(nullable: false),
                        TotalValor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrdemCompra = c.String(maxLength: 200, unicode: false),
                        Hora = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.VendaImovelID)
                .ForeignKey("dbo.Corretor", t => t.CorretorID)
                .ForeignKey("dbo.Imovel", t => t.ImovelID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioID)
                .Index(t => t.CorretorID)
                .Index(t => t.ImovelID)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaImovel", "UsuarioID", "dbo.Usuario");
            DropForeignKey("dbo.VendaImovel", "ImovelID", "dbo.Imovel");
            DropForeignKey("dbo.VendaImovel", "CorretorID", "dbo.Corretor");
            DropForeignKey("dbo.Usuario", "NivelUsuarioID", "dbo.NivelUsuario");
            DropForeignKey("dbo.Registro", "CorretorID", "dbo.Corretor");
            DropForeignKey("dbo.Imovel", "PorcentagemID", "dbo.Porcentagem");
            DropForeignKey("dbo.Foto", "ImovelID", "dbo.Imovel");
            DropForeignKey("dbo.Imovel", "EmpreendimentoID", "dbo.Empreendimento");
            DropForeignKey("dbo.Corretor", "NivelUsuarioID", "dbo.NivelUsuario");
            DropForeignKey("dbo.Empreendimento", "CorretorID", "dbo.Corretor");
            DropIndex("dbo.VendaImovel", new[] { "UsuarioID" });
            DropIndex("dbo.VendaImovel", new[] { "ImovelID" });
            DropIndex("dbo.VendaImovel", new[] { "CorretorID" });
            DropIndex("dbo.Usuario", new[] { "NivelUsuarioID" });
            DropIndex("dbo.Registro", new[] { "CorretorID" });
            DropIndex("dbo.Imovel", new[] { "PorcentagemID" });
            DropIndex("dbo.Foto", new[] { "ImovelID" });
            DropIndex("dbo.Imovel", new[] { "EmpreendimentoID" });
            DropIndex("dbo.Corretor", new[] { "NivelUsuarioID" });
            DropIndex("dbo.Empreendimento", new[] { "CorretorID" });
            DropTable("dbo.VendaImovel");
            DropTable("dbo.Usuario");
            DropTable("dbo.Registro");
            DropTable("dbo.Porcentagem");
            DropTable("dbo.Imovel");
            DropTable("dbo.Foto");
            DropTable("dbo.NivelUsuario");
            DropTable("dbo.Empreendimento");
            DropTable("dbo.Corretor");
            DropTable("dbo.Contato");
        }
    }
}
