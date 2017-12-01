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
            
                this.Punctuations = new BindingList<Punctuation>();
            
                this.Symbols = new BindingList<Symbol>();
            
                this.Numerals = new BindingList<Numeral>();
            
                this.Silences = new BindingList<Silence>();
            
                this.Spaces = new BindingList<Space>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Guid CharacterId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AlphabetId")]
        public Nullable<Guid> AlphabetId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Punctuations")]
        public BindingList<Punctuation> Punctuations { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Punctuations, and load them if requested
        /// </summary>
        public static void CheckExpandPunctuations(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("punctuations", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childPunctuations = sdm.GetAllPunctuations<Punctuation>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadPunctuations(childPunctuations));
            }

        }


        

        
        /// <summary>
        /// Find the related Punctuations (from the list provided) and attach them locally to the Punctuations list.
        /// </summary>
        public void LoadPunctuations(IEnumerable<Punctuation> punctuations)
        {
            punctuations.Where(wherePunctuation => wherePunctuation.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(fePunctuation => this.Punctuations.Add(fePunctuation));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Symbols")]
        public BindingList<Symbol> Symbols { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Symbols, and load them if requested
        /// </summary>
        public static void CheckExpandSymbols(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("symbols", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSymbols = sdm.GetAllSymbols<Symbol>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadSymbols(childSymbols));
            }

        }


        

        
        /// <summary>
        /// Find the related Symbols (from the list provided) and attach them locally to the Symbols list.
        /// </summary>
        public void LoadSymbols(IEnumerable<Symbol> symbols)
        {
            symbols.Where(whereSymbol => whereSymbol.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feSymbol => this.Symbols.Add(feSymbol));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Numerals")]
        public BindingList<Numeral> Numerals { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Numerals, and load them if requested
        /// </summary>
        public static void CheckExpandNumerals(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("numerals", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childNumerals = sdm.GetAllNumerals<Numeral>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadNumerals(childNumerals));
            }

        }


        

        
        /// <summary>
        /// Find the related Numerals (from the list provided) and attach them locally to the Numerals list.
        /// </summary>
        public void LoadNumerals(IEnumerable<Numeral> numerals)
        {
            numerals.Where(whereNumeral => whereNumeral.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feNumeral => this.Numerals.Add(feNumeral));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Silences")]
        public BindingList<Silence> Silences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Silences, and load them if requested
        /// </summary>
        public static void CheckExpandSilences(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("silences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSilences = sdm.GetAllSilences<Silence>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadSilences(childSilences));
            }

        }


        

        
        /// <summary>
        /// Find the related Silences (from the list provided) and attach them locally to the Silences list.
        /// </summary>
        public void LoadSilences(IEnumerable<Silence> silences)
        {
            silences.Where(whereSilence => whereSilence.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feSilence => this.Silences.Add(feSilence));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Spaces")]
        public BindingList<Space> Spaces { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Spaces, and load them if requested
        /// </summary>
        public static void CheckExpandSpaces(SqlDataManager sdm, IEnumerable<Character> characters, string expandString)
        {
            var charactersWhere = CreateCharacterWhere(characters);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("spaces", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSpaces = sdm.GetAllSpaces<Space>(charactersWhere);

                characters.ToList()
                        .ForEach(feCharacter => feCharacter.LoadSpaces(childSpaces));
            }

        }


        

        
        /// <summary>
        /// Find the related Spaces (from the list provided) and attach them locally to the Spaces list.
        /// </summary>
        public void LoadSpaces(IEnumerable<Space> spaces)
        {
            spaces.Where(whereSpace => whereSpace.CharacterId == this.CharacterId)
                    .ToList()
                    .ForEach(feSpace => this.Spaces.Add(feSpace));
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
            
            
            CheckExpandPunctuations(sdm, characters, expandString);
            
            CheckExpandSymbols(sdm, characters, expandString);
            
            CheckExpandNumerals(sdm, characters, expandString);
            
            CheckExpandSilences(sdm, characters, expandString);
            
            CheckExpandSpaces(sdm, characters, expandString);
        }
        
    }
}