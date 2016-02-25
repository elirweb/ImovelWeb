namespace ImovelWeb.DDD.Test.ValueObject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            VendaImovel = new HashSet<VendaImovel>();
        }

        public int UsuarioID { get; set; }

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

        public string Telefone { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        public int NivelUsuarioID { get; set; }

        public virtual NivelUsuario NivelUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaImovel> VendaImovel { get; set; }
    }
}
