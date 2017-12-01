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
    public partial class CharacterSquencesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<CharacterSquence> CharacterSquences);
        partial void OnAfterGetById(CharacterSquence CharacterSquences, Guid charactersquenceId);
        partial void OnBeforePost(CharacterSquence charactersquence);
        partial void OnAfterPost(CharacterSquence charactersquence);
        partial void OnBeforePut(CharacterSquence charactersquence);
        partial void OnAfterPut(CharacterSquence charactersquence);
        partial void OnBeforeDelete(CharacterSquence charactersquence);
        partial void OnAfterDelete(CharacterSquence charactersquence);
        

        public CharacterSquencesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/CharacterSquence
        public IEnumerable<CharacterSquence> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllCharacterSquences<CharacterSquence>();
            CharacterSquence.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/CharacterSquences/{charactersquence-guid}
        public CharacterSquence Get(Guid charactersquenceId)
        {
            var CharacterSquencesWhere = String.Format("CharacterSquenceId = '{0}'", charactersquenceId);
            var result = this.SDM.GetAllCharacterSquences<CharacterSquence>(CharacterSquencesWhere).FirstOrDefault();
            this.OnAfterGetById(result, charactersquenceId);
            return result;
        }

        // POST api/CharacterSquences/{charactersquence-guid}
        public CharacterSquence Post([FromBody]CharacterSquence charactersquence)
        {
            if (charactersquence.CharacterSquenceId == Guid.Empty) charactersquence.CharacterSquenceId = Guid.NewGuid();
            this.OnBeforePost(charactersquence);
            this.SDM.Upsert(charactersquence);
            this.OnAfterPost(charactersquence);
            return charactersquence;
        }

        // POST api/CharacterSquences/{charactersquence-guid}
        public CharacterSquence Put([FromBody]CharacterSquence charactersquence)
        {
            if (charactersquence.CharacterSquenceId == Guid.Empty) charactersquence.CharacterSquenceId = Guid.NewGuid();
            this.OnBeforePut(charactersquence);
            this.SDM.Upsert(charactersquence);
            this.OnAfterPut(charactersquence);
            return charactersquence;
        }

        // POST api/CharacterSquences/{charactersquence-guid}
        public void Delete(Guid charactersquenceId)
        {
            var charactersquenceWhere = String.Format("CharacterSquenceId = '{0}'", charactersquenceId);
            var charactersquence = this.SDM.GetAllCharacterSquences<CharacterSquence>(charactersquenceWhere).FirstOrDefault();
            this.OnBeforeDelete(charactersquence);
            this.SDM.Delete(charactersquence);
            this.OnAfterDelete(charactersquence);
        }
    }
}
