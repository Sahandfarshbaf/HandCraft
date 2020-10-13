using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Slider
    {
        public long Id { get; set; }
        public long? SliderPlaceId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ImageHurl { get; set; }
        public int? Rorder { get; set; }
        public string LinkUrl { get; set; }
        public long? CuserId { get; set; }
        public long? Cdate { get; set; }
        public long? DuserId { get; set; }
        public long? Ddate { get; set; }
        public long? MuserId { get; set; }
        public long? Mdate { get; set; }
        public long? DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual SliderPlace SliderPlace { get; set; }
    }
}
