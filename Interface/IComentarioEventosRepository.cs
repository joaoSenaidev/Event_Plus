using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface IComentarioEventosRepositories
    {
        void Cadastrar(ComentarioEventos comentarioEventos);
        void Deletar(Guid id);
        List<ComentarioEventos> Listar(Guid id);
        ComentarioEventos BuscarPorId(Guid idUsuario, Guid IdEvento);

    }
}
