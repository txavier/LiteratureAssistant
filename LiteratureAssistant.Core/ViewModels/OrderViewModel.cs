using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCard.Core.ViewModels
{
    public class OrderViewModel
    {
        public string orderedForUserFullName { get; set; }

        public string orderedByUserFullName { get; set; }

        public string itemLabel { get; set; }

        public int orderId { get; set; }

        public int? itemId { get; set; }

        public int? orderedForUserId { get; set; }

        public int? orderedByUserId { get; set; }

        public string date { get; set; }

        public bool? pending { get; set; }

        public bool? received { get; set; }

        public bool? orderSent { get; set; }

        public int? quantity { get; set; }

        public string language { get; set; }

        //public ItemViewModel item { get; set; }

        //public UserViewModel user { get; set; }
    }
}
