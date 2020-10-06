using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SliderPlaceType
    {
        public SliderPlaceType()
        {
            Slider = new HashSet<Slider>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Rkey { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual ICollection<Slider> Slider { get; set; }
    }
}
