namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("itemTemplate")]
    public partial class itemTemplate
    {
        public itemTemplate()
        {
            items = new HashSet<item>();
            templateAttributes = new HashSet<templateAttribute>();
        }

        public int itemTemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string itemTemplateName { get; set; }

        public virtual ICollection<item> items { get; set; }

        public virtual ICollection<templateAttribute> templateAttributes { get; set; }
    }
}
