namespace ImovelWeb.DDD.ValueObject.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Foto")]
    public partial class Foto
    {
        public int FotoID { get; set; }

        [StringLength(100)]
        public string NomeFoto { get; set; }

        public int ImovelID { get; set; }

        public virtual Imovel Imovel { get; set; }
    }
}
