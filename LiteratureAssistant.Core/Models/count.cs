namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("count")]
    public partial class count
    {
        public int countId { get; set; }

        public int itemId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public virtual item item { get; set; }
    }
}
