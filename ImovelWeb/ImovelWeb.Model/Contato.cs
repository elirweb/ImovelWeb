using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
    
        [Table("Contato")]
        public class Contato
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ContatoID")]
            public int ContatoID { get; set; }

            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Assunto")]
            public string Assunto { get; set; }

            [Display(Name = "Comentario")]
            public string Comentario { get; set; }

            [Display(Name = "Newsletter")]
            public bool Newsletter { get; set; }

        }
    
}
