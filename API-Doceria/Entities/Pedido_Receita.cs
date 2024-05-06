using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("pedido_receita")]
    public class Pedido_Receita
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("pedidoId")]
        public int PedidoId { get; set; }

        [Column("receitaId")]
        public int ReceitaId { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("total", TypeName = "money")]
        public decimal Total { get; set; }
    }
}
