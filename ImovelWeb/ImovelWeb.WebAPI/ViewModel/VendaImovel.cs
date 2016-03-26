namespace ImovelWeb.WebAPI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendaImovel")]
    public partial class VendaImovel
    {
        public int VendaImovelID { get; set; }

        public int UsuarioID { get; set; }

        public int ImovelID { get; set; }

        public int CorretorID { get; set; }

        public decimal TotalValor { get; set; }

        [StringLength(200)]
        public string OrdemCompra { get; set; }

        public TimeSpan Hora { get; set; }

        public virtual Corretor Corretor { get; set; }

        public virtual Imovel Imovel { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
