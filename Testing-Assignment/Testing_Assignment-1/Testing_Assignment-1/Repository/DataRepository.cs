using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing_Assignment_1.Models;

namespace Testing_Assignment_1.Repository
{
    public class DataRepository : IDataRepository
    {
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        public DataRepository()
        {
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();
            _passenger.Add(id1, new Passenger() { Id = id1, FisrtName = "Parth", LastName = "Nonghanvadra", PhoneNumber="9876543210" });
            _passenger.Add(id2, new Passenger() { Id = id2, FisrtName = "Kuldip", LastName = "Patel", PhoneNumber = "9876543210" });
            _passenger.Add(id3, new Passenger() { Id = id3, FisrtName = "Darshit", LastName = "Rawal", PhoneNumber = "9876543210" });

        }

        /// <summary>
        /// Add new Passenger to Dictionary
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>Passenger Detail</returns>
        public Passenger AddUser(Passenger passenger)
        {

            Guid newId = new Guid();
            passenger.Id = newId;
            _passenger.Add(newId, passenger);
            return passenger;
        }

        /// <summary>
        /// Update Details of Passenger to Dictionary
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>Updated Passenger details</returns>
        public Passenger Update(Passenger passenger)
        {
            Passenger obj = GetById(passenger.Id);
            if (obj == null)
                return null;
            _passenger[obj.Id] = passenger;
            return passenger;
        }

        /// <summary>
        /// Delete Passenger from Dictionary
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true if passenger is deleted otherwise false</returns>
        public bool Delete(Guid Id)
        {
            var result = _passenger.Remove(Id);
            return result;
        }

        /// <summary>
        /// Get Details of Passenger from Dictionary
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Passenger Details of given Id</returns>
        public Passenger GetById(Guid id)
        {
            return _passenger.FirstOrDefault(x => x.Key == id).Value;
        }

        /// <summary>
        /// Get List of Passengers from Dictionary
        /// </summary>
        /// <returns>List of Passengers</returns>
        public IList<Passenger> getPassengersList()
        {
            return _passenger.Select(x => x.Value).ToList();
        }
    }
}