using DapperDemo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.DAL
{
    public interface IGymStore
    {
        IEnumerable<GymDALModel> SelectAllLocations();
        GymDALModel SelectALocation(int id);
        bool InsertNewLocation(GymDALModel dalModel);
        bool EditLocation(GymDALModel dalModel);

    }
}
