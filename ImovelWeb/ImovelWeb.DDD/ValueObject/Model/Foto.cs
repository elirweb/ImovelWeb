namespace ImovelWeb.DDD.ValueObject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
