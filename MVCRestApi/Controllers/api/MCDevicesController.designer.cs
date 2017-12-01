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
    public partial class MCDevicesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<MCDevice> MCDevices);
        partial void OnAfterGetById(MCDevice MCDevices, Guid mcdeviceId);
        partial void OnBeforePost(MCDevice mcdevice);
        partial void OnAfterPost(MCDevice mcdevice);
        partial void OnBeforePut(MCDevice mcdevice);
        partial void OnAfterPut(MCDevice mcdevice);
        partial void OnBeforeDelete(MCDevice mcdevice);
        partial void OnAfterDelete(MCDevice mcdevice);
        

        public MCDevicesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/MCDevice
        public IEnumerable<MCDevice> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllMCDevices<MCDevice>();
            MCDevice.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/MCDevices/{mcdevice-guid}
        public MCDevice Get(Guid mcdeviceId)
        {
            var MCDevicesWhere = String.Format("MCDeviceId = '{0}'", mcdeviceId);
            var result = this.SDM.GetAllMCDevices<MCDevice>(MCDevicesWhere).FirstOrDefault();
            this.OnAfterGetById(result, mcdeviceId);
            return result;
        }

        // POST api/MCDevices/{mcdevice-guid}
        public MCDevice Post([FromBody]MCDevice mcdevice)
        {
            if (mcdevice.MCDeviceId == Guid.Empty) mcdevice.MCDeviceId = Guid.NewGuid();
            this.OnBeforePost(mcdevice);
            this.SDM.Upsert(mcdevice);
            this.OnAfterPost(mcdevice);
            return mcdevice;
        }

        // POST api/MCDevices/{mcdevice-guid}
        public MCDevice Put([FromBody]MCDevice mcdevice)
        {
            if (mcdevice.MCDeviceId == Guid.Empty) mcdevice.MCDeviceId = Guid.NewGuid();
            this.OnBeforePut(mcdevice);
            this.SDM.Upsert(mcdevice);
            this.OnAfterPut(mcdevice);
            return mcdevice;
        }

        // POST api/MCDevices/{mcdevice-guid}
        public void Delete(Guid mcdeviceId)
        {
            var mcdeviceWhere = String.Format("MCDeviceId = '{0}'", mcdeviceId);
            var mcdevice = this.SDM.GetAllMCDevices<MCDevice>(mcdeviceWhere).FirstOrDefault();
            this.OnBeforeDelete(mcdevice);
            this.SDM.Delete(mcdevice);
            this.OnAfterDelete(mcdevice);
        }
    }
}
