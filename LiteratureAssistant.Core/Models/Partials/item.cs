using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCard.Core.Models
{
    [MetadataType(typeof(itemMetadata))]
    public partial class item
    {
        private class itemMetadata
        {
            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual ICollection<item> item1 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual item item2 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual ICollection<item> item11 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual item item3 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual ICollection<item> item12 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual item item4 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual ICollection<item> item13 { get; set; }

            [DisplayName("[Set Name in the itemMetadata class]")]
            public virtual item item5 { get; set; }
        }
    }
}
