namespace EstoqueSystem.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        // parameterless constructor for deserialization
        public Produto()
        {
            Nome = string.Empty;
            Categoria = new Categoria();
            Quantidade = 0;
            Preco = 0.0;
        }

        public Produto(string nome, Categoria categoria, int quantidade, double preco)
        {
            Nome = nome;
            Categoria = categoria;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
