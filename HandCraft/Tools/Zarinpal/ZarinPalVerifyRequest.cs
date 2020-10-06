using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools.Zarinpal
{
    public class ZarinPalVerifyRequest
    {
        public string merchant_id { set; get; }
        public int amount { set; get; }
        public string authority { set; get; }
    }
}
