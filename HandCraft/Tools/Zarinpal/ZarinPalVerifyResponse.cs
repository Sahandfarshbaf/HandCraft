using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools.Zarinpal
{
    public class ZarinPalVerifyResponse
    {
        public int code { set; get; }
        public int merchacodent_id { set; get; }
        public int ref_id { set; get; }
        public string card_pan { set; get; }
        public string card_hash { set; get; }
        public string fee_type { set; get; }
        public int fee { set; get; }
    }
}
