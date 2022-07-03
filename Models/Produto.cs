using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Produto
    {
		public int Id { get; set; }
		public string Nome { get; set; }
        public double ValorProduto { get; set; }

        public Produto() { }

        public Produto(
            string Nome,
            double ValorProduto
        )
        {
            this.Nome = Nome;
            this.ValorProduto = ValorProduto;

            Context db = new Context();
            db.Produtos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n ValorProduto: R$ {this.ValorProduto}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Produto.ReferenceEquals(this, obj))
            {
            return false;
            }

            Produto it = (Produto)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarProduto(
            int Id,
            string Nome,
            double ValorProduto
        )
        {
            try
            {
                Produto produto = GetProdutoById(Id);
                produto.Nome = Nome;
                produto.ValorProduto = ValorProduto;

                Context db = new Context();
                db.Produtos.Update(produto);
                db.SaveChanges();
            }
            catch 
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }


        public static IEnumerable<Produto> GetProdutos()
        {
            try
            {
                Context db = new Context();
                return (from Produto in db.Produtos select Produto);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static Produto GetProdutoById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Produto> produtos = from Produto in db.Produtos
                                                        where Produto.Id == Id
                                                        select Produto;

                return produtos.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverProduto(Produto produto)
        {
            try
            {
                Context db = new Context();
                db.Produtos.Remove(produto);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
    }
}