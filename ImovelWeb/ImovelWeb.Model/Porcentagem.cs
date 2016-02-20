
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ImovelWeb.Model
{
   
        [Table("Porcentagem")]
        public class Porcentagem
        {
            [Key]
            [Display(Name = "PorcentagemID")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PorcentagemID { get; set; }

            [Display(Name = "Desconto")]
            public string Desconto { get; set; }
        }
    

}
