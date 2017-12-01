using MorseCodeHelper.Lib.DataClasses;
using MorseCodeHelper.Lib.SqlDataManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class MorseCodeMetaSnapshot
    {
        public List<Signal> Signals { get; private set; }
        public List<Alphabet> Alphabets { get; private set; }

        public static void SaveNow()
        {
            var sdm = new SqlDataManager();
            var mcms = new MorseCodeMetaSnapshot();

            var allCharacters = sdm.GetAllCharacters<Character>();


            var allSignals = sdm.GetAllSignals<Signal>();

            mcms.Alphabets = sdm.GetAllAlphabets<Alphabet>();
            foreach (var alphabet in mcms.Alphabets)
            {
                alphabet.LoadCharacters(allCharacters);
                alphabet.ParseCharacters(sdm, allSignals);
            }

            mcms.Signals = sdm.GetAllSignals<Signal>();

            mcms.Save("../../../SSoT/MorseCodeMetaSnapshot.json");
        }

        private void Save(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
