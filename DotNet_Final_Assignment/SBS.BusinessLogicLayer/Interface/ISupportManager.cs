﻿using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessLogicLayer.Interface
{
    public interface ISupportManager
    {
        IEnumerable<Dealer> GetDealers();
        IEnumerable<Manufacturer> GetManufacturers();
    }
}
