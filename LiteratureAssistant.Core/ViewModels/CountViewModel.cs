using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCard.Core.ViewModels
{
    public class CountViewModel
    {
        public string itemLabel { get; set; }

        public int countId { get; set; }

        public int itemId { get; set; }

        public int? received { get; set; }

        public string receivedDate { get; set; }

        public int? currentlyOnHand { get; set; }

        public string currentlyOnHandDate { get; set; }

        public string barcodeTemplateAttributeName { get; set; }

        public string barcodeTemplateAttributeValue { get; set; }

    }
}
