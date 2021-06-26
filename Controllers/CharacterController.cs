using System.Collections.Generic;
using System.Linq;
using DotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character(){Id=1 , Name="Yogesh"}
        };
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c=>c.Id == id));
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character c){
            characters.Add(c);
            return Ok(characters);
        }
    }
}