using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface ILocationRepository:IRepositoryBase<Location>
    {
        List<Location> GetCountryList();
        List<Location> GetProvinceList(long? countryId);
        List<Location> GetCityList(long provinceId);
        
    }
}
