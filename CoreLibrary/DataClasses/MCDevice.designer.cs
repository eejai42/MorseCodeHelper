using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MorseCodeHelper.Lib.SqlDataManagement;
using CoreLibrary.Extensions;

namespace MorseCodeHelper.Lib.DataClasses
{                            
    public partial class MCDevice
    {
        private void InitPoco()
        {
            
            this.MCDeviceId = Guid.NewGuid();
            
                this.Lights = new BindingList<Light>();
            
                this.Repeaters = new BindingList<Repeater>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EquipmentId")]
        public Guid MCDeviceId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TelegraphStationId")]
        public Nullable<Guid> TelegraphStationId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Lights")]
        public BindingList<Light> Lights { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Lights, and load them if requested
        /// </summary>
        public static void CheckExpandLights(SqlDataManager sdm, IEnumerable<MCDevice> mCDevices, string expandString)
        {
            var mCDevicesWhere = CreateMCDeviceWhere(mCDevices);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("lights", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childLights = sdm.GetAllLights<Light>(mCDevicesWhere);

                mCDevices.ToList()
                        .ForEach(feMCDevice => feMCDevice.LoadLights(childLights));
            }

        }


        

        
        /// <summary>
        /// Find the related Lights (from the list provided) and attach them locally to the Lights list.
        /// </summary>
        public void LoadLights(IEnumerable<Light> lights)
        {
            lights.Where(whereLight => whereLight.MCDeviceId == this.MCDeviceId)
                    .ToList()
                    .ForEach(feLight => this.Lights.Add(feLight));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Repeaters")]
        public BindingList<Repeater> Repeaters { get; set; }
            
        /// <summary>
        /// Check to see if there are any related Repeaters, and load them if requested
        /// </summary>
        public static void CheckExpandRepeaters(SqlDataManager sdm, IEnumerable<MCDevice> mCDevices, string expandString)
        {
            var mCDevicesWhere = CreateMCDeviceWhere(mCDevices);
            expandString = expandString.SafeToString();

            if (String.Equals(expandString, "all", StringComparison.OrdinalIgnoreCase) || expandString.IndexOf("repeaters", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var childRepeaters = sdm.GetAllRepeaters<Repeater>(mCDevicesWhere);

                mCDevices.ToList()
                        .ForEach(feMCDevice => feMCDevice.LoadRepeaters(childRepeaters));
            }

        }


        

        
        /// <summary>
        /// Find the related Repeaters (from the list provided) and attach them locally to the Repeaters list.
        /// </summary>
        public void LoadRepeaters(IEnumerable<Repeater> repeaters)
        {
            repeaters.Where(whereRepeater => whereRepeater.MCDeviceId == this.MCDeviceId)
                    .ToList()
                    .ForEach(feRepeater => this.Repeaters.Add(feRepeater));
        }
        

        

        private static string CreateMCDeviceWhere(IEnumerable<MCDevice> mCDevices)
        {
            if (!mCDevices.Any()) return "1=1";
            else 
            {
                var idList = mCDevices.Select(selectMCDevice => String.Format("'{0}'", selectMCDevice.MCDeviceId));
                var csIdList = String.Join(",", idList);
                return String.Format("MCDeviceId in ({0})", csIdList);
            }
        }
        
        public static void CheckExpand(SqlDataManager sdm, IEnumerable<MCDevice> mCDevices, string expandString)
        {
            
            
            CheckExpandLights(sdm, mCDevices, expandString);
            
            CheckExpandRepeaters(sdm, mCDevices, expandString);
        }
        
    }
}