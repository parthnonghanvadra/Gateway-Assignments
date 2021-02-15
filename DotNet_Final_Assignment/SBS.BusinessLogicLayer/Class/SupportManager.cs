﻿using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interface;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessLogicLayer.Class
{
    public class SupportManager : ISupportManager
    {
        private readonly ISupportRepository _supportRepository;

        public SupportManager(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;
        }
        public IEnumerable<Dealer> GetDealers()
        {
            return _supportRepository.GetDealers();
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _supportRepository.GetManufacturers();
        }
    }
}
