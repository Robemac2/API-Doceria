using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("receita")]
    public class Receita
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("lista-ingredientes")]
        public List<Receita_Ingrediente> Ingredientes { get; set; }

        [Column("tempoDePreparo")]
        public TimeOnly TempoDePreparo { get; set; }

        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }

        [Column("rendimento")]
        public int Rendimento { get; set; }

        [Column("precoUnitario", TypeName = "money")]
        public decimal PrecoUnitario { get; set; }
    }
}
