namespace WildCard.Core.Models
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

        public int? received { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? receivedDate { get; set; }

        public int? currentlyOnHand { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? currentlyOnHandDate { get; set; }

        public virtual item item { get; set; }
    }
}
