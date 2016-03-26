namespace ImovelWeb.WebAPI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empreendimento")]
    public partial class Empreendimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empreendimento()
        {
            Imovels = new HashSet<Imovel>();
        }

        public int EmpreendimentoID { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(50)]
        public string Numero { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        public int CorretorID { get; set; }

        public virtual Corretor Corretor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovels { get; set; }
    }
}
