using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;

namespace Event_Plus.Repositoreis
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly EventPlus_Context? _context;

        public PresencaRepository(EventPlus_Context context)
        {
            _context = context;  
        }


        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.Presenca.Find(id)!;

                if (presencaBuscado != null)
                {
                    if (presencaBuscado.Situacao)
                    {
                        presencaBuscado.Situacao = false;

                    }
                    else 
                    {
                        presencaBuscado.Situacao = true;
                    }
                }
                _context.Presenca.Update(presencaBuscado!);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.Presenca.Select(p => new Presenca
                {
                    IdPresenca = p.IdPresenca,
                    Situacao = p.Situacao,

                    Eventos = new Eventos
                    {
                        IdEvento = p.IdEvento!,
                        DataEvento = p.Eventos!.DataEvento,
                        NomeEvento = p.Eventos.NomeEvento,
                        Descricao = p.Eventos.Descricao,

                        Instituicoes = new Instituicoes
                        {
                            IdInstituicao = p.Eventos.Instituicoes!.IdInstituicao,
                            NomeFantasia = p.Eventos.Instituicoes!.NomeFantasia
                        }

                    }


                }).FirstOrDefault(p => p.IdPresenca == id)!;
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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;

                if (presencaBuscada != null)
                {
                    _context.Presenca.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            try
            {
                inscricao.IdPresenca = Guid.NewGuid();

                _context.Presenca.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presenca.Select(p => new Presenca
                {
                    IdPresenca = p.IdPresenca,
                    Situacao = p.Situacao,

                    Eventos = new Eventos
                    {
                        IdEvento = p.IdEvento,
                        DataEvento = p.Eventos!.DataEvento,
                        NomeEvento = p.Eventos.NomeEvento,
                        Descricao = p.Eventos.Descricao,

                        Instituicoes = new Instituicoes
                        {
                            IdInstituicao = p.Eventos.Instituicoes!.IdInstituicao,
                            NomeFantasia = p.Eventos.Instituicoes!.NomeFantasia
                        }

                    }


                }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            try
            {
                return _context.Presenca.Select(p => new Presenca
                {
                    IdPresenca = p.IdPresenca,
                    Situacao = p.Situacao,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,

                    Eventos = new Eventos
                    {
                        IdEvento = p.IdEvento,
                        DataEvento = p.Eventos!.DataEvento,
                        NomeEvento = p.Eventos!.NomeEvento,
                        Descricao = p.Eventos!.Descricao,

                        Instituicoes = new Instituicoes
                        {
                            IdInstituicao = p.Eventos.IdInstituicao,
                        }
                    }

                    }).Where(p => p.IdUsuario == id).ToList();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
