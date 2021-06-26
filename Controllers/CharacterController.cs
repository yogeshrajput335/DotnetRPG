using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<List<Character>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character c){
            return Ok(await _characterService.AddCharacter(c));
        }
    }
}