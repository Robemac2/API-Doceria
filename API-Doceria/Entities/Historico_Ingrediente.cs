using API_Doceria.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("historico_ingrediente")]
    public class Historico_Ingrediente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("ingredienteId")]
        public virtual Ingrediente Ingrediente { get; set; }

        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("unidade", TypeName = "varchar(24)")]
        public Unidade Unidade { get; set; }

        [Column("data")]
        public DateOnly Data { get; set; }
    }
}
