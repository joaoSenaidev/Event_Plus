using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Domains
{
    [Table("Instituicoes")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicoes
    {
        [Key]
        public Guid IdInstituicao { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O Nome da instituição é obrigatoria!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Endereço é obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório!")]
        public string? CNPJ { get; set; }


    }
}
