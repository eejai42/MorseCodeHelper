using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Numeral
    {
        private void InitPoco()
        {
            
            this.NumeralId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "NumeralId")]
        public Guid NumeralId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Nullable<Guid> CharacterId { get; set; }
    

        

        

        private static string CreateNumeralWhere(IEnumerable<Numeral> numerals)
        {
            if (!numerals.Any()) return "1=1";
            else 
            {
                var idList = numerals.Select(selectNumeral => String.Format("'{0}'", selectNumeral.NumeralId));
                var csIdList = String.Join(",", idList);
                return String.Format("NumeralId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Numeral> numerals, string expandString)
        {
            
        }
        
    }
}