using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Communication
    {
        private void InitPoco()
        {
            
            this.CommunicationId = Guid.NewGuid();
            
                this.Controllers = new BindingList<Controller>();
            
                this.Listeners = new BindingList<Listener>();
            
                this.Observers = new BindingList<Observer>();
            
                this.TelegraphOperators = new BindingList<TelegraphOperator>();
            
                this.Telegraphs = new BindingList<Telegraph>();
            
                this.Understandings = new BindingList<Understanding>();
            
                this.Words = new BindingList<Word>();
            
                this.Sentences = new BindingList<Sentence>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CommunicationId")]
        public Guid CommunicationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphOperatorId")]
        public Nullable<Guid> TelegraphOperatorId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AlphabetId")]
        public Nullable<Guid> AlphabetId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Controllers")]
        public BindingList<Controller> Controllers { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Controllers, and load them if requested
        /// </summary>
        public static void CheckExpandControllers(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("controllers", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childControllers = sdm.GetAllControllers<Controller>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadControllers(childControllers));
            }

        }


        

        
        /// <summary>
        /// Find the related Controllers (from the list provided) and attach them locally to the Controllers list.
        /// </summary>
        public void LoadControllers(IEnumerable<Controller> controllers)
        {
            controllers.Where(whereController => whereController.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feController => this.Controllers.Add(feController));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Listeners")]
        public BindingList<Listener> Listeners { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Listeners, and load them if requested
        /// </summary>
        public static void CheckExpandListeners(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("listeners", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childListeners = sdm.GetAllListeners<Listener>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadListeners(childListeners));
            }

        }


        

        
        /// <summary>
        /// Find the related Listeners (from the list provided) and attach them locally to the Listeners list.
        /// </summary>
        public void LoadListeners(IEnumerable<Listener> listeners)
        {
            listeners.Where(whereListener => whereListener.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feListener => this.Listeners.Add(feListener));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Observers")]
        public BindingList<Observer> Observers { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Observers, and load them if requested
        /// </summary>
        public static void CheckExpandObservers(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("observers", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childObservers = sdm.GetAllObservers<Observer>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadObservers(childObservers));
            }

        }


        

        
        /// <summary>
        /// Find the related Observers (from the list provided) and attach them locally to the Observers list.
        /// </summary>
        public void LoadObservers(IEnumerable<Observer> observers)
        {
            observers.Where(whereObserver => whereObserver.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feObserver => this.Observers.Add(feObserver));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphOperators")]
        public BindingList<TelegraphOperator> TelegraphOperators { get; set; }
            
        /// <summary>
        /// Check to see if there are any related TelegraphOperators, and load them if requested
        /// </summary>
        public static void CheckExpandTelegraphOperators(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("telegraphOperators", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTelegraphOperators = sdm.GetAllTelegraphOperators<TelegraphOperator>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadTelegraphOperators(childTelegraphOperators));
            }

        }


        

        
        /// <summary>
        /// Find the related TelegraphOperators (from the list provided) and attach them locally to the TelegraphOperators list.
        /// </summary>
        public void LoadTelegraphOperators(IEnumerable<TelegraphOperator> telegraphOperators)
        {
            telegraphOperators.Where(whereTelegraphOperator => whereTelegraphOperator.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feTelegraphOperator => this.TelegraphOperators.Add(feTelegraphOperator));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Telegraphs")]
        public BindingList<Telegraph> Telegraphs { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Telegraphs, and load them if requested
        /// </summary>
        public static void CheckExpandTelegraphs(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("telegraphs", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTelegraphs = sdm.GetAllTelegraphs<Telegraph>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadTelegraphs(childTelegraphs));
            }

        }


        

        
        /// <summary>
        /// Find the related Telegraphs (from the list provided) and attach them locally to the Telegraphs list.
        /// </summary>
        public void LoadTelegraphs(IEnumerable<Telegraph> telegraphs)
        {
            telegraphs.Where(whereTelegraph => whereTelegraph.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feTelegraph => this.Telegraphs.Add(feTelegraph));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Understandings")]
        public BindingList<Understanding> Understandings { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Understandings, and load them if requested
        /// </summary>
        public static void CheckExpandUnderstandings(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("understandings", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childUnderstandings = sdm.GetAllUnderstandings<Understanding>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadUnderstandings(childUnderstandings));
            }

        }


        

        
        /// <summary>
        /// Find the related Understandings (from the list provided) and attach them locally to the Understandings list.
        /// </summary>
        public void LoadUnderstandings(IEnumerable<Understanding> understandings)
        {
            understandings.Where(whereUnderstanding => whereUnderstanding.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feUnderstanding => this.Understandings.Add(feUnderstanding));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Words")]
        public BindingList<Word> Words { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Words, and load them if requested
        /// </summary>
        public static void CheckExpandWords(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("words", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childWords = sdm.GetAllWords<Word>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadWords(childWords));
            }

        }


        

        
        /// <summary>
        /// Find the related Words (from the list provided) and attach them locally to the Words list.
        /// </summary>
        public void LoadWords(IEnumerable<Word> words)
        {
            words.Where(whereWord => whereWord.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feWord => this.Words.Add(feWord));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Sentences")]
        public BindingList<Sentence> Sentences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Sentences, and load them if requested
        /// </summary>
        public static void CheckExpandSentences(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            var communicationsWhere = CreateCommunicationWhere(communications);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("sentences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSentences = sdm.GetAllSentences<Sentence>(communicationsWhere);

                communications.ToList()
                        .ForEach(feCommunication => feCommunication.LoadSentences(childSentences));
            }

        }


        

        
        /// <summary>
        /// Find the related Sentences (from the list provided) and attach them locally to the Sentences list.
        /// </summary>
        public void LoadSentences(IEnumerable<Sentence> sentences)
        {
            sentences.Where(whereSentence => whereSentence.CommunicationId == this.CommunicationId)
                    .ToList()
                    .ForEach(feSentence => this.Sentences.Add(feSentence));
        }
        

        

        private static string CreateCommunicationWhere(IEnumerable<Communication> communications)
        {
            if (!communications.Any()) return "1=1";
            else 
            {
                var idList = communications.Select(selectCommunication => String.Format("'{0}'", selectCommunication.CommunicationId));
                var csIdList = String.Join(",", idList);
                return String.Format("CommunicationId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Communication> communications, string expandString)
        {
            
            
            CheckExpandControllers(sdm, communications, expandString);
            
            CheckExpandListeners(sdm, communications, expandString);
            
            CheckExpandObservers(sdm, communications, expandString);
            
            CheckExpandTelegraphOperators(sdm, communications, expandString);
            
            CheckExpandTelegraphs(sdm, communications, expandString);
            
            CheckExpandUnderstandings(sdm, communications, expandString);
            
            CheckExpandWords(sdm, communications, expandString);
            
            CheckExpandSentences(sdm, communications, expandString);
        }
        
    }
}