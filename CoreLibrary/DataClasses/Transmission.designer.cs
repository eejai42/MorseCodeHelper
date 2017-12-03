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
            
                this.Understandings = new BindingList<Understanding>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TransmissionId")]
        public Guid TransmissionId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphId")]
        public Nullable<Guid> TelegraphId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Understandings")]
        public BindingList<Understanding> Understandings { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Understandings, and load them if requested
        /// </summary>
        public static void CheckExpandUnderstandings(SqlDataManager sdm, IEnumerable<Transmission> transmissions, string expandString)
        {
            var transmissionsWhere = CreateTransmissionWhere(transmissions);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("understandings", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childUnderstandings = sdm.GetAllUnderstandings<Understanding>(transmissionsWhere);

                transmissions.ToList()
                        .ForEach(feTransmission => feTransmission.LoadUnderstandings(childUnderstandings));
            }

        }


        

        
        /// <summary>
        /// Find the related Understandings (from the list provided) and attach them locally to the Understandings list.
        /// </summary>
        public void LoadUnderstandings(IEnumerable<Understanding> understandings)
        {
            understandings.Where(whereUnderstanding => whereUnderstanding.TransmissionId == this.TransmissionId)
                    .ToList()
                    .ForEach(feUnderstanding => this.Understandings.Add(feUnderstanding));
        }
        

        

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
            
            
            CheckExpandUnderstandings(sdm, transmissions, expandString);
        }
        
    }
}