using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Customer
    {
        private void InitPoco()
        {
            
            this.CustomerId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CustomerId")]
        public Guid CustomerId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    

        

        

        private static string CreateCustomerWhere(IEnumerable<Customer> customers)
        {
            if (!customers.Any()) return "1=1";
            else 
            {
                var idList = customers.Select(selectCustomer => String.Format("'{0}'", selectCustomer.CustomerId));
                var csIdList = String.Join(",", idList);
                return String.Format("CustomerId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Customer> customers, string expandString)
        {
            
        }
        
    }
}