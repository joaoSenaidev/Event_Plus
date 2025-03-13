using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuarios
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é Obrigatória! ")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres e no máximo 60")]
        public string? Senha { get; set; }  

        /// <summary>
        /// Refêrencia da Tabela TituloTipoUsuario
        /// </summary>
        [Required(ErrorMessage = "O tipo do usuario é obrigatorio!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuarios? TipoUsuario { get; set; }

    }
}
