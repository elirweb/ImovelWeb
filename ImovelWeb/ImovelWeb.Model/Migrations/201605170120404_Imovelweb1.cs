namespace ImovelWeb.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imovelweb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VendaImovel", "Hora", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VendaImovel", "Hora", c => c.Time(nullable: false, precision: 7));
        }
    }
}
