﻿using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.Sales.Currency
{
    public class CurrencyDto
    {
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; }
    }
}
