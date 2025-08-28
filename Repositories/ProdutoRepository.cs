using System.Collections.Generic;
using System.Linq;
using EstoqueSystem.Models;

namespace EstoqueSystem.Repositories
{
    public class ProdutoRepository
    {
        private List<Produto> produtos = new List<Produto>();

        public void Adicionar(Produto produto)
        {
            produtos.Add(produto);
        }

        public Produto? BuscarPorNome(string nome)
        {
            return produtos.FirstOrDefault(p => p.Nome == nome);
        }

        public List<Produto> ObterTodos()
        {
            return produtos;
        }
    }
}
