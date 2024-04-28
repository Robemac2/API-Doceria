using API_Doceria.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Column("senha")]
        [MaxLength(50)]
        public string Senha { get; set; }
        [Column("tipoUsuario", TypeName = "varchar(24)")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
