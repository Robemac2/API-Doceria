using API_Doceria.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("ingrediente")]
    public class Ingrediente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("unidade", TypeName = "varchar(24)")]
        public Unidade Unidade { get; set; }
        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }
        [Column("data")]
        public DateOnly Data { get; set; }
    }
}
