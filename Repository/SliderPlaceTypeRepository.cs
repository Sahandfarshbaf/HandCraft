using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class SliderPlaceTypeRepository : RepositoryBase<SliderPlaceType>, ISliderPlaceTypeRepository
    {
        public SliderPlaceTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
