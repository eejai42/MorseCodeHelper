using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Symbol
    {
        private void InitPoco()
        {
            
            this.SymbolId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SymbolId")]
        public Guid SymbolId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Nullable<Guid> CharacterId { get; set; }
    

        

        

        private static string CreateSymbolWhere(IEnumerable<Symbol> symbols)
        {
            if (!symbols.Any()) return "1=1";
            else 
            {
                var idList = symbols.Select(selectSymbol => String.Format("'{0}'", selectSymbol.SymbolId));
                var csIdList = String.Join(",", idList);
                return String.Format("SymbolId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Symbol> symbols, string expandString)
        {
            
        }
        
    }
}