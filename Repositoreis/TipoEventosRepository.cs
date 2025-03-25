using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositoreis
{
    public class TipoEventosRepository : ITipoEventosRepository
    {
        private readonly EventPlus_Context?  _context;

        public TipoEventosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid id, TipoEventos tipoEvento)
        {
            try
            {
                TipoEventos tipoEventosBuscado = _context.TipoEventos.Find(id)!;

                if (tipoEventosBuscado != null)
                {
                    tipoEventosBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.TipoEventos.Update(tipoEventosBuscado!);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoEventos.Find(id)!;

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEventos tipoEvento)
        {
            try
            {
                tipoEvento.IdTipoEvento = Guid.NewGuid();

                _context.TipoEventos.Add(tipoEvento);

                _context.SaveChanges();

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
                TipoEventos tipoEventosBuscado = _context.TipoEventos.Find(id)!;

                if (tipoEventosBuscado != null)
                {
                    _context.TipoEventos.Remove(tipoEventosBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEventos> Listar()
        {
            try
            {
                return _context.TipoEventos.OrderBy(tp => tp.TituloTipoEvento).ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
