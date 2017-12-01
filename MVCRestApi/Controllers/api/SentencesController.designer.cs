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
    public partial class SentencesController : ApiController
    {
        public SqlDataManager SDM { get; }

        partial void OnConstructor();
        partial void OnBeforeGet();
        partial void OnAfterGet(IEnumerable<Sentence> Sentences);
        partial void OnAfterGetById(Sentence Sentences, Guid sentenceId);
        partial void OnBeforePost(Sentence sentence);
        partial void OnAfterPost(Sentence sentence);
        partial void OnBeforePut(Sentence sentence);
        partial void OnAfterPut(Sentence sentence);
        partial void OnBeforeDelete(Sentence sentence);
        partial void OnAfterDelete(Sentence sentence);
        

        public SentencesController()
        {
            this.SDM = new SqlDataManager();
            this.OnConstructor();
        }
        // GET api/Sentence
        public IEnumerable<Sentence> Get()
        {
            this.OnBeforeGet();
            var results = this.SDM.GetAllSentences<Sentence>();
            Sentence.CheckExpand(this.SDM, results, HttpContext.Current.Request["expand"]);
            this.OnAfterGet(results);
            return results;
        }

        // GET api/Sentences/{sentence-guid}
        public Sentence Get(Guid sentenceId)
        {
            var SentencesWhere = String.Format("SentenceId = '{0}'", sentenceId);
            var result = this.SDM.GetAllSentences<Sentence>(SentencesWhere).FirstOrDefault();
            this.OnAfterGetById(result, sentenceId);
            return result;
        }

        // POST api/Sentences/{sentence-guid}
        public Sentence Post([FromBody]Sentence sentence)
        {
            if (sentence.SentenceId == Guid.Empty) sentence.SentenceId = Guid.NewGuid();
            this.OnBeforePost(sentence);
            this.SDM.Upsert(sentence);
            this.OnAfterPost(sentence);
            return sentence;
        }

        // POST api/Sentences/{sentence-guid}
        public Sentence Put([FromBody]Sentence sentence)
        {
            if (sentence.SentenceId == Guid.Empty) sentence.SentenceId = Guid.NewGuid();
            this.OnBeforePut(sentence);
            this.SDM.Upsert(sentence);
            this.OnAfterPut(sentence);
            return sentence;
        }

        // POST api/Sentences/{sentence-guid}
        public void Delete(Guid sentenceId)
        {
            var sentenceWhere = String.Format("SentenceId = '{0}'", sentenceId);
            var sentence = this.SDM.GetAllSentences<Sentence>(sentenceWhere).FirstOrDefault();
            this.OnBeforeDelete(sentence);
            this.SDM.Delete(sentence);
            this.OnAfterDelete(sentence);
        }
    }
}
