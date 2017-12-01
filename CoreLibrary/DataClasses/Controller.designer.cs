using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Controller
    {
        private void InitPoco()
        {
            
            this.ControllerId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ControllerId")]
        public Guid ControllerId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CommunicationId")]
        public Nullable<Guid> CommunicationId { get; set; }
    

        

        

        private static string CreateControllerWhere(IEnumerable<Controller> controllers)
        {
            if (!controllers.Any()) return "1=1";
            else 
            {
                var idList = controllers.Select(selectController => String.Format("'{0}'", selectController.ControllerId));
                var csIdList = String.Join(",", idList);
                return String.Format("ControllerId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Controller> controllers, string expandString)
        {
            
        }
        
    }
}