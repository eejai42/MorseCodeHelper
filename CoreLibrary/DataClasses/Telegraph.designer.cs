using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Telegraph
    {
        private void InitPoco()
        {
            
            this.TelegraphId = Guid.NewGuid();
            
                this.Controllers = new BindingList<Controller>();
            
                this.Listeners = new BindingList<Listener>();
            
                this.Observers = new BindingList<Observer>();
            
                this.Transmissions = new BindingList<Transmission>();
            
                this.Sentences = new BindingList<Sentence>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphId")]
        public Guid TelegraphId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "InputMessage")]
        public String InputMessage { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Nullable<Guid> TelegraphStationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CustomerId")]
        public Nullable<Guid> CustomerId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphOperatorId")]
        public Nullable<Guid> TelegraphOperatorId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Controllers")]
        public BindingList<Controller> Controllers { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Controllers, and load them if requested
        /// </summary>
        public static void CheckExpandControllers(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            var telegraphsWhere = CreateTelegraphWhere(telegraphs);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("controllers", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childControllers = sdm.GetAllControllers<Controller>(telegraphsWhere);

                telegraphs.ToList()
                        .ForEach(feTelegraph => feTelegraph.LoadControllers(childControllers));
            }

        }


        

        
        /// <summary>
        /// Find the related Controllers (from the list provided) and attach them locally to the Controllers list.
        /// </summary>
        public void LoadControllers(IEnumerable<Controller> controllers)
        {
            controllers.Where(whereController => whereController.TelegraphId == this.TelegraphId)
                    .ToList()
                    .ForEach(feController => this.Controllers.Add(feController));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Listeners")]
        public BindingList<Listener> Listeners { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Listeners, and load them if requested
        /// </summary>
        public static void CheckExpandListeners(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            var telegraphsWhere = CreateTelegraphWhere(telegraphs);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("listeners", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childListeners = sdm.GetAllListeners<Listener>(telegraphsWhere);

                telegraphs.ToList()
                        .ForEach(feTelegraph => feTelegraph.LoadListeners(childListeners));
            }

        }


        

        
        /// <summary>
        /// Find the related Listeners (from the list provided) and attach them locally to the Listeners list.
        /// </summary>
        public void LoadListeners(IEnumerable<Listener> listeners)
        {
            listeners.Where(whereListener => whereListener.TelegraphId == this.TelegraphId)
                    .ToList()
                    .ForEach(feListener => this.Listeners.Add(feListener));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Observers")]
        public BindingList<Observer> Observers { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Observers, and load them if requested
        /// </summary>
        public static void CheckExpandObservers(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            var telegraphsWhere = CreateTelegraphWhere(telegraphs);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("observers", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childObservers = sdm.GetAllObservers<Observer>(telegraphsWhere);

                telegraphs.ToList()
                        .ForEach(feTelegraph => feTelegraph.LoadObservers(childObservers));
            }

        }


        

        
        /// <summary>
        /// Find the related Observers (from the list provided) and attach them locally to the Observers list.
        /// </summary>
        public void LoadObservers(IEnumerable<Observer> observers)
        {
            observers.Where(whereObserver => whereObserver.TelegraphId == this.TelegraphId)
                    .ToList()
                    .ForEach(feObserver => this.Observers.Add(feObserver));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Transmissions")]
        public BindingList<Transmission> Transmissions { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Transmissions, and load them if requested
        /// </summary>
        public static void CheckExpandTransmissions(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            var telegraphsWhere = CreateTelegraphWhere(telegraphs);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("transmissions", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childTransmissions = sdm.GetAllTransmissions<Transmission>(telegraphsWhere);

                telegraphs.ToList()
                        .ForEach(feTelegraph => feTelegraph.LoadTransmissions(childTransmissions));
            }

        }


        

        
        /// <summary>
        /// Find the related Transmissions (from the list provided) and attach them locally to the Transmissions list.
        /// </summary>
        public void LoadTransmissions(IEnumerable<Transmission> transmissions)
        {
            transmissions.Where(whereTransmission => whereTransmission.TelegraphId == this.TelegraphId)
                    .ToList()
                    .ForEach(feTransmission => this.Transmissions.Add(feTransmission));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Sentences")]
        public BindingList<Sentence> Sentences { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Sentences, and load them if requested
        /// </summary>
        public static void CheckExpandSentences(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            var telegraphsWhere = CreateTelegraphWhere(telegraphs);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("sentences", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSentences = sdm.GetAllSentences<Sentence>(telegraphsWhere);

                telegraphs.ToList()
                        .ForEach(feTelegraph => feTelegraph.LoadSentences(childSentences));
            }

        }


        

        
        /// <summary>
        /// Find the related Sentences (from the list provided) and attach them locally to the Sentences list.
        /// </summary>
        public void LoadSentences(IEnumerable<Sentence> sentences)
        {
            sentences.Where(whereSentence => whereSentence.TelegraphId == this.TelegraphId)
                    .ToList()
                    .ForEach(feSentence => this.Sentences.Add(feSentence));
        }
        

        

        private static string CreateTelegraphWhere(IEnumerable<Telegraph> telegraphs)
        {
            if (!telegraphs.Any()) return "1=1";
            else 
            {
                var idList = telegraphs.Select(selectTelegraph => String.Format("'{0}'", selectTelegraph.TelegraphId));
                var csIdList = String.Join(",", idList);
                return String.Format("TelegraphId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Telegraph> telegraphs, string expandString)
        {
            
            
            CheckExpandControllers(sdm, telegraphs, expandString);
            
            CheckExpandListeners(sdm, telegraphs, expandString);
            
            CheckExpandObservers(sdm, telegraphs, expandString);
            
            CheckExpandTransmissions(sdm, telegraphs, expandString);
            
            CheckExpandSentences(sdm, telegraphs, expandString);
        }
        
    }
}