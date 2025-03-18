using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória!")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Refêrencia da Tabela TipoEventos
        /// </summary>
        public Guid IdTipoEvento { get; set; }

        [ForeignKey("IdTipoEvento")]
        public TipoEventos? TipoEventos { get; set; }

        /// <summary>
        /// Refêrencia da Tabela Instituicao
        /// </summary>
        public Guid IdInstituicao { get; set; }

        [ForeignKey("IdInstituicao")]
        public Instituicoes? Instituicoes { get; set; }

        public Presenca? Presenca { get; set; }

    }

}
