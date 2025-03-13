using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("ComentarioEventos")]
    public class ComentarioEventos
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O comentário é obrigatório!")]
        public string? Comentario { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "O Exibir obrigatório!")]
        public bool Exibe { get; set; }


        /// <summary>
        /// Refêrencia da Tabela Usuario
        /// </summary>
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuarios { get; set; }

        /// <summary>
        /// Refêrencia da Tabela Evento
        /// </summary>
        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Eventos? Eventos { get; set; }


    }
}
