using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
   
        [Table("Foto")]
        public class Foto
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "FotoID")]
            public int FotoID { get; set; }

            [Display(Name = "NomeFoto")]
            public string NomeFoto { get; set; }

            public int ImovelID { get; set; }
            [ForeignKey("ImovelID")]
            public Imovel Imovel { get; set; }
        }
    
}
