using Event_Plus.Domains;
using Event_Plus.Interface;
using Event_Plus.Repositoreis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITipoUsuariosRepository _tipoUsuariosRepository;

        public TiposUsuariosController(ITipoUsuariosRepository tipoUsuariosRepository)
        {
            _tipoUsuariosRepository = tipoUsuariosRepository;
        }

        ////// <summary>
        /// Lista do Tipo de Usuario
        /// </summary>
        /// <returns>Listar os Tipos de Usuario</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuarios> tipoUsuarios = _tipoUsuariosRepository.Listar();

                return Ok(tipoUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarios novoTipoUsuario)
        {
            try
            {
                _tipoUsuariosRepository.Cadastrar(novoTipoUsuario);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuarios tipoUsuario)
        {
            try
            {
                _tipoUsuariosRepository.Atualizar(id, tipoUsuario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                TipoUsuarios tiposUsuarioBuscado = _tipoUsuariosRepository.BuscarPorId(id);

                return Ok(tiposUsuarioBuscado);

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
               _tipoUsuariosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
