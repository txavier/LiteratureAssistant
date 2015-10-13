using System.Collections.Generic;
using WildCard.Core.Models;

namespace LiteratureAssistant.Core.ViewModels
{
    public class OrderByItemViewModel
    {
        public IEnumerable<item> item;
        public int quantity;

        public int itemId { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public int? onHand { get; set; }
        public string orderFor { get; set; }
        public string itemNumber { get; set; }
    }
}