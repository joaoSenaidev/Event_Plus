using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuarioController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        ////// <summary>
        /// Lista do Tipo de Usuario
        /// </summary>
        /// <returns>Listar os Tipos de Usuario</returns>
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            try
            {
                _usuariosRepository.Cadastrar(novoUsuario);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
