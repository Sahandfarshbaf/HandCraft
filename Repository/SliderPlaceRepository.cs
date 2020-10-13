using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class SliderPlaceRepository : RepositoryBase<SliderPlace>, ISliderPlaceRepository
    {
        public SliderPlaceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
