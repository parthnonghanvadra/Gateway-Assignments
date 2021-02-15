using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class SupportRepository : ISupportRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        ///<summary>
        ///Public constructor
        ///</summary>
        public SupportRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        /// <summary>
        /// Get All Dealers
        /// </summary>
        /// <returns>List of Dealers</returns>
        public IEnumerable<Dealer> GetDealers()
        {
            List<Dealer> dealerReturn = new List<Dealer>();
            IEnumerable<Database.Dealer> dealers = _dbContext.Dealers.ToList();

            foreach (var dealer in dealers)
            {
                Dealer entity = new Dealer();
                entity = autoMapperConfig.DbDealerToDealerMapper.Map<Dealer>(dealer);

                dealerReturn.Add(entity);
            }

            return dealerReturn;
        }

        /// <summary>
        /// Get All Manufacturers
        /// </summary>
        /// <returns>List of Manufacturers</returns>
        public IEnumerable<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturerReturn = new List<Manufacturer>();
            IEnumerable<Database.Manufacturer> manufacturers = _dbContext.Manufacturers.ToList();

            foreach (var manufacturer in manufacturers)
            {
                Manufacturer entity = new Manufacturer();
                entity = autoMapperConfig.DbManufacturerToManufacturerMapper.Map<Manufacturer>(manufacturer);

                manufacturerReturn.Add(entity);
            }

            return manufacturerReturn;
        }
    }
}
