using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositoreis
{
    public class ComentarioEventosRepository : IComentarioEventosRepositories
    {
        private readonly EventPlus_Context _context;

        public ComentarioEventosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }

        public ComentarioEventos BuscarPorId(Guid idUsuario, Guid IdEvento)
        {
            try
            {
                ComentarioEventos comentarioEventosBuscados = _context.ComentarioEventos.Find(idUsuario, IdEvento)!;

                return comentarioEventosBuscados;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEventos novoComentarioEventos)
        {
            try
            {
                _context.ComentarioEventos.Add(novoComentarioEventos);

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
                ComentarioEventos comentarioEventosBuscado = _context.ComentarioEventos.Find(id)!;

                if (comentarioEventosBuscado != null)
                {
                    _context.ComentarioEventos.Remove(comentarioEventosBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEventos> Listar(Guid id)
        {
            try
            {
                List<ComentarioEventos> listaComentarioEventos = _context.ComentarioEventos.Include(g => g.Comentario).ToList();

                return listaComentarioEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
