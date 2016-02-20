using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
    
        [Table("Empreendimento")]
        public class Empreendimento
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "EmpreendimentoID")]
            public int EmpreendimentoID { get; set; }

            [Display(Name = "NomeEmpreendimento")]
            public string NomeEmpreendimento { get; set; }

            [Display(Name = "Endereco")]
            public string Endereco { get; set; }

            [Display(Name = "numero")]
            public string Numero { get; set; }

            [Display(Name = "Estado")]
            public string Estado { get; set; }

            [Display(Name = "Cidade")]
            public string Cidade { get; set; }

            [Display(Name = "ImovelID")]
            public virtual IEnumerable<Imovel> ImovelID { get; set; }

            public int CorretorID { get; set; }
            [ForeignKey("CorretorID")]
            public Corretor Corretor { get; set; }
        }

}
