using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class MorseCode
    {
        private void InitPoco()
        {
            
            this.MorseCodeId = Guid.NewGuid();
            
                this.DeliveryMethods = new BindingList<DeliveryMethod>();
            
                this.Alphabets = new BindingList<Alphabet>();
            
                this.Units = new BindingList<Unit>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CodeId")]
        public Guid MorseCodeId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DeliveryMethods")]
        public BindingList<DeliveryMethod> DeliveryMethods { get; set; }
            
        /// <summary>
        /// Check to see if there are any related DeliveryMethods, and load them if requested
        /// </summary>
        public static void CheckExpandDeliveryMethods(SqlDataManager sdm, IEnumerable<MorseCode> morseCodes, string expandString)
        {
            var morseCodesWhere = CreateMorseCodeWhere(morseCodes);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("deliveryMethods", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childDeliveryMethods = sdm.GetAllDeliveryMethods<DeliveryMethod>(morseCodesWhere);

                morseCodes.ToList()
                        .ForEach(feMorseCode => feMorseCode.LoadDeliveryMethods(childDeliveryMethods));
            }

        }


        

        
        /// <summary>
        /// Find the related DeliveryMethods (from the list provided) and attach them locally to the DeliveryMethods list.
        /// </summary>
        public void LoadDeliveryMethods(IEnumerable<DeliveryMethod> deliveryMethods)
        {
            deliveryMethods.Where(whereDeliveryMethod => whereDeliveryMethod.MorseCodeId == this.MorseCodeId)
                    .ToList()
                    .ForEach(feDeliveryMethod => this.DeliveryMethods.Add(feDeliveryMethod));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Alphabets")]
        public BindingList<Alphabet> Alphabets { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Alphabets, and load them if requested
        /// </summary>
        public static void CheckExpandAlphabets(SqlDataManager sdm, IEnumerable<MorseCode> morseCodes, string expandString)
        {
            var morseCodesWhere = CreateMorseCodeWhere(morseCodes);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("alphabets", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childAlphabets = sdm.GetAllAlphabets<Alphabet>(morseCodesWhere);

                morseCodes.ToList()
                        .ForEach(feMorseCode => feMorseCode.LoadAlphabets(childAlphabets));
            }

        }


        

        
        /// <summary>
        /// Find the related Alphabets (from the list provided) and attach them locally to the Alphabets list.
        /// </summary>
        public void LoadAlphabets(IEnumerable<Alphabet> alphabets)
        {
            alphabets.Where(whereAlphabet => whereAlphabet.MorseCodeId == this.MorseCodeId)
                    .ToList()
                    .ForEach(feAlphabet => this.Alphabets.Add(feAlphabet));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Units")]
        public BindingList<Unit> Units { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Units, and load them if requested
        /// </summary>
        public static void CheckExpandUnits(SqlDataManager sdm, IEnumerable<MorseCode> morseCodes, string expandString)
        {
            var morseCodesWhere = CreateMorseCodeWhere(morseCodes);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("units", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childUnits = sdm.GetAllUnits<Unit>(morseCodesWhere);

                morseCodes.ToList()
                        .ForEach(feMorseCode => feMorseCode.LoadUnits(childUnits));
            }

        }


        

        
        /// <summary>
        /// Find the related Units (from the list provided) and attach them locally to the Units list.
        /// </summary>
        public void LoadUnits(IEnumerable<Unit> units)
        {
            units.Where(whereUnit => whereUnit.MorseCodeId == this.MorseCodeId)
                    .ToList()
                    .ForEach(feUnit => this.Units.Add(feUnit));
        }
        

        

        private static string CreateMorseCodeWhere(IEnumerable<MorseCode> morseCodes)
        {
            if (!morseCodes.Any()) return "1=1";
            else 
            {
                var idList = morseCodes.Select(selectMorseCode => String.Format("'{0}'", selectMorseCode.MorseCodeId));
                var csIdList = String.Join(",", idList);
                return String.Format("MorseCodeId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<MorseCode> morseCodes, string expandString)
        {
            
            
            CheckExpandDeliveryMethods(sdm, morseCodes, expandString);
            
            CheckExpandAlphabets(sdm, morseCodes, expandString);
            
            CheckExpandUnits(sdm, morseCodes, expandString);
        }
        
    }
}