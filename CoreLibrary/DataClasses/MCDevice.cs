/*************************************************
Initially Generated by SSoT.me - 2017
    EJ Alexandra - An odxml42 Tool
    This file will not be overwritten by default!
*************************************************/
using System;
using System.ComponentModel;
                        
namespace MorseCodeHelper.Lib.DataClasses
{                   
    
    public partial class MCDevice 
    {
        public MCDevice()
        {
            this.InitPoco();
        }

        public override String ToString()
        {
            return String.Format("MCDevice: {0}", this.Name);
        }
    }
}