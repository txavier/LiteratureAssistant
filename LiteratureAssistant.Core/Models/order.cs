namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        public int orderId { get; set; }

        public int itemId { get; set; }

        public int userId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public bool? pending { get; set; }

        public bool? received { get; set; }

        public bool? orderSent { get; set; }

        public virtual item item { get; set; }

        public virtual user user { get; set; }
    }
}
