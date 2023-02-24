﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrSmartRewriteV2
{
    internal struct ConfigJSON
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        public string Prefix { get; private set; }
    }
}
