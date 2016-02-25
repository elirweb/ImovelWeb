namespace ImovelWeb.DDD.Test.ValueObject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registro")]
    public partial class Registro
    {
        public int RegistroID { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Status { get; set; }

        public int CorretorID { get; set; }

        public virtual Corretor Corretor { get; set; }
    }
}
