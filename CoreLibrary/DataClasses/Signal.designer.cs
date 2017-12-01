using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Signal
    {
        private void InitPoco()
        {
            
            this.SignalId = Guid.NewGuid();
            
                this.CharacterSquences = new BindingList<CharacterSquence>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SignalId")]
        public Guid SignalId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Symbol")]
        public String Symbol { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ShortCode")]
        public String ShortCode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "LongCode")]
        public String LongCode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "BinaryCode")]
        public String BinaryCode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SortOrder")]
        public Int32 SortOrder { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RelativeTime")]
        public Int32 RelativeTime { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterSquences")]
        public BindingList<CharacterSquence> CharacterSquences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related CharacterSquences, and load them if requested
        /// </summary>
        public static void CheckExpandCharacterSquences(SqlDataManager sdm, IEnumerable<Signal> signals, string expandString)
        {
            var signalsWhere = CreateSignalWhere(signals);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("characterSquences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCharacterSquences = sdm.GetAllCharacterSquences<CharacterSquence>(signalsWhere);

                signals.ToList()
                        .ForEach(feSignal => feSignal.LoadCharacterSquences(childCharacterSquences));
            }

        }


        

        
        /// <summary>
        /// Find the related CharacterSquences (from the list provided) and attach them locally to the CharacterSquences list.
        /// </summary>
        public void LoadCharacterSquences(IEnumerable<CharacterSquence> characterSquences)
        {
            characterSquences.Where(whereCharacterSquence => whereCharacterSquence.SignalId == this.SignalId)
                    .ToList()
                    .ForEach(feCharacterSquence => this.CharacterSquences.Add(feCharacterSquence));
        }
        

        

        private static string CreateSignalWhere(IEnumerable<Signal> signals)
        {
            if (!signals.Any()) return "1=1";
            else 
            {
                var idList = signals.Select(selectSignal => String.Format("'{0}'", selectSignal.SignalId));
                var csIdList = String.Join(",", idList);
                return String.Format("SignalId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Signal> signals, string expandString)
        {
            
            
            CheckExpandCharacterSquences(sdm, signals, expandString);
        }
        
    }
}