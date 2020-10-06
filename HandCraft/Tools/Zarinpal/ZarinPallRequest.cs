using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools.Zarinpal
{
    public class ZarinPallRequest
    {
        public string merchant_id { set; get; }
        public int amount { set; get; }
        public string description { set; get; }
        public ZarinPalRequestMetaData metadata { set; get; }
        public string callback_url { set; get; }

        public ZarinPallRequest()
        {
            this.metadata = new ZarinPalRequestMetaData();
        }
    }
}
