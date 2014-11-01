namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public user()
        {
            orders = new HashSet<order>();
            orders1 = new HashSet<order>();
        }

        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        public virtual ICollection<order> orders { get; set; }

        public virtual ICollection<order> orders1 { get; set; }
    }
}
