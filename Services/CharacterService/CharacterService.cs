using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character(){Id=1 , Name="Yogesh"}
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto c)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(c);
            character.Id = characters.Max(c=>c.Id)+1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c=>c.Id == id));
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto c){
            
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{
            Character character = characters.FirstOrDefault(d=>d.Id==c.Id);
            character.Name = c.Name;
            character.HitPoints = c.HitPoints;
            character.Strength = c.Strength;
            character.Defence = c.Defence;
            character.Intelligence = c.Intelligence;
            character.Class = c.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            } catch (Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message= "Error in udpate method";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id){
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
            Character character = characters.First(d=>d.Id==id);
            characters.Remove(character);

            serviceResponse.Data = characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            } catch (Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message= "Error in delete method";
            }
            return serviceResponse;
        }
         
    }
}