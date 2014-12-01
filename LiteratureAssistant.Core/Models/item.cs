namespace WildCard.Core.Models
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
            item1 = new HashSet<item>();
            item11 = new HashSet<item>();
            item12 = new HashSet<item>();
            item13 = new HashSet<item>();
            itemAttributes = new HashSet<itemAttribute>();
            orders = new HashSet<order>();
        }

        public int itemId { get; set; }

        public int itemTemplateId { get; set; }

        public int? parentItemId { get; set; }

        public int? childItemId { get; set; }

        public int? groupItemId { get; set; }

        public int? parentGroupItemId { get; set; }

        public int? processItemId { get; set; }

        public int? parentProcessItemId { get; set; }

        public virtual ICollection<count> counts { get; set; }

        public virtual ICollection<item> item1 { get; set; }

        public virtual item item2 { get; set; }

        public virtual ICollection<item> item11 { get; set; }

        public virtual item item3 { get; set; }

        public virtual ICollection<item> item12 { get; set; }

        public virtual item item4 { get; set; }

        public virtual ICollection<item> item13 { get; set; }

        public virtual item item5 { get; set; }

        public virtual itemTemplate itemTemplate { get; set; }

        public virtual ICollection<itemAttribute> itemAttributes { get; set; }

        public virtual ICollection<order> orders { get; set; }
    }
}
