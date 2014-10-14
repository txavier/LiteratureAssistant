using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteratureAssistant.Core.ViewModels
{
    public class OrderViewModel
    {
        public int orderId { get; set; }

        public int itemId { get; set; }

        public int userId { get; set; }

        public DateTime date { get; set; }

        public bool? pending { get; set; }

        public bool? received { get; set; }

        public bool? orderSent { get; set; }

        public ItemViewModel item { get; set; }

        public UserViewModel user { get; set; }
    }
}
