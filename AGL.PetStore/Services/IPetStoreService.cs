using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGL.PetStore.Services
{
    public interface IPetStoreService
    {
        
        Task<List<Models.PetOwnersModel>> GetPetOwners();
    }
}