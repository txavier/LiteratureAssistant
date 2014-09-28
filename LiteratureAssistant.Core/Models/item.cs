namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("item")]
    public partial class item
    {
        public item()
        {
            counts = new HashSet<count>();
            itemAttributes = new HashSet<itemAttribute>();
            orders = new HashSet<order>();
        }

        public int itemId { get; set; }

        public int itemTemplateId { get; set; }

        public virtual ICollection<count> counts { get; set; }

        public virtual itemTemplate itemTemplate { get; set; }

        public virtual ICollection<itemAttribute> itemAttributes { get; set; }

        public virtual ICollection<order> orders { get; set; }
    }
}
