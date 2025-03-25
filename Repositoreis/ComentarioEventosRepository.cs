using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repositoreis
{
    public class ComentarioEventosRepository : IComentarioEventosRepositories
    {
        private readonly EventPlus_Context _context;

        public ComentarioEventosRepository(EventPlus_Context contexto)
        {
            _context = contexto;
        }

        public ComentarioEventos BuscarPorId(Guid idUsuario, Guid IdEvento)
        {
            try
            {
                return _context.ComentarioEventos.Select(c => new ComentarioEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Comentario = c.Comentario,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuarios
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Eventos 
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == IdEvento)!;
                       

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEventos comentarioEventos)
        {
            try
            {
                comentarioEventos.IdComentarioEvento = Guid.NewGuid();

                _context.ComentarioEventos.Add(comentarioEventos);

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
                ComentarioEventos comentarioEventosBuscado = _context.ComentarioEventos.Find(id)!;

                if (comentarioEventosBuscado != null)
                {
                    _context.ComentarioEventos.Remove(comentarioEventosBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEventos> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEventos.Select(c => new ComentarioEventos
                {
                    IdComentarioEvento = c.IdComentarioEvento,
                    Comentario = c.Comentario,
                    Exibe = c.Exibe,
                    IdUsuario = c.IdUsuario,
                    IdEvento = c.IdEvento,

                    Usuarios = new Usuarios
                    {
                        Nome = c.Usuarios!.Nome
                    },

                    Eventos = new Eventos
                    {
                        NomeEvento = c.Eventos!.NomeEvento,
                    }




                }).Where(c => c.IdEvento == id).ToList();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEventos> ListarSomenteExibe(Guid id) 
        {
            try
            {
                return _context.ComentarioEventos.Select(c => new ComentarioEventos
                {
                    IdComentarioEvento = c.IdComentarioEvento,
                    Comentario = c.Comentario,
                    Exibe = c.Exibe,
                    IdUsuario = c.IdUsuario,
                    IdEvento = c.IdEvento,

                    Usuarios = new Usuarios 
                    {
                        Nome = c.Usuarios!.Nome
                    },

                    Eventos = new Eventos
                    {
                        NomeEvento = c.Eventos!.NomeEvento,
                    }

                }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
