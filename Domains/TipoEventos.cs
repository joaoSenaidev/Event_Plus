using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("TipoEventos")]
    public class TipoEventos
    {
        [Key]
        public Guid IdTipoEvento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do tipo de evento é obrigatório!")]
        public string? TituloTipoEvento { get; set; }


    }
}
