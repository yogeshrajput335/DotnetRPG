using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto c);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto c);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}