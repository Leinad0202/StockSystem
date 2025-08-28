using System.Collections.Generic;
using System.Linq;
using EstoqueSystem.Models;

namespace EstoqueSystem.Repositories
{
    public class CategoriaRepository
    {
        private List<Categoria> categorias = new List<Categoria>();

        public void Adicionar(Categoria categoria)
        {
            if (!categorias.Any(c => c.Nome == categoria.Nome))
                categorias.Add(categoria);
        }

        public Categoria? BuscarPorNome(string nome)
        {
            return categorias.FirstOrDefault(c => c.Nome == nome);
        }

        public List<Categoria> ObterTodos()
        {
            return categorias;
        }
    }
}
