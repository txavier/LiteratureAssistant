namespace WildCard.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("organization")]
    public partial class organization
    {
        public organization()
        {
            itemAttributes = new HashSet<itemAttribute>();
        }

        public int organizationId { get; set; }

        public bool? defaultOrganization { get; set; }

        public string name { get; set; }

        [Required]
        public string systemName { get; set; }

        public virtual ICollection<itemAttribute> itemAttributes { get; set; }
    }
}
