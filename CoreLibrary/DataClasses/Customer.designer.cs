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
            
                this.Telegraphs = new BindingList<Telegraph>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CustomerId")]
        public Guid CustomerId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Nullable<Guid> TelegraphStationId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Telegraphs")]
        public BindingList<Telegraph> Telegraphs { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Telegraphs, and load them if requested
        /// </summary>
        public static void CheckExpandTelegraphs(SqlDataManager sdm, IEnumerable<Customer> customers, string expandString)
        {
            var customersWhere = CreateCustomerWhere(customers);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("telegraphs", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTelegraphs = sdm.GetAllTelegraphs<Telegraph>(customersWhere);

                customers.ToList()
                        .ForEach(feCustomer => feCustomer.LoadTelegraphs(childTelegraphs));
            }

        }


        

        
        /// <summary>
        /// Find the related Telegraphs (from the list provided) and attach them locally to the Telegraphs list.
        /// </summary>
        public void LoadTelegraphs(IEnumerable<Telegraph> telegraphs)
        {
            telegraphs.Where(whereTelegraph => whereTelegraph.CustomerId == this.CustomerId)
                    .ToList()
                    .ForEach(feTelegraph => this.Telegraphs.Add(feTelegraph));
        }
        

        

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
            
            
            CheckExpandTelegraphs(sdm, customers, expandString);
        }
        
    }
}