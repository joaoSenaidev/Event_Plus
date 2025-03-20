using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;

namespace Event_Plus.Repositoreis
{
    public class EventosRepository : IEventosRepository
    {
        private readonly EventPlus_Context _context;

        public EventosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid id, Eventos evento)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Eventos novoEvento)
        {
            try
            {
                _context.Eventos.Add(novoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                List<Eventos> listaEventos = _context.Eventos.ToList();

                return listaEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                List<Eventos> listaEventosPorId = _context.Eventos.ToList();

                return listaEventosPorId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ProximosEventos()
        {
            throw new NotImplementedException();
        }
    }
}
