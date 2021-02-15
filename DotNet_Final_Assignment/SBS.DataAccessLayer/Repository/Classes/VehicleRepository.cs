using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        ///<summary>
        ///Public constructor
        ///</summary>
        public VehicleRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        /// <summary>
        /// Add Vehicle To Database
        /// </summary>
        /// <param name="vehicle">object of vehicle</param>
        /// <returns>Status of creation</returns>
        public string Create(Vehicle vehicle)
        {
            try
            {
                if(vehicle != null)
                {
                    var res = _dbContext.Vehicles.Where(x => x.LicensePlate == vehicle.LicensePlate).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }    

                    Database.Vehicle entity = new Database.Vehicle();

                    entity = autoMapperConfig.VehicleToDbVehicleMapper.Map<Database.Vehicle>(vehicle);

                    _dbContext.Vehicles.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        /// <summary>
        /// Delete Vehicle
        /// </summary>
        /// <param name="id">Id of Vehicle</param>
        /// <returns>Status of deletion</returns>
        public string Delete(int id)
        {
            try
            {
                Database.Vehicle entity = new Database.Vehicle();

                entity = _dbContext.Vehicles.Where(x => x.Id == id).FirstOrDefault();

                if(entity != null)
                {
                    _dbContext.Vehicles.Remove(entity);
                    _dbContext.SaveChanges();

                    return "deleted";
                }
                return "null";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        /// <summary>
        /// Get All Vehicles
        /// </summary>
        /// <returns>List of Vehicles</returns>
        public IEnumerable<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicleReturn = new List<Vehicle>();
            IEnumerable<Database.Vehicle> vehicles = _dbContext.Vehicles.ToList();

            foreach (var vehicle in vehicles)
            {
                Vehicle entity = new Vehicle();
                entity = autoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(vehicle);

                vehicleReturn.Add(entity);
            }

            return vehicleReturn;
        }

        /// <summary>
        /// Get single vehicle of customer
        /// </summary>
        /// <param name="customerId">Id of the customer</param>
        /// <returns>single vehicle</returns>
        public IEnumerable<Vehicle> GetVehicles(int customerId)
        {
            List<Vehicle> vehicleReturn = new List<Vehicle>();
            IEnumerable<Database.Vehicle> vehicles = _dbContext.Vehicles.Where(x => x.CustomerId == customerId).ToList();

            foreach (var vehicle in vehicles)
            {
                Vehicle entity = new Vehicle();
                entity = autoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(vehicle);

                vehicleReturn.Add(entity);
            }

            return vehicleReturn;
        }

        /// <summary>
        /// Update vehicle
        /// </summary>
        /// <param name="vehicle">object of vehicle</param>
        /// <returns>Status of Updation</returns>
        public string Update(Vehicle vehicle)
        {
            try
            {
                var entity = _dbContext.Vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefault();

                if (entity != null)
                {
                    entity.LicensePlate = vehicle.LicensePlate;
                    entity.ManufacturerId = vehicle.ManufacturerId;
                    entity.Model = vehicle.Model;
                    entity.RegistrationDate = vehicle.RegistrationDate; 
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.CustomerId = vehicle.CustomerId;

                    _dbContext.SaveChanges();

                    return "Updated";
                }
                return "null";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
