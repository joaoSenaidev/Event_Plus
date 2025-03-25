using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;

namespace Event_Plus.Repositoreis
{
    public class TipoUsuariosRepository : ITipoUsuariosRepository
    {
        private readonly EventPlus_Context? _context;
        public TipoUsuariosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Guid id, TipoUsuarios tipoUsuario)
        {
            try
            {
                TipoUsuarios tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }
                _context.TipoUsuario.Update(tipoUsuarioBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuarios BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoUsuario.Find(id)!;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuarios tipoUsuario)
        {
            try
            {
                tipoUsuario.IdTipoUsuario = Guid.NewGuid();

                _context.TipoUsuario.Add(tipoUsuario);

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
                TipoUsuarios tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
                }
                    _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuarios> Listar()
        {
            try
            {
                return _context.TipoUsuario.ToList();
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
