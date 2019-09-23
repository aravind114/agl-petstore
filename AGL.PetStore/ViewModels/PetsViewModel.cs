using AGL.PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.PetStore.ViewModels
{
    public class PetsViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string OwnersName { get; set; }
        public GenderEnum OwnersGender { get; set; }
    }
}
