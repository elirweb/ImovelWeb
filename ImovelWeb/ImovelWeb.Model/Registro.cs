using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
    [Table("Registro")]
    public class Registro
    {

        [Key]
        [Display(Name = "RegistroID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistroID { get; set; }

        [Display(Name = "DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public int CorretorID { get; set; }
        [ForeignKey("CorretorID")]
        public Corretor Corretor { get; set; }
    }
}
