using System;
using System.Collections.Generic;
using EstoqueSystem.Models;
using EstoqueSystem.Repositories;
using EstoqueSystem.Utils;

namespace EstoqueSystem.Services
{
    public class EstoqueService
    {
        private ProdutoRepository _produtoRepo;
        private CategoriaRepository _categoriaRepo;
        private const string arquivoProdutos = "produtos.json";
        private const string arquivoCategorias = "categorias.json";

        public EstoqueService(ProdutoRepository produtoRepo, CategoriaRepository categoriaRepo)
        {
            _produtoRepo = produtoRepo;
            _categoriaRepo = categoriaRepo;
            CarregarDados();
        }

        public void AdicionarCategoria(string nome)
        {
            var categoria = new Categoria(nome);
            _categoriaRepo.Adicionar(categoria);
            SalvarDados();
        }

        public void AdicionarProduto(string nome, string nomeCategoria, int qtd, double preco)
        {
            var categoria = _categoriaRepo.BuscarPorNome(nomeCategoria);
            if (categoria == null)
            {
                categoria = new Categoria(nomeCategoria);
                _categoriaRepo.Adicionar(categoria);
            }

            var produto = new Produto(nome, categoria, qtd, preco);
            _produtoRepo.Adicionar(produto);
            SalvarDados();
        }

        public void VenderProduto(string nome, int quantidade)
        {
            var produto = _produtoRepo.BuscarPorNome(nome);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            if (produto.Quantidade >= quantidade)
            {
                produto.Quantidade -= quantidade;
                Console.WriteLine($"{quantidade} unidades de {nome} vendidas.");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("Estoque insuficiente.");
            }
        }

        public void ListarProdutos()
        {
            var produtos = _produtoRepo.ObterTodos();
            Console.WriteLine("\n=== Estoque Atual ===");
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.Nome} - {p.Categoria.Nome} - Qtd: {p.Quantidade} - Preço: R${p.Preco:F2}");
            }
        }

        public double CalcularValorTotal()
        {
            double total = 0;
            foreach (var p in _produtoRepo.ObterTodos())
                total += p.Quantidade * p.Preco;
            return total;
        }

        private void SalvarDados()
        {
            Persistencia.Salvar(_produtoRepo.ObterTodos(), arquivoProdutos);
            Persistencia.Salvar(_categoriaRepo.ObterTodos(), arquivoCategorias);
        }

        private void CarregarDados()
        {
            var produtos = Persistencia.Carregar<List<Produto>>(arquivoProdutos);
            var categorias = Persistencia.Carregar<List<Categoria>>(arquivoCategorias);

            if (categorias != null)
                foreach (var c in categorias) _categoriaRepo.Adicionar(c);
            if (produtos != null)
                foreach (var p in produtos) _produtoRepo.Adicionar(p);
        }
    }
}
