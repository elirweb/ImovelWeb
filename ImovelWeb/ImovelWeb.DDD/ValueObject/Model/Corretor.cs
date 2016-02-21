namespace ImovelWeb.DDD.ValueObject.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Corretor")]
    public partial class Corretor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corretor()
        {
            Empreendimentoes = new HashSet<Empreendimento>();
            Registroes = new HashSet<Registro>();
            VendaImovels = new HashSet<VendaImovel>();
        }

        public int CorretorID { get; set; }

        [StringLength(20)]
        public string Matricula { get; set; }

        [StringLength(100)]
        public string NomeCorretor { get; set; }

        [StringLength(20)]
        public string Login { get; set; }

        [StringLength(20)]
        public string Senha { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Sexo { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        public int NivelUsuarioID { get; set; }

        public virtual NivelUsuario NivelUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empreendimento> Empreendimentoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registro> Registroes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaImovel> VendaImovels { get; set; }
    }
}
