using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class CharacterSquence
    {
        private void InitPoco()
        {
            
            this.CharacterSquenceId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SequenceId")]
        public Guid CharacterSquenceId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Index")]
        public Int32 Index { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Nullable<Guid> CharacterId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SignalId")]
        public Nullable<Guid> SignalId { get; set; }
    

        

        

        private static string CreateCharacterSquenceWhere(IEnumerable<CharacterSquence> characterSquences)
        {
            if (!characterSquences.Any()) return "1=1";
            else 
            {
                var idList = characterSquences.Select(selectCharacterSquence => String.Format("'{0}'", selectCharacterSquence.CharacterSquenceId));
                var csIdList = String.Join(",", idList);
                return String.Format("CharacterSquenceId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<CharacterSquence> characterSquences, string expandString)
        {
            
        }
        
    }
}