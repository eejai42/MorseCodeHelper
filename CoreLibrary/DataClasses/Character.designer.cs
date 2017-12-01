using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Character
    {
        private void InitPoco()
        {
            
            this.CharacterId = Guid.NewGuid();
            
                this.CharacterSquences = new BindingList<CharacterSquence>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Guid CharacterId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SequenceCode")]
        public String SequenceCode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Symbol")]
        public String Symbol { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AlphabetId")]
        public Nullable<Guid> AlphabetId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterSquences")]
        public BindingList<CharacterSquence> CharacterSquences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related CharacterSquences, and load them if requested
        /// </summary>
        public static void CheckExpandCharacterSquences(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("characterSquences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCharacterSquences = sdm.GetAllCharacterSquences<CharacterSquence>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadCharacterSquences(childCharacterSquences));
            }

        }


        

        
        /// <summary>
        /// Find the related CharacterSquences (from the list provided) and attach them locally to the CharacterSquences list.
        /// </summary>
        public void LoadCharacterSquences(IEnumerable<CharacterSquence> characterSquences)
        {
            characterSquences.Where(whereCharacterSquence => whereCharacterSquence.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feCharacterSquence => this.CharacterSquences.Add(feCharacterSquence));
        }
        

        

        private static string CreateCharacterWhere(IEnumerable<Character> characters)
        {
            if (!characters.Any()) return "1=1";
            else 
            {
                var idList = characters.Select(selectCharacter => String.Format("'{0}'", selectCharacter.CharacterId));
                var csIdList = String.Join(",", idList);
                return String.Format("CharacterId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            
            
            CheckExpandCharacterSquences(sdm, characters, expandString);
        }
        
    }
}