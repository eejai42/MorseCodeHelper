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
    public partial class MorseCodesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<MorseCode> MorseCodes);
        partial void OnAfterGetById(MorseCode MorseCodes, Guid morsecodeId);
        partial void OnBeforePost(MorseCode morsecode);
        partial void OnAfterPost(MorseCode morsecode);
        partial void OnBeforePut(MorseCode morsecode);
        partial void OnAfterPut(MorseCode morsecode);
        partial void OnBeforeDelete(MorseCode morsecode);
        partial void OnAfterDelete(MorseCode morsecode);
        

        public MorseCodesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/MorseCode
        public IEnumerable<MorseCode> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllMorseCodes<MorseCode>();
            MorseCode.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/MorseCodes/{morsecode-guid}
        public MorseCode Get(Guid morsecodeId)
        {
            var MorseCodesWhere = String.Format("MorseCodeId = '{0}'", morsecodeId);
            var result = this.SDM.GetAllMorseCodes<MorseCode>(MorseCodesWhere).FirstOrDefault();
            this.OnAfterGetById(result, morsecodeId);
            return result;
        }

        // POST api/MorseCodes/{morsecode-guid}
        public MorseCode Post([FromBody]MorseCode morsecode)
        {
            if (morsecode.MorseCodeId == Guid.Empty) morsecode.MorseCodeId = Guid.NewGuid();
            this.OnBeforePost(morsecode);
            this.SDM.Upsert(morsecode);
            this.OnAfterPost(morsecode);
            return morsecode;
        }

        // POST api/MorseCodes/{morsecode-guid}
        public MorseCode Put([FromBody]MorseCode morsecode)
        {
            if (morsecode.MorseCodeId == Guid.Empty) morsecode.MorseCodeId = Guid.NewGuid();
            this.OnBeforePut(morsecode);
            this.SDM.Upsert(morsecode);
            this.OnAfterPut(morsecode);
            return morsecode;
        }

        // POST api/MorseCodes/{morsecode-guid}
        public void Delete(Guid morsecodeId)
        {
            var morsecodeWhere = String.Format("MorseCodeId = '{0}'", morsecodeId);
            var morsecode = this.SDM.GetAllMorseCodes<MorseCode>(morsecodeWhere).FirstOrDefault();
            this.OnBeforeDelete(morsecode);
            this.SDM.Delete(morsecode);
            this.OnAfterDelete(morsecode);
        }
    }
}
