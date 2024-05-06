using API_Doceria.Enum;
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

        [Column("receitaId")]
        public int ReceitaId { get; set; }

        [Column("ingredienteId")]
        public int IngredienteId { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("unidade", TypeName = "varchar(24)")]
        public Unidade Unidade { get; set; }

        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }
    }
}
