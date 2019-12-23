using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.DAL;
using DapperDemo.DAL.Model;
using DapperDemo.Models;

namespace DapperDemo.GymServices
{
    public class GymService: IGymService
    {
        private readonly IGymStore _gymStore;

        public GymService(IGymStore gymStore)
        {
            _gymStore = gymStore;
        }

        public LocationsViewModel GetAllLocations()
        {
            var dalLocations = _gymStore.SelectAllLocations();
            return MapDALToViewModel(dalLocations);
        }

        public LocationViewModel ViewLocation(int id)
        {
            var dalLocation = _gymStore.SelectALocation(id);

            return MapADALToViewModel(dalLocation);
        }

        public AddResultsViewModel AddNewLocation(AddLocationViewModel model)
        {
            var dalModel = new GymDALModel
            {
                GymName = model.GymName,
                OpenAfter10PM = model.OpenAfter10PM,
                MembershipPrice = model.MembershipPrice,
                City = model.City
            };

            var additionResults = _gymStore.InsertNewLocation(dalModel);
            var addResults = new AddResultsViewModel();
            
            if(additionResults = true)
            {
                addResults.AdditionConfirmationMessage = "The gym location has been added.";
            }
            else
            {
                addResults.AdditionConfirmationMessage = "The gym has not been added.";
            }
            return addResults;
        }

        public EditLocationViewModel EditGymLocationInfo(LocationViewModel model)
        {
            var dalModel = new GymDALModel
            {
                LocationId = model.LocationId,
                GymName = model.GymName,
                OpenAfter10PM = model.OpenAfter10PM,
                MembershipPrice = model.MembershipPrice,
                City = model.City
            };

            var results = _gymStore.EditLocation(dalModel);
            var editedResults = _gymStore.SelectALocation(model.LocationId);
            
            var editLocationVM = new EditLocationViewModel
            {
                LocationId = editedResults.LocationId,
                GymName = editedResults.GymName,
                OpenAfter10PM = editedResults.OpenAfter10PM,
                MembershipPrice = editedResults.MembershipPrice,
                City = editedResults.City,
                
            };

            if (results == true)
            {
                editLocationVM.EditConfirmationMessage = "The gym information has been updated.";
            }
            else
            {
                editLocationVM.EditConfirmationMessage = "The gym information has not been updated.";
            }

            return editLocationVM;
        }

        private static LocationsViewModel MapDALToViewModel(IEnumerable<DAL.Model.GymDALModel> dalLocations)
        {
            var locations = new List<Location>();

            foreach (var dalLocation in dalLocations)
            {
                var location = new Location();
                location.LocationId = dalLocation.LocationId;
                location.GymName = dalLocation.GymName;
                location.OpenAfter10PM = dalLocation.OpenAfter10PM;
                location.MembershipPrice = dalLocation.MembershipPrice;
                location.City = dalLocation.City;

                locations.Add(location);
            }

            var locationsViewModel = new LocationsViewModel();
            locationsViewModel.Locations = locations;

            return locationsViewModel;
        }

        private static LocationViewModel MapADALToViewModel(GymDALModel dalLocation)
        {
            var locationViewModel = new LocationViewModel();

            locationViewModel.LocationId = dalLocation.LocationId;
            locationViewModel.GymName = dalLocation.GymName;
            locationViewModel.OpenAfter10PM = dalLocation.OpenAfter10PM;
            locationViewModel.MembershipPrice = dalLocation.MembershipPrice;
            locationViewModel.City = dalLocation.City;


            return locationViewModel;
        }

       
    }
}
