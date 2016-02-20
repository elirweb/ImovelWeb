using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImovelWeb.Model
{
    [Table("Corretor")]
    public class Corretor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CorretorID")]
        public int CorretorID { get; set; }

        [Display(Name = "Matricula")]
        public string Matricula { get; set; }

        [Display(Name = "EmpreendimentoID")]
        public virtual ICollection<Empreendimento> EmpreendimentoID { get; set; }

        [Display(Name = "NomeCorretor")]
        public string NomeCorretor { get; set; }

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        public int NivelUsuarioID { get; set; }
        [ForeignKey("NivelUsuarioID")]
        public NivelUsuario NivelUsuario { get; set; }


    }
}
