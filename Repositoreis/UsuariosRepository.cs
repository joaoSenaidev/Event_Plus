using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;

namespace Event_Plus.Repositoreis
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly EventPlus_Context _context;

        public UsuariosRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuarios novousuario)
        {
            try
            {
                _context.Usuarios.Add(novousuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
