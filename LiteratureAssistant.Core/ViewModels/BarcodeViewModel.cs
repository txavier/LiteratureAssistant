using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LiteratureAssistant.Core.ViewModels
{
    public class BarcodeViewModel
    {
        public string barcodeBase64DataUri { get; set; }

        public string fieldName { get; set; }

        public string value { get; set; }
    }
}
