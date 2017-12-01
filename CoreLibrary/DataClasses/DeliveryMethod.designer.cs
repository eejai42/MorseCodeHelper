using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class DeliveryMethod
    {
        private void InitPoco()
        {
            
            this.DeliveryMethodId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MethodId")]
        public Guid DeliveryMethodId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "MorseCodeId")]
        public Nullable<Guid> MorseCodeId { get; set; }
    

        

        

        private static string CreateDeliveryMethodWhere(IEnumerable<DeliveryMethod> deliveryMethods)
        {
            if (!deliveryMethods.Any()) return "1=1";
            else 
            {
                var idList = deliveryMethods.Select(selectDeliveryMethod => String.Format("'{0}'", selectDeliveryMethod.DeliveryMethodId));
                var csIdList = String.Join(",", idList);
                return String.Format("DeliveryMethodId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<DeliveryMethod> deliveryMethods, string expandString)
        {
            
        }
        
    }
}