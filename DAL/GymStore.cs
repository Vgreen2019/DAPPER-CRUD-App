using Dapper;
using DapperDemo.DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DapperDemo.DAL
{
    public class GymStore : IGymStore
    {
        private readonly Database _config;

        public GymStore(DapperDemoConfiguration config)
        {
            _config = config.Database;
        }

        public IEnumerable<GymDALModel> SelectAllLocations()
        {
            var sql = @"SELECT * FROM Locations ORDER BY GymName ASC";

            using (var connection = new SqlConnection(_config.ConnectionString))   
            {
                var results = connection.Query<GymDALModel>(sql) ?? new List<GymDALModel>();
                return results;

            }
        }

        public GymDALModel SelectALocation(int id)
        {
            var sql = @"SELECT * FROM Locations WHERE LocationID = @LocationID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.QueryFirstOrDefault<GymDALModel>(sql, new { LocationID = id });
                return results;

            }
        }

        public bool InsertNewLocation(GymDALModel dalModel)
        {
            var sql = $@"INSERT INTO Locations (GymName, OpenAfter10PM, MembershipPrice, City) 
                            VALUES (@{nameof(dalModel.GymName)}, @{nameof(dalModel.OpenAfter10PM)},  @{nameof(dalModel.MembershipPrice)},  @{nameof(dalModel.City)})";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);

                if (results == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool EditLocation(GymDALModel dalModel)
        {
            var sql = $@"UPDATE Locations 
                         SET GymName = @{nameof(dalModel.GymName)}, OpenAfter10PM = @{nameof(dalModel.OpenAfter10PM)}, MembershipPrice = @{nameof(dalModel.MembershipPrice)}, City = @{nameof(dalModel.City)} 
                         WHERE LocationID = @{nameof(dalModel.LocationId)}";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);
                if (results == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteLocation(int id)
        {
            var sql = @"DELETE FROM Locations WHERE LocationID = @LocationID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, new { LocationID = id });
                if (results == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
