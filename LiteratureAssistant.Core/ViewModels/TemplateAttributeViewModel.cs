namespace WildCard.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TemplateAttributeViewModel
    {
        public TemplateAttributeViewModel()
        {
        }

        public int templateAttributeId { get; set; }

        public int itemTemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string templateAttributeName { get; set; }

        public bool? required { get; set; }

        public int? priority { get; set; }
    }
}
