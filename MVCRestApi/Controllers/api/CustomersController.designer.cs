using MorseCodeHelper.Lib.SqlDataManagement;
using MorseCodeHelper.Lib.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApplication1.Areas.RESTApi.Controllers
{
    public partial class CustomersController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<Customer> Customers);
        partial void OnAfterGetById(Customer Customers, Guid customerId);
        partial void OnBeforePost(Customer customer);
        partial void OnAfterPost(Customer customer);
        partial void OnBeforePut(Customer customer);
        partial void OnAfterPut(Customer customer);
        partial void OnBeforeDelete(Customer customer);
        partial void OnAfterDelete(Customer customer);
        

        public CustomersController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/Customer
        public IEnumerable<Customer> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllCustomers<Customer>();
            Customer.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/Customers/{customer-guid}
        public Customer Get(Guid customerId)
        {
            var CustomersWhere = String.Format("CustomerId = '{0}'", customerId);
            var result = this.SDM.GetAllCustomers<Customer>(CustomersWhere).FirstOrDefault();
            this.OnAfterGetById(result, customerId);
            return result;
        }

        // POST api/Customers/{customer-guid}
        public Customer Post([FromBody]Customer customer)
        {
            if (customer.CustomerId == Guid.Empty) customer.CustomerId = Guid.NewGuid();
            this.OnBeforePost(customer);
            this.SDM.Upsert(customer);
            this.OnAfterPost(customer);
            return customer;
        }

        // POST api/Customers/{customer-guid}
        public Customer Put([FromBody]Customer customer)
        {
            if (customer.CustomerId == Guid.Empty) customer.CustomerId = Guid.NewGuid();
            this.OnBeforePut(customer);
            this.SDM.Upsert(customer);
            this.OnAfterPut(customer);
            return customer;
        }

        // POST api/Customers/{customer-guid}
        public void Delete(Guid customerId)
        {
            var customerWhere = String.Format("CustomerId = '{0}'", customerId);
            var customer = this.SDM.GetAllCustomers<Customer>(customerWhere).FirstOrDefault();
            this.OnBeforeDelete(customer);
            this.SDM.Delete(customer);
            this.OnAfterDelete(customer);
        }
    }
}
