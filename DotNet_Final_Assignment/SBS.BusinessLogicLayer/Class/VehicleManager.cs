using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interface;
using SBS.DataAccessLayer.Repository.Interfaces;

namespace SBS.BusinessLogicLayer.Class
{
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public string Create(Vehicle vehicle)
        {
            return _vehicleRepository.Create(vehicle);
        }

        public string Delete(int id)
        {
            return _vehicleRepository.Delete(id);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetVehicles();
        }

        public IEnumerable<Vehicle> GetVehicles(int customerId)
        {
            return _vehicleRepository.GetVehicles(customerId);
        }

        public string Update(Vehicle vehicle)
        {
            return _vehicleRepository.Update(vehicle);
        }
    }
}
