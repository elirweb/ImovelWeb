using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
   
        [Table("VendaImovel")]
        public class VendaImovel
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "VendaImovelID")]
            public int VendaImovelID { get; set; }

            public int UsuarioID { get; set; }
            [ForeignKey("UsuarioID")]
            public Usuario Usuario { get; set; }

            public int ImovelID { get; set; }
            [ForeignKey("ImovelID")]
            public Imovel Imovel { get; set; }

            public int CorretorID { get; set; }
            [ForeignKey("CorretorID")]
            public Corretor Corretor { get; set; }

            [Display(Name = "TotalValor")]
            public decimal TotalValor { get; set; }

            [Display(Name = "OrdemCompra")]
            public string OrdemCompra { get; set; }

            [Display(Name = "Hora")]
            public TimeSpan Hora { get; set; }

        }
    
    
}
