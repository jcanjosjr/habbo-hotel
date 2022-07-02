using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public int QuantidadeProduto { get; set; }
        public float ValorTotalDespesa { get; set; }
        // Cada Despesa possui uma Reserva.
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }
        // Cada Despesa possui N Produtos
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        public Despesa() { }

        public Despesa(
            int IdReserva,
            int IdProduto,
            int QuantidadeProduto
        )
        {
            this.IdReserva = IdReserva;
            this.IdProduto = IdProduto;
            this.QuantidadeProduto = QuantidadeProduto;

            Context db = new Context();
            db.Despesas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID da Despesa: {this.Id}"
                + $"\n ID da Reserva: {this.Reserva.Id}"
                + $"\n Produto: {this.Produto.Nome}"
                + $"\n Quantidade: {this.QuantidadeProduto}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Despesa.ReferenceEquals(this, obj))
            {
                return false;
            }
            Despesa it = (Despesa)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarDespesa(
            int Id,
            int IdReserva,
            int IdProduto,
            int QuantidadeProduto
        )
        {
            try
            {
                Despesa despesa = DespesaGetById(Id);
                despesa.IdReserva = IdReserva;
                despesa.IdProduto = IdProduto;
                despesa.QuantidadeProduto = QuantidadeProduto;

                Context db = new Context();
                db.Despesas.Update(despesa);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void CalculaTotalDespesa(int Id, int IdProduto, int QuantidadeProduto)
        {
            try
            {
                Despesa despesa = DespesaGetById(Id);
                Produto produto = Produto.GetProdutoById(IdProduto);
                try
                {
                    despesa.ValorTotalDespesa = produto.ValorProduto * despesa.QuantidadeProduto;
                }
                catch
                {
                    throw new SystemException("Um erro ocorreu durante a soma dos produtos.");
                }

                Context db = new Context();
                db.Despesas.Update(despesa);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static IEnumerable<Despesa> GetDespesas()
        {
            try
            {
                Context db = new Context();
                return (from Despesa in db.Despesas select Despesa);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static Despesa GetDespesa(int IdProduto, int IdReserva)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Despesa> Despesas = from Despesa in db.Despesas
                                                where Despesa.IdProduto == IdProduto && Despesa.IdReserva == IdReserva
                                                select Despesa;

                return Despesas.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }

        }

        public static Despesa DespesaGetById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Despesa> Despesas = from Despesa in db.Despesas
                                                where Despesa.Id == Id
                                                select Despesa;

                return Despesas.First();               
            }
            catch
            {
                
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");;
            }
        }

        public static IEnumerable<Despesa> DespesaGetByIdReserva(int IdReserva)
        {
            try
            {
                Context db = new Context();
                return (from Despesa in db.Despesas
                        where Despesa.IdReserva == IdReserva
                        select Despesa);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverDespesa(Despesa despesa)
        {
            try
            {
                Context db = new Context();
                db.Despesas.Remove(despesa);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
    }
}