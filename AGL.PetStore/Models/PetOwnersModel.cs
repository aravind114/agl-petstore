using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;


namespace AGL.PetStore.Models
{
    public class PetOwnersModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GenderEnum Gender { get; set; }       

        [JsonProperty("Pets")]
        public List<PetsModel> Pets { get; set; }
    }
}