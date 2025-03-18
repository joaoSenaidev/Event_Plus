using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface ITipoUsuariosRepository
    {
        void Cadastrar(TipoUsuarios tipoUsuario);
        void Atualizar(Guid id, TipoUsuarios tipoUsuario);
        void Deletar(Guid id);
        List<TipoUsuarios> Listar();
        TipoUsuarios BuscarPorId(Guid id);
        
    }
}
