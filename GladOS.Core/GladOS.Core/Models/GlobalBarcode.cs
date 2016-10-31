using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladOS.Core.Models
{
    public class GlobalBarcode
    {
        private static string globalBarcodes = "";

        public static string GlobalBarcodes
        {
            get { return globalBarcodes; }
            set { globalBarcodes = value; }
        }

    }
}
