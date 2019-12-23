using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DapperDemo.GymServices
{
    public interface IGymService
    {
        LocationsViewModel GetAllLocations();
        LocationViewModel ViewLocation(int id);
        AddResultsViewModel AddNewLocation(AddLocationViewModel model);
        EditLocationViewModel EditGymLocationInfo(LocationViewModel model);
    }
}


