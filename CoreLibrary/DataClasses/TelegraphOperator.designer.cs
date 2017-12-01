using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class TelegraphOperator
    {
        private void InitPoco()
        {
            
            this.TelegraphOperatorId = Guid.NewGuid();
            
                this.Communications = new BindingList<Communication>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "OperatorId")]
        public Guid TelegraphOperatorId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CommunicationId")]
        public Nullable<Guid> CommunicationId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Communications")]
        public BindingList<Communication> Communications { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Communications, and load them if requested
        /// </summary>
        public static void CheckExpandCommunications(SqlDataManager sdm, IEnumerable<TelegraphOperator> telegraphOperators, string expandString)
        {
            var telegraphOperatorsWhere = CreateTelegraphOperatorWhere(telegraphOperators);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("communications", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCommunications = sdm.GetAllCommunications<Communication>(telegraphOperatorsWhere);

                telegraphOperators.ToList()
                        .ForEach(feTelegraphOperator => feTelegraphOperator.LoadCommunications(childCommunications));
            }

        }


        

        
        /// <summary>
        /// Find the related Communications (from the list provided) and attach them locally to the Communications list.
        /// </summary>
        public void LoadCommunications(IEnumerable<Communication> communications)
        {
            communications.Where(whereCommunication => whereCommunication.TelegraphOperatorId == this.TelegraphOperatorId)
                    .ToList()
                    .ForEach(feCommunication => this.Communications.Add(feCommunication));
        }
        

        

        private static string CreateTelegraphOperatorWhere(IEnumerable<TelegraphOperator> telegraphOperators)
        {
            if (!telegraphOperators.Any()) return "1=1";
            else 
            {
                var idList = telegraphOperators.Select(selectTelegraphOperator => String.Format("'{0}'", selectTelegraphOperator.TelegraphOperatorId));
                var csIdList = String.Join(",", idList);
                return String.Format("TelegraphOperatorId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<TelegraphOperator> telegraphOperators, string expandString)
        {
            
            
            CheckExpandCommunications(sdm, telegraphOperators, expandString);
        }
        
    }
}