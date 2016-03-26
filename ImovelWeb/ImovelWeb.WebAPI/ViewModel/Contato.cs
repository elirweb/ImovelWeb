namespace ImovelWeb.WebAPI.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contato")]
    public partial class Contato
    {
        public int ContatoID { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Assunto { get; set; }

        [StringLength(200)]
        public string Comentário { get; set; }

        public bool Newsletter { get; set; }
    }
}
