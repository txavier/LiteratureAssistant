using LiteratureAssistant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureAssistant.Core.ViewModels
{
    public class ItemViewModel
    {
        public int itemId { get; set; }

        public int itemTemplateId { get; set; }

        public ItemTemplateViewModel itemTemplate { get; set; }

        public IEnumerable<ItemAttributeViewModel> itemAttributes { get; set; }
    }
}
