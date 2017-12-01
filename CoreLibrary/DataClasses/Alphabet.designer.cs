using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Alphabet
    {
        private void InitPoco()
        {
            
            this.AlphabetId = Guid.NewGuid();
            
                this.Characters = new BindingList<Character>();
            
                this.Communications = new BindingList<Communication>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AlphabetId")]
        public Guid AlphabetId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CountryId")]
        public Nullable<Guid> CountryId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Characters")]
        public BindingList<Character> Characters { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Characters, and load them if requested
        /// </summary>
        public static void CheckExpandCharacters(SqlDataManager sdm, IEnumerable<Alphabet> alphabets, string expandString)
        {
            var alphabetsWhere = CreateAlphabetWhere(alphabets);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("characters", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCharacters = sdm.GetAllCharacters<Character>(alphabetsWhere);

                alphabets.ToList()
                        .ForEach(feAlphabet => feAlphabet.LoadCharacters(childCharacters));
            }

        }


        

        
        /// <summary>
        /// Find the related Characters (from the list provided) and attach them locally to the Characters list.
        /// </summary>
        public void LoadCharacters(IEnumerable<Character> characters)
        {
            characters.Where(whereCharacter => whereCharacter.AlphabetId == this.AlphabetId)
                    .ToList()
                    .ForEach(feCharacter => this.Characters.Add(feCharacter));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Communications")]
        public BindingList<Communication> Communications { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Communications, and load them if requested
        /// </summary>
        public static void CheckExpandCommunications(SqlDataManager sdm, IEnumerable<Alphabet> alphabets, string expandString)
        {
            var alphabetsWhere = CreateAlphabetWhere(alphabets);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("communications", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childCommunications = sdm.GetAllCommunications<Communication>(alphabetsWhere);

                alphabets.ToList()
                        .ForEach(feAlphabet => feAlphabet.LoadCommunications(childCommunications));
            }

        }


        

        
        /// <summary>
        /// Find the related Communications (from the list provided) and attach them locally to the Communications list.
        /// </summary>
        public void LoadCommunications(IEnumerable<Communication> communications)
        {
            communications.Where(whereCommunication => whereCommunication.AlphabetId == this.AlphabetId)
                    .ToList()
                    .ForEach(feCommunication => this.Communications.Add(feCommunication));
        }
        

        

        private static string CreateAlphabetWhere(IEnumerable<Alphabet> alphabets)
        {
            if (!alphabets.Any()) return "1=1";
            else 
            {
                var idList = alphabets.Select(selectAlphabet => String.Format("'{0}'", selectAlphabet.AlphabetId));
                var csIdList = String.Join(",", idList);
                return String.Format("AlphabetId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Alphabet> alphabets, string expandString)
        {
            
            
            CheckExpandCharacters(sdm, alphabets, expandString);
            
            CheckExpandCommunications(sdm, alphabets, expandString);
        }
        
    }
}