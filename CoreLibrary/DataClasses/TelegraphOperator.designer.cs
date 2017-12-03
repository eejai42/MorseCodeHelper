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
            
                this.Telegraphs = new BindingList<Telegraph>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "OperatorId")]
        public Guid TelegraphOperatorId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Nullable<Guid> TelegraphStationId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Telegraphs")]
        public BindingList<Telegraph> Telegraphs { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Telegraphs, and load them if requested
        /// </summary>
        public static void CheckExpandTelegraphs(SqlDataManager sdm, IEnumerable<TelegraphOperator> telegraphOperators, string expandString)
        {
            var telegraphOperatorsWhere = CreateTelegraphOperatorWhere(telegraphOperators);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("telegraphs", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTelegraphs = sdm.GetAllTelegraphs<Telegraph>(telegraphOperatorsWhere);

                telegraphOperators.ToList()
                        .ForEach(feTelegraphOperator => feTelegraphOperator.LoadTelegraphs(childTelegraphs));
            }

        }


        

        
        /// <summary>
        /// Find the related Telegraphs (from the list provided) and attach them locally to the Telegraphs list.
        /// </summary>
        public void LoadTelegraphs(IEnumerable<Telegraph> telegraphs)
        {
            telegraphs.Where(whereTelegraph => whereTelegraph.TelegraphOperatorId == this.TelegraphOperatorId)
                    .ToList()
                    .ForEach(feTelegraph => this.Telegraphs.Add(feTelegraph));
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
            
            
            CheckExpandTelegraphs(sdm, telegraphOperators, expandString);
        }
        
    }
}