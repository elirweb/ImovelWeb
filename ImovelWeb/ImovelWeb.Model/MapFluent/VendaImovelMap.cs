using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Model.MapFluent
{
    public class VendaImovelMap : EntityTypeConfiguration<VendaImovel>
    {
        public VendaImovelMap()
        {
            ToTable("VendaImovel");
            HasKey(c => c.VendaImovelID);
            Property(c => c.OrdemCompra).HasColumnType("varchar").HasMaxLength(200);
            Property(c=>c.Hora).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
