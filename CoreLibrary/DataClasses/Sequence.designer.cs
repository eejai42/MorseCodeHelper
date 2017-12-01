using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class Sequence
    {
        private void InitPoco()
        {
            
            this.SequenceId = Guid.NewGuid();
            
                this.Signals = new BindingList<Signal>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SequenceId")]
        public Guid SequenceId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CharacterId")]
        public Nullable<Guid> CharacterId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Signals")]
        public BindingList<Signal> Signals { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Signals, and load them if requested
        /// </summary>
        public static void CheckExpandSignals(SqlDataManager sdm, IEnumerable<Sequence> sequences, string expandString)
        {
            var sequencesWhere = CreateSequenceWhere(sequences);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("signals", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childSignals = sdm.GetAllSignals<Signal>(sequencesWhere);

                sequences.ToList()
                        .ForEach(feSequence => feSequence.LoadSignals(childSignals));
            }

        }


        

        
        /// <summary>
        /// Find the related Signals (from the list provided) and attach them locally to the Signals list.
        /// </summary>
        public void LoadSignals(IEnumerable<Signal> signals)
        {
            signals.Where(whereSignal => whereSignal.SequenceId == this.SequenceId)
                    .ToList()
                    .ForEach(feSignal => this.Signals.Add(feSignal));
        }
        

        

        private static string CreateSequenceWhere(IEnumerable<Sequence> sequences)
        {
            if (!sequences.Any()) return "1=1";
            else 
            {
                var idList = sequences.Select(selectSequence => String.Format("'{0}'", selectSequence.SequenceId));
                var csIdList = String.Join(",", idList);
                return String.Format("SequenceId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<Sequence> sequences, string expandString)
        {
            
            
            CheckExpandSignals(sdm, sequences, expandString);
        }
        
    }
}