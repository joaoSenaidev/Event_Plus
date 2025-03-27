using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface IEventosRepository
    {
        void Cadastrar(Eventos evento);
        List<Eventos> ListarProximosEventos();
        List<Eventos> ListarPorId(Guid id);
        List<Eventos> Listar();
        Eventos BuscarPorId(Guid id);
        void Atualizar(Guid id, Eventos evento);
        void Deletar(Guid id);
    }
}
