﻿using System;
using System.Collections.Generic;
using Otus.Teaching.Pcf.Common.Dto;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;

 namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Mappers
{
    public class PromoCodeMapper
    {
        public static PromoCode MapFromModel(GivePromoCodeToCustomerDto request, Preference preference, IEnumerable<Customer> customers) {

            var promocode = new PromoCode();
            promocode.Id = request.PromoCodeId;
            
            promocode.PartnerId = request.PartnerId;
            promocode.Code = request.PromoCode;
            promocode.ServiceInfo = request.ServiceInfo;
           
            promocode.BeginDate = DateTime.Parse(request.BeginDate);
            promocode.EndDate = DateTime.Parse(request.EndDate);

            promocode.Preference = preference;
            promocode.PreferenceId = preference.Id;

            promocode.Customers = new List<PromoCodeCustomer>();

            foreach (var item in customers)
            {
                promocode.Customers.Add(new PromoCodeCustomer()
                {

                    CustomerId = item.Id,
                    Customer = item,
                    PromoCodeId = promocode.Id,
                    PromoCode = promocode
                });
            };

            return promocode;
        }
    }
}