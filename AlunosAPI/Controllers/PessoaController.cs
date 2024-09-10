using AlunosAPI.Models;
using AlunosAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;


namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly PessoaRepository _pessoaRepository;

        public PessoaController(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        // GET: api/<PessoaController>
        [HttpGet]
        public async Task <IEnumerable<Pessoa>> Listar()
        {
            return await _pessoaRepository.ListarTodasPessoas();
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _pessoaRepository.BuscarPorId(id);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async void Post([FromBody] Pessoa dados)
        {
            await _pessoaRepository.Salvar(dados);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pessoa dados)
        {
            dados.Id = id;
            await _pessoaRepository.Atualizar(dados);
            return Ok();
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
  
                await _pessoaRepository.DeletarPorId(id);
                  return Ok();
            }
        }
}
