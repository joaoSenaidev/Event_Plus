using System.Data;
using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositoreis
{
    public class EventosRepository : IEventosRepository
    {
        private readonly EventPlus_Context _context;

        public EventosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid id, Eventos evento)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }
                _context.Eventos.Update(eventoBuscado!);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.Eventos.Select(e => new Eventos 
                {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    DataEvento = e.DataEvento,
                    TipoEventos = new TipoEventos
                    {
                        TituloTipoEvento = e.TipoEventos!.TituloTipoEvento                    
                    },
                    Instituicoes = new Instituicoes
                    {
                        NomeFantasia = e.Instituicoes!.NomeFantasia
                    }

                }).FirstOrDefault(e => e.IdEvento == id)!;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Eventos evento)
        {
            try
            {
                if (evento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual");
                }

                evento.IdEvento = Guid.NewGuid();

                _context.Eventos.Add(evento);

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
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                return _context.Eventos.Select(e => new Eventos
                {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    DataEvento = e.DataEvento,
                    IdTipoEvento = e.IdTipoEvento,
                    TipoEventos = new TipoEventos 
                    {
                        IdTipoEvento = e.IdTipoEvento,
                        TituloTipoEvento = e.TipoEventos!.TituloTipoEvento
                    },
                    IdInstituicao = e.IdInstituicao,
                    Instituicoes = new Instituicoes 
                    {
                        IdInstituicao = e.IdInstituicao,
                        NomeFantasia = e.Instituicoes!.NomeFantasia
                    }


                }).ToList();

               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                return _context.Eventos.Include(e => e.Presenca).Select(e => new Eventos
                {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    DataEvento = e.DataEvento,
                    IdTipoEvento = e.IdTipoEvento,
                    TipoEventos = new TipoEventos
                    {
                        IdTipoEvento = e.IdTipoEvento,
                        TituloTipoEvento = e.TipoEventos!.TituloTipoEvento
                    },
                    IdInstituicao = e.IdInstituicao,
                    Instituicoes = new Instituicoes
                    {
                        IdInstituicao = e.IdInstituicao,
                        NomeFantasia = e.Instituicoes!.NomeFantasia
                    },
                    Presenca = new Presenca
                    {
                        IdUsuario = e.Presenca!.IdUsuario,
                        Situacao = e.Presenca!.Situacao
                    }
                }).Where(e => e.Presenca!.Situacao == true && e.Presenca.IdUsuario == id).ToList();
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ProximosEventos()
        {
            try
            {
            return _context.Eventos.Select(e => new Eventos
            {
                IdEvento = e.IdEvento,
                NomeEvento = e.NomeEvento,
                Descricao = e.Descricao,
                DataEvento = e.DataEvento,
                IdTipoEvento = e.IdTipoEvento,
                TipoEventos = new TipoEventos
                {
                    IdTipoEvento = e.IdTipoEvento,
                    TituloTipoEvento = e.TipoEventos!.TituloTipoEvento
                },
                IdInstituicao = e.IdInstituicao,
                Instituicoes = new Instituicoes
                { 
                    IdInstituicao = e.IdInstituicao,
                    NomeFantasia = e.Instituicoes!.NomeFantasia
                }
            }).Where(e => e.DataEvento >= DateTime.Now).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
