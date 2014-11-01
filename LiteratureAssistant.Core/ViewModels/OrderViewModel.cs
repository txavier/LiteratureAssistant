using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteratureAssistant.Core.ViewModels
{
    public class OrderViewModel
    {
        public string orderedForUserFullName { get; set; }

        public string orderedByUserFullName { get; set; }

        public string itemLabel { get; set; }

        public int orderId { get; set; }

        public int itemId { get; set; }

        public int orderedForUserId { get; set; }

        public int orderedByUserId { get; set; }

        public DateTime date { get; set; }

        public bool? pending { get; set; }

        public bool? received { get; set; }

        public bool? orderSent { get; set; }

        public ItemViewModel item { get; set; }

        public UserViewModel user { get; set; }
    }
}
