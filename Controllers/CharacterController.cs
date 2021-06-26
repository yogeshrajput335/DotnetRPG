using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using DotnetRPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        // private static List<Character> characters = new List<Character>(){
        //     new Character(),
        //     new Character(){Id=1 , Name="Yogesh"}
        // };
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto c){
            return Ok(await _characterService.AddCharacter(c));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto c){
            var response = await _characterService.UpdateCharacter(c);
            if(response.Data ==null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data ==null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}