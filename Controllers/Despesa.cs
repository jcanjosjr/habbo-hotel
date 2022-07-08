using System;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class DespesaControllers
    {
        public static Despesa CriarDespesa(
            int IdReserva,
            int IdProduto,
            int QuantidadeProduto
        )
        {
            try
            {
                Reserva.ReservaGetById(IdReserva);
                Produto.GetProdutoById(IdProduto);

                Regex regexNumeros = new Regex("[0-9]");
                if (QuantidadeProduto <= 0 || !regexNumeros.IsMatch(QuantidadeProduto.ToString()))
                {
                    throw new Exception("A quantidade de produtos não pode ser zero ou inferior.");
                }
                return new Despesa(IdReserva, IdProduto, QuantidadeProduto);
            }
            catch
            {
                throw new Exception("Possuímos um erro ao cadastrar a Despesa.");
            }
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
                Despesa despesa = Despesa.DespesaGetById(Id);
                Reserva.ReservaGetById(IdReserva);
                Produto.GetProdutoById(IdProduto);

                Regex regexNumeros = new Regex("[0-9]");
                if (!(QuantidadeProduto <= 0 || !regexNumeros.IsMatch(QuantidadeProduto.ToString())))
                {
                   QuantidadeProduto = despesa.QuantidadeProduto;
                }

                Despesa.AlterarDespesa(
                    Id,
                    IdReserva,
                    IdProduto,
                    QuantidadeProduto
                );
            }
            catch
            {
                throw new Exception("Possuímos um erro ao alterar a Despesa.");
            }
        }

        public static Despesa RemoveDespesa(int Id)
        {
            try
            {
                Despesa despesa = Despesa.DespesaGetById(Id);
                Despesa.RemoverDespesa(despesa);
                return despesa;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao remover a Despesa.");
            }
        }
    }
}