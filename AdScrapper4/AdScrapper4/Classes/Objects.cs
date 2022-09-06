using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class SearchLocations
    {
        public string LocationName;
        public string GoogleLocationCode;
        public string BingLocationCode;

        public override string ToString()
        {
            return LocationName.ToString();
        }
    }
}
