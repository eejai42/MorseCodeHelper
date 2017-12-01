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
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Guid TelegraphStationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        

        

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
            
        }
        
    }
}