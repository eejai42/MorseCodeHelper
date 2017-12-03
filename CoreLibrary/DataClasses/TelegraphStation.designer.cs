using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class TelegraphStation
    {
        private void InitPoco()
        {
            
            this.TelegraphStationId = Guid.NewGuid();
            
                this.MCDevices = new BindingList<MCDevice>();
            
                this.TelegraphOperators = new BindingList<TelegraphOperator>();
            
                this.Customers = new BindingList<Customer>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Guid TelegraphStationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MCDevices")]
        public BindingList<MCDevice> MCDevices { get; set; }
            
        /// <summary>
        /// Check to see if there are any related MCDevices, and load them if requested
        /// </summary>
        public static void CheckExpandMCDevices(SqlDataManager sdm, IEnumerable<TelegraphStation> telegraphStations, string expandString)
        {
            var telegraphStationsWhere = CreateTelegraphStationWhere(telegraphStations);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("mCDevices", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childMCDevices = sdm.GetAllMCDevices<MCDevice>(telegraphStationsWhere);

                telegraphStations.ToList()
                        .ForEach(feTelegraphStation => feTelegraphStation.LoadMCDevices(childMCDevices));
            }

        }


        

        
        /// <summary>
        /// Find the related MCDevices (from the list provided) and attach them locally to the MCDevices list.
        /// </summary>
        public void LoadMCDevices(IEnumerable<MCDevice> mCDevices)
        {
            mCDevices.Where(whereMCDevice => whereMCDevice.TelegraphStationId == this.TelegraphStationId)
                    .ToList()
                    .ForEach(feMCDevice => this.MCDevices.Add(feMCDevice));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphOperators")]
        public BindingList<TelegraphOperator> TelegraphOperators { get; set; }
            
        /// <summary>
        /// Check to see if there are any related TelegraphOperators, and load them if requested
        /// </summary>
        public static void CheckExpandTelegraphOperators(SqlDataManager sdm, IEnumerable<TelegraphStation> telegraphStations, string expandString)
        {
            var telegraphStationsWhere = CreateTelegraphStationWhere(telegraphStations);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("telegraphOperators", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTelegraphOperators = sdm.GetAllTelegraphOperators<TelegraphOperator>(telegraphStationsWhere);

                telegraphStations.ToList()
                        .ForEach(feTelegraphStation => feTelegraphStation.LoadTelegraphOperators(childTelegraphOperators));
            }

        }


        

        
        /// <summary>
        /// Find the related TelegraphOperators (from the list provided) and attach them locally to the TelegraphOperators list.
        /// </summary>
        public void LoadTelegraphOperators(IEnumerable<TelegraphOperator> telegraphOperators)
        {
            telegraphOperators.Where(whereTelegraphOperator => whereTelegraphOperator.TelegraphStationId == this.TelegraphStationId)
                    .ToList()
                    .ForEach(feTelegraphOperator => this.TelegraphOperators.Add(feTelegraphOperator));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Customers")]
        public BindingList<Customer> Customers { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Customers, and load them if requested
        /// </summary>
        public static void CheckExpandCustomers(SqlDataManager sdm, IEnumerable<TelegraphStation> telegraphStations, string expandString)
        {
            var telegraphStationsWhere = CreateTelegraphStationWhere(telegraphStations);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("customers", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCustomers = sdm.GetAllCustomers<Customer>(telegraphStationsWhere);

                telegraphStations.ToList()
                        .ForEach(feTelegraphStation => feTelegraphStation.LoadCustomers(childCustomers));
            }

        }


        

        
        /// <summary>
        /// Find the related Customers (from the list provided) and attach them locally to the Customers list.
        /// </summary>
        public void LoadCustomers(IEnumerable<Customer> customers)
        {
            customers.Where(whereCustomer => whereCustomer.TelegraphStationId == this.TelegraphStationId)
                    .ToList()
                    .ForEach(feCustomer => this.Customers.Add(feCustomer));
        }
        

        

        private static string CreateTelegraphStationWhere(IEnumerable<TelegraphStation> telegraphStations)
        {
            if (!telegraphStations.Any()) return "1=1";
            else 
            {
                var idList = telegraphStations.Select(selectTelegraphStation => String.Format("'{0}'", selectTelegraphStation.TelegraphStationId));
                var csIdList = String.Join(",", idList);
                return String.Format("TelegraphStationId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<TelegraphStation> telegraphStations, string expandString)
        {
            
            
            CheckExpandMCDevices(sdm, telegraphStations, expandString);
            
            CheckExpandTelegraphOperators(sdm, telegraphStations, expandString);
            
            CheckExpandCustomers(sdm, telegraphStations, expandString);
        }
        
    }
}