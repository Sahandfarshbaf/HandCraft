using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SliderRepository : RepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
