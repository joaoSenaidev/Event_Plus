using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventosRepository _eventoRepository;
        public EventoController(IEventosRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Eventos> eventos = _eventoRepository.Listar();

                return Ok(eventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        [HttpPost]
        public IActionResult Post(Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("ListarPorId/{id}")]
        public IActionResult ListarPorId(Guid id)
        {
            try
            {
                List<Eventos> listaEventos = _eventoRepository.ListarPorId(id);
                return Ok(listaEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.ListarProximosEventos(id);

                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }



    }
    }
