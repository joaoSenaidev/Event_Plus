using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface IPresencaRepository
    {
        void Deletar(Guid id);
        void Inscrever(Presenca inscricao);
        void Atualizar(Guid id, Presenca presenca);
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid id);
        List<Presenca> ListarMinhasPresencas(Guid id);


    }
}
