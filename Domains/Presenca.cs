using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("Presenca")]
    public class Presenca
    {
        [Key]
        public Guid IdPresenca { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é obrigatoria!")]
        public bool Situacao { get; set; }

        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuarios { get; set; }

        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Eventos? Eventos { get; set; }
    }
}
