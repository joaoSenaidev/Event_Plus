using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasController : ControllerBase
    {
        private readonly IPresencaRepository _presencaRepository;

        public PresencasController(IPresencaRepository presencasRepository)
        {
            _presencaRepository = presencasRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Presenca novaPresenca)
        {
            try
            {
                _presencaRepository.Inscrever(novaPresenca);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhas/{id}")]
        public IActionResult GetByMe(Guid id)
        {
            try
            {
                return Ok(_presencaRepository.ListarMinhasPresencas(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
