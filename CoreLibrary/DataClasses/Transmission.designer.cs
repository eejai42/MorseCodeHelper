using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Transmission
    {
        private void InitPoco()
        {
            
            this.TransmissionId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TransmissionId")]
        public Guid TransmissionId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphId")]
        public Nullable<Guid> TelegraphId { get; set; }
    

        

        

        private static string CreateTransmissionWhere(IEnumerable<Transmission> transmissions)
        {
            if (!transmissions.Any()) return "1=1";
            else 
            {
                var idList = transmissions.Select(selectTransmission => String.Format("'{0}'", selectTransmission.TransmissionId));
                var csIdList = String.Join(",", idList);
                return String.Format("TransmissionId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Transmission> transmissions, string expandString)
        {
            
        }
        
    }
}