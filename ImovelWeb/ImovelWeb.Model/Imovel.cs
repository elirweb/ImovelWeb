using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
    
        [Table("Imovel")]
        public class Imovel
        {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ImovelID")]
            public int ImovelID { get; set; }

            [Display(Name = "FotoID")]
            public virtual ICollection<Foto> FotoID { get; set; }


            [Display(Name = "NomeImovel")]
            public string NomeImovel { get; set; }

            [Display(Name = "Descricao")]
            public string Descricao { get; set; }

            [Display(Name = "Endereco")]
            public string Endereco { get; set; }

            [Display(Name = "numero")]
            public string Numero { get; set; }

            [Display(Name = "Estado")]
            public string Estado { get; set; }

            [Display(Name = "Cidade")]
            public string Cidade { get; set; }


            [Display(Name = "Preco")]
            public decimal Preco { get; set; }

            public int PorcentagemID { get; set; }
            [ForeignKey("PorcentagemID")]
            public Porcentagem Porcentagem { get; set; }

            public int EmpreendimentoID { get; set; }
            [ForeignKey("EmpreendimentoID")]
            public Empreendimento Empreendimento { get; set; }


        }

    
}
