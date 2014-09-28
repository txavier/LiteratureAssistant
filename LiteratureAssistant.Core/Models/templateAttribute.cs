namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("templateAttribute")]
    public partial class templateAttribute
    {
        public templateAttribute()
        {
            itemAttributes = new HashSet<itemAttribute>();
        }

        public int templateAttributeId { get; set; }

        public int itemTemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string templateAttributeName { get; set; }

        public bool? required { get; set; }

        public virtual ICollection<itemAttribute> itemAttributes { get; set; }

        public virtual itemTemplate itemTemplate { get; set; }
    }
}
