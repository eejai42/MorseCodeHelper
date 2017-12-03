using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Sentence
    {
        private void InitPoco()
        {
            
            this.SentenceId = Guid.NewGuid();
            
                this.Words = new BindingList<Word>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SentenceId")]
        public Guid SentenceId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphId")]
        public Nullable<Guid> TelegraphId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Words")]
        public BindingList<Word> Words { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Words, and load them if requested
        /// </summary>
        public static void CheckExpandWords(SqlDataManager sdm, IEnumerable<Sentence> sentences, string expandString)
        {
            var sentencesWhere = CreateSentenceWhere(sentences);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("words", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childWords = sdm.GetAllWords<Word>(sentencesWhere);

                sentences.ToList()
                        .ForEach(feSentence => feSentence.LoadWords(childWords));
            }

        }


        

        
        /// <summary>
        /// Find the related Words (from the list provided) and attach them locally to the Words list.
        /// </summary>
        public void LoadWords(IEnumerable<Word> words)
        {
            words.Where(whereWord => whereWord.SentenceId == this.SentenceId)
                    .ToList()
                    .ForEach(feWord => this.Words.Add(feWord));
        }
        

        

        private static string CreateSentenceWhere(IEnumerable<Sentence> sentences)
        {
            if (!sentences.Any()) return "1=1";
            else 
            {
                var idList = sentences.Select(selectSentence => String.Format("'{0}'", selectSentence.SentenceId));
                var csIdList = String.Join(",", idList);
                return String.Format("SentenceId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Sentence> sentences, string expandString)
        {
            
            
            CheckExpandWords(sdm, sentences, expandString);
        }
        
    }
}