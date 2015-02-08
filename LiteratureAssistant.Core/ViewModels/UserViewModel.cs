using WildCard.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCard.Core.ViewModels
{
    public class UserViewModel
    {
        public int? userId { get; set; }

        public string fullName { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public IEnumerable<OrderViewModel> orders { get; set; }
    }
}
