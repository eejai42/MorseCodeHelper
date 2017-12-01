using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Country
    {
        private void InitPoco()
        {
            
            this.CountryId = Guid.NewGuid();
            
                this.Alphabets = new BindingList<Alphabet>();
            
                this.Languages = new BindingList<Language>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CountryId")]
        public Guid CountryId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Alphabets")]
        public BindingList<Alphabet> Alphabets { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Alphabets, and load them if requested
        /// </summary>
        public static void CheckExpandAlphabets(SqlDataManager sdm, IEnumerable<Country> countries, string expandString)
        {
            var countriesWhere = CreateCountryWhere(countries);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("alphabets", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childAlphabets = sdm.GetAllAlphabets<Alphabet>(countriesWhere);

                countries.ToList()
                        .ForEach(feCountry => feCountry.LoadAlphabets(childAlphabets));
            }

        }


        

        
        /// <summary>
        /// Find the related Alphabets (from the list provided) and attach them locally to the Alphabets list.
        /// </summary>
        public void LoadAlphabets(IEnumerable<Alphabet> alphabets)
        {
            alphabets.Where(whereAlphabet => whereAlphabet.CountryId == this.CountryId)
                    .ToList()
                    .ForEach(feAlphabet => this.Alphabets.Add(feAlphabet));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Languages")]
        public BindingList<Language> Languages { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Languages, and load them if requested
        /// </summary>
        public static void CheckExpandLanguages(SqlDataManager sdm, IEnumerable<Country> countries, string expandString)
        {
            var countriesWhere = CreateCountryWhere(countries);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("languages", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childLanguages = sdm.GetAllLanguages<Language>(countriesWhere);

                countries.ToList()
                        .ForEach(feCountry => feCountry.LoadLanguages(childLanguages));
            }

        }


        

        
        /// <summary>
        /// Find the related Languages (from the list provided) and attach them locally to the Languages list.
        /// </summary>
        public void LoadLanguages(IEnumerable<Language> languages)
        {
            languages.Where(whereLanguage => whereLanguage.CountryId == this.CountryId)
                    .ToList()
                    .ForEach(feLanguage => this.Languages.Add(feLanguage));
        }
        

        

        private static string CreateCountryWhere(IEnumerable<Country> countries)
        {
            if (!countries.Any()) return "1=1";
            else 
            {
                var idList = countries.Select(selectCountry => String.Format("'{0}'", selectCountry.CountryId));
                var csIdList = String.Join(",", idList);
                return String.Format("CountryId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Country> countries, string expandString)
        {
            
            
            CheckExpandAlphabets(sdm, countries, expandString);
            
            CheckExpandLanguages(sdm, countries, expandString);
        }
        
    }
}