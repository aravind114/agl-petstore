using AGL.PetStore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGL.PetStore.Services
{
    public class PetStoreService : IPetStoreService
    {
        public async Task<List<PetOwnersModel>> GetPetOwners()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://agl-developer-test.azurewebsites.net/people.json"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PetOwnersModel>>(apiResponse);

                }
            }
            
        }
    }
}
