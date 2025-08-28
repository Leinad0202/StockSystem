namespace EstoqueSystem.Models
{
    public class Categoria
    {
        public string Nome { get; set; }

        // parameterless constructor for deserialization
        public Categoria() { Nome = string.Empty; }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}
