
using ControleDeEstoque.Model;

namespace ControleDeEstoque.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(int id);
        void AddProduto(Produto produto);
        void UpdateProduto(Produto produto);
        void DeleteProduto(Produto id);

        Task<bool> SaveChangesAsync();
    }
}