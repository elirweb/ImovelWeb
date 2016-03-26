namespace ImovelWeb.WebAPI.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imovel")]
    public partial class Imovel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imovel()
        {
            Fotoes = new HashSet<Foto>();
            VendaImovels = new HashSet<VendaImovel>();
        }

        public int ImovelID { get; set; }

        [StringLength(100)]
        public string NomeImovel { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        public decimal Preco { get; set; }

        public int PorcentagemID { get; set; }

        public int EmpreendimentoID { get; set; }

        public virtual Empreendimento Empreendimento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Fotoes { get; set; }

        public virtual Porcentagem Porcentagem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaImovel> VendaImovels { get; set; }
    }
}
