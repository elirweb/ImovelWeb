namespace ImovelWeb.DDD.Test.ValueObject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
