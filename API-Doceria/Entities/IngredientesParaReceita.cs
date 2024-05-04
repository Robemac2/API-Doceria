using API_Doceria.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Doceria.Entities
{
    public class IngredientesParaReceita
    {
        [NotMapped]
        public Ingrediente Ingrediente { get; set; }
        public int Quantidade { get; set; }
        public Unidade Unidade { get; set; }
        public decimal Preco { get; set; }
    }
}
