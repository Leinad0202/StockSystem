using System;
using EstoqueSystem.Models;
using EstoqueSystem.Repositories;
using EstoqueSystem.Services;

namespace EstoqueSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoRepo = new ProdutoRepository();
            var categoriaRepo = new CategoriaRepository();
            var estoque = new EstoqueService(produtoRepo, categoriaRepo);

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n=== Sistema de Estoque ===");
                Console.WriteLine("1 - Adicionar Categoria");
                Console.WriteLine("2 - Adicionar Produto");
                Console.WriteLine("3 - Vender Produto");
                Console.WriteLine("4 - Listar Produtos");
                Console.WriteLine("5 - Valor Total do Estoque");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Nome da categoria: ");
                        estoque.AdicionarCategoria(Console.ReadLine() ?? string.Empty);
                        break;
                    case "2":
                        Console.Write("Nome do produto: ");
                        string nomeProd = Console.ReadLine() ?? string.Empty;
                        Console.Write("Categoria: ");
                        string cat = Console.ReadLine() ?? string.Empty;
                        Console.Write("Quantidade: ");
                        if (!int.TryParse(Console.ReadLine(), out int qtd))
                        {
                            Console.WriteLine("Quantidade inválida.");
                            break;
                        }
                        Console.Write("Preço: ");
                        if (!double.TryParse(Console.ReadLine(), out double preco))
                        {
                            Console.WriteLine("Preço inválido.");
                            break;
                        }
                        estoque.AdicionarProduto(nomeProd, cat, qtd, preco);
                        break;
                    case "3":
                        Console.Write("Nome do produto: ");
                        string vendaNome = Console.ReadLine() ?? string.Empty;
                        Console.Write("Quantidade: ");
                        if (!int.TryParse(Console.ReadLine(), out int vendaQtd))
                        {
                            Console.WriteLine("Quantidade inválida.");
                            break;
                        }
                        estoque.VenderProduto(vendaNome, vendaQtd);
                        break;
                    case "4":
                        estoque.ListarProdutos();
                        break;
                    case "5":
                        Console.WriteLine($"Valor total do estoque: R$ {estoque.CalcularValorTotal():F2}");
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
