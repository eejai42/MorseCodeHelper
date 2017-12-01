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
    public partial class TelegraphStationsController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<TelegraphStation> TelegraphStations);
        partial void OnAfterGetById(TelegraphStation TelegraphStations, Guid telegraphstationId);
        partial void OnBeforePost(TelegraphStation telegraphstation);
        partial void OnAfterPost(TelegraphStation telegraphstation);
        partial void OnBeforePut(TelegraphStation telegraphstation);
        partial void OnAfterPut(TelegraphStation telegraphstation);
        partial void OnBeforeDelete(TelegraphStation telegraphstation);
        partial void OnAfterDelete(TelegraphStation telegraphstation);
        

        public TelegraphStationsController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/TelegraphStation
        public IEnumerable<TelegraphStation> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllTelegraphStations<TelegraphStation>();
            TelegraphStation.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/TelegraphStations/{telegraphstation-guid}
        public TelegraphStation Get(Guid telegraphstationId)
        {
            var TelegraphStationsWhere = String.Format("TelegraphStationId = '{0}'", telegraphstationId);
            var result = this.SDM.GetAllTelegraphStations<TelegraphStation>(TelegraphStationsWhere).FirstOrDefault();
            this.OnAfterGetById(result, telegraphstationId);
            return result;
        }

        // POST api/TelegraphStations/{telegraphstation-guid}
        public TelegraphStation Post([FromBody]TelegraphStation telegraphstation)
        {
            if (telegraphstation.TelegraphStationId == Guid.Empty) telegraphstation.TelegraphStationId = Guid.NewGuid();
            this.OnBeforePost(telegraphstation);
            this.SDM.Upsert(telegraphstation);
            this.OnAfterPost(telegraphstation);
            return telegraphstation;
        }

        // POST api/TelegraphStations/{telegraphstation-guid}
        public TelegraphStation Put([FromBody]TelegraphStation telegraphstation)
        {
            if (telegraphstation.TelegraphStationId == Guid.Empty) telegraphstation.TelegraphStationId = Guid.NewGuid();
            this.OnBeforePut(telegraphstation);
            this.SDM.Upsert(telegraphstation);
            this.OnAfterPut(telegraphstation);
            return telegraphstation;
        }

        // POST api/TelegraphStations/{telegraphstation-guid}
        public void Delete(Guid telegraphstationId)
        {
            var telegraphstationWhere = String.Format("TelegraphStationId = '{0}'", telegraphstationId);
            var telegraphstation = this.SDM.GetAllTelegraphStations<TelegraphStation>(telegraphstationWhere).FirstOrDefault();
            this.OnBeforeDelete(telegraphstation);
            this.SDM.Delete(telegraphstation);
            this.OnAfterDelete(telegraphstation);
        }
    }
}
