using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("receita_ingrediente")]
    public class Receita_Ingrediente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("receitaId")]
        public virtual Receita Receita { get; set; }
        [ForeignKey("ingredienteId")]
        public virtual Ingrediente Ingrediente { get; set; }
    }
}
