using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext context;

        public ProdutoRepository(ProdutoDbContext context)
        {
            this.context = context;
        }

        // Adiciona um novo produto ao contexto
        public void AddProduto(Produto produto)
        {
            context.Add(produto);
        }

        // Remove um produto do contexto
        public void DeleteProduto(Produto produto)
        {
            context.Remove(produto);
        }

        // Obtém um produto por ID de forma assíncrona
        public async Task<Produto> GetProduto(int id)
        {
            // Utiliza LINQ para encontrar um produto com o ID fornecido
            return await context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        // Obtém todos os produtos de forma assíncrona
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            // Retorna todos os produtos no contexto
            return await context.Produtos.ToListAsync();
        }

        // Salva as alterações no contexto de forma assíncrona
        public async Task<bool> SaveChangesAsync()
        {
            // Verifica se houve alguma alteração no contexto ao chamar SaveChangesAsync
            return await context.SaveChangesAsync() > 0;
        }

        // Atualiza um produto no contexto
        public void UpdateProduto(Produto produto)
        {
            context.Update(produto);
        }
    }
}
