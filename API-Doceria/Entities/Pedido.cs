using API_Doceria.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("totalPedido", TypeName = "money")]
        public decimal TotalPedido { get; set; }
        [Column("cliente")]
        [MaxLength(50)]
        public string Cliente { get; set; }
        [Column("dataPedido")]
        public DateOnly DataPedido { get; set; }
        [Column("status", TypeName = "varchar(24)")]
        public StatusPedido Status { get; set; }
    }
}
