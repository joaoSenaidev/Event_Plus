using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface ITipoEventosRepository
    {
       void Cadastrar(TipoEventos tipoEvento);
       void Atualizar(Guid id, TipoEventos tipoEvento);
       void Deletar(Guid id);
       List<TipoEventos> Listar();
       TipoEventos BuscarPorId(Guid id);

    }
}
