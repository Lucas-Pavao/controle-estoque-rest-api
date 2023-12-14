using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Model
{
    public class Produto
    {
        public int Id { get; set; }

        // Troque User para int (ou Guid, dependendo da identificação do usuário)
        public int IdUser { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}
