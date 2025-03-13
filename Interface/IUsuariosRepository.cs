using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios novousuario);
        Usuarios BuscarPorId(Guid id);
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
