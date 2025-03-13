using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("TipoUsuarios")]
    public class TipoUsuarios
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do tipo de usuário é obrigatório!")]
        public string? TituloTipoUsuario { get; set; }

    }
}
