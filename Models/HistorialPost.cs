using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace practicando.Models
{
    public class HistorialPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public int? PostId { get; set; }

        [Required]
        public string? Titulo { get; set; }

        public DateTime? FechaConsulta { get; set; }

        public int? UsuarioId { get; set; }
    }
}
