namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("itemAttribute")]
    public partial class itemAttribute
    {
        public int itemAttributeId { get; set; }

        public int itemId { get; set; }

        public int templateAttributeId { get; set; }

        [Required]
        [StringLength(50)]
        public string value { get; set; }
    }
}
