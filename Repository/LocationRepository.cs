using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public List<Location> GetCityList(long provinceId)
        {
            return FindByCondition(c => c.ProvinceId == provinceId && string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId)).OrderBy(c => c.Name).ToList();
        }

        public List<Location> GetCountryList()
        {
            return FindByCondition(c => c.Pid == null && string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId)).OrderBy(c => c.Name).ToList();
        }

        public List<Location> GetProvinceList(long? countryId)
        {
            return FindByCondition(c => c.ProvinceId == null && (c.Pid == countryId || c.Pid == 1) && string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId)).OrderBy(c => c.Name).ToList();

        }
    }
}
