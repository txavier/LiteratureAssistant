namespace LiteratureAssistant.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("item")]
    public partial class item
    {
        public int itemId { get; set; }

        public int itemTemplateId { get; set; }
    }
}
