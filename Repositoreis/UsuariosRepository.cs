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
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TipoUsuarios
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }

                }).FirstOrDefault(u => u.Email == email && u.Senha == senha)!;

                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TipoUsuarios
                    {
                        IdTipoUsuario = u.TipoUsuario!.IdTipoUsuario,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }

                }).FirstOrDefault(u => u.IdTipoUsuario == id)!;

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

        public void Cadastrar(Usuarios usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();

                _context.Usuarios.Add(usuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
