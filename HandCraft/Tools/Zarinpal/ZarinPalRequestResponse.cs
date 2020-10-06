using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools.Zarinpal
{
    public class ZarinPalRequestResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public string authority { get; set; }
        public string fee_type { get; set; }
        public int fee { get; set; }
  
    }
}
