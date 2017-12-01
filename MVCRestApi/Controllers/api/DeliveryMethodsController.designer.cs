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
    public partial class DeliveryMethodsController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<DeliveryMethod> DeliveryMethods);
        partial void OnAfterGetById(DeliveryMethod DeliveryMethods, Guid deliverymethodId);
        partial void OnBeforePost(DeliveryMethod deliverymethod);
        partial void OnAfterPost(DeliveryMethod deliverymethod);
        partial void OnBeforePut(DeliveryMethod deliverymethod);
        partial void OnAfterPut(DeliveryMethod deliverymethod);
        partial void OnBeforeDelete(DeliveryMethod deliverymethod);
        partial void OnAfterDelete(DeliveryMethod deliverymethod);
        

        public DeliveryMethodsController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/DeliveryMethod
        public IEnumerable<DeliveryMethod> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllDeliveryMethods<DeliveryMethod>();
            DeliveryMethod.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/DeliveryMethods/{deliverymethod-guid}
        public DeliveryMethod Get(Guid deliverymethodId)
        {
            var DeliveryMethodsWhere = String.Format("DeliveryMethodId = '{0}'", deliverymethodId);
            var result = this.SDM.GetAllDeliveryMethods<DeliveryMethod>(DeliveryMethodsWhere).FirstOrDefault();
            this.OnAfterGetById(result, deliverymethodId);
            return result;
        }

        // POST api/DeliveryMethods/{deliverymethod-guid}
        public DeliveryMethod Post([FromBody]DeliveryMethod deliverymethod)
        {
            if (deliverymethod.DeliveryMethodId == Guid.Empty) deliverymethod.DeliveryMethodId = Guid.NewGuid();
            this.OnBeforePost(deliverymethod);
            this.SDM.Upsert(deliverymethod);
            this.OnAfterPost(deliverymethod);
            return deliverymethod;
        }

        // POST api/DeliveryMethods/{deliverymethod-guid}
        public DeliveryMethod Put([FromBody]DeliveryMethod deliverymethod)
        {
            if (deliverymethod.DeliveryMethodId == Guid.Empty) deliverymethod.DeliveryMethodId = Guid.NewGuid();
            this.OnBeforePut(deliverymethod);
            this.SDM.Upsert(deliverymethod);
            this.OnAfterPut(deliverymethod);
            return deliverymethod;
        }

        // POST api/DeliveryMethods/{deliverymethod-guid}
        public void Delete(Guid deliverymethodId)
        {
            var deliverymethodWhere = String.Format("DeliveryMethodId = '{0}'", deliverymethodId);
            var deliverymethod = this.SDM.GetAllDeliveryMethods<DeliveryMethod>(deliverymethodWhere).FirstOrDefault();
            this.OnBeforeDelete(deliverymethod);
            this.SDM.Delete(deliverymethod);
            this.OnAfterDelete(deliverymethod);
        }
    }
}
