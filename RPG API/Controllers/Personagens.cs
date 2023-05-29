using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG_API.Models;

namespace RPG_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class Personagens : ControllerBase
    {
        private static List<Personagem> listaP = new List<Personagem>
        {
            new Personagem
            {
                Id = 1,
                Nome = "Linkin",
                Sobrenome = "Park",
                Fantasia = "Banda rock",
                Local = "USA"

            },


            new Personagem
            {
                Id = 2,
                Nome = "Zelda",
                Sobrenome = "Park",
                Fantasia = "Babymetal",
                Local = "USA"

            }



        };

        [HttpGet]
        public async Task<ActionResult<List<Personagem>>> TodosPersonagens()
        {
            return Ok(listaP);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Personagem>>> UnicoPersonagem(int id) //Pesquisa
        {
            var unico = listaP.Find(x => x.Id == id);

            if (unico is null)
                return NotFound("Não foi encontrado");

            return Ok(unico);
            
        }

        [HttpPost]
        public async Task<ActionResult<List<Personagem>>> AddPersonagem(Personagem novo) //AddPersonagem
        {
            listaP.Add(novo);
            return Ok(listaP);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<List<Personagem>>> EditaPersonagem(int id,Personagem editado)
        {
            var pesquisa = listaP.Find(x => x.Id == id);

            if(pesquisa is null)
                return NotFound("Personagem nao existe");

            pesquisa.Nome = editado.Nome != "" && editado.Nome != "string" ? editado.Nome : pesquisa.Nome; //Expressao Ternaria 
            pesquisa.Sobrenome = editado.Sobrenome != "" && editado.Sobrenome != "string" ? editado.Sobrenome : pesquisa.Sobrenome; //Expressao Ternaria 
            pesquisa.Fantasia = editado.Fantasia != "" && editado.Fantasia != "string" ? editado.Fantasia : pesquisa.Fantasia; //Expressao Ternaria 
            pesquisa.Local = editado.Local != "" && editado.Local != "string" ? editado.Local : pesquisa.Local; //Expressao Ternaria 

               return Ok(pesquisa);
            

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Personagem>>> DeletaPersonagem(int id)
        {
            var pesquisa = listaP.Find(x => x.Id==id);

            if (pesquisa is null)
                return NotFound("Personagem nao existe");

            listaP.Remove(pesquisa);
            return Ok(pesquisa);   


        }

    }
}
