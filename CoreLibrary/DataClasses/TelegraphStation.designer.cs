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
            
                this.Communications = new BindingList<Communication>();
            
                this.MCDevices = new BindingList<MCDevice>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Guid TelegraphStationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Communications")]
        public BindingList<Communication> Communications { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Communications, and load them if requested
        /// </summary>
        public static void CheckExpandCommunications(SqlDataManager sdm, IEnumerable<TelegraphStation> telegraphStations, string expandString)
        {
            var telegraphStationsWhere = CreateTelegraphStationWhere(telegraphStations);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("communications", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCommunications = sdm.GetAllCommunications<Communication>(telegraphStationsWhere);

                telegraphStations.ToList()
                        .ForEach(feTelegraphStation => feTelegraphStation.LoadCommunications(childCommunications));
            }

        }


        

        
        /// <summary>
        /// Find the related Communications (from the list provided) and attach them locally to the Communications list.
        /// </summary>
        public void LoadCommunications(IEnumerable<Communication> communications)
        {
            communications.Where(whereCommunication => whereCommunication.TelegraphStationId == this.TelegraphStationId)
                    .ToList()
                    .ForEach(feCommunication => this.Communications.Add(feCommunication));
        }
        
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
            
            
            CheckExpandCommunications(sdm, telegraphStations, expandString);
            
            CheckExpandMCDevices(sdm, telegraphStations, expandString);
        }
        
    }
}