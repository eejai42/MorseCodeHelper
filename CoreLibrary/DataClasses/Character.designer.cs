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
            
                this.Sequences = new BindingList<Sequence>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Guid CharacterId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Symbol")]
        public String Symbol { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AlphabetId")]
        public Nullable<Guid> AlphabetId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Sequences")]
        public BindingList<Sequence> Sequences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Sequences, and load them if requested
        /// </summary>
        public static void CheckExpandSequences(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("sequences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSequences = sdm.GetAllSequences<Sequence>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadSequences(childSequences));
            }

        }


        

        
        /// <summary>
        /// Find the related Sequences (from the list provided) and attach them locally to the Sequences list.
        /// </summary>
        public void LoadSequences(IEnumerable<Sequence> sequences)
        {
            sequences.Where(whereSequence => whereSequence.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feSequence => this.Sequences.Add(feSequence));
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
            
            
            CheckExpandSequences(sdm, characters, expandString);
        }
        
    }
}