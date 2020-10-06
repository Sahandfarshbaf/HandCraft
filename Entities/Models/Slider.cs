using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Slider
    {
        public long Id { get; set; }
        public long? SliderPlaceTypeId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ImageHurl { get; set; }
        public int? Rorder { get; set; }
        public string LinkUrl { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual SliderPlaceType SliderPlaceType { get; set; }
    }
}
