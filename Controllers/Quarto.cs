using Models;
using System;

namespace Controllers
{
    public class QuartoController
    {
        public static Quarto IncluirQuarto(
            string Andar,
            string NroQuarto,
            string Descricao,
            double ValorQuarto
        )
        {
            if (String.IsNullOrEmpty(Andar))
            {
                throw new Exception("Campo referente ao Andar esta inválido.");
            }

            if (String.IsNullOrEmpty(NroQuarto))
            {
                throw new Exception("Campo referente ao Número do Quarto está inválido.");
            }

            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Campo referente a Descrição está inválido.");
            }

            if (ValorQuarto <= 0)
            {
                throw new Exception("O valor não poderá ser negativo ou igual a zero.");
            }

            return new Quarto(Andar, NroQuarto, Descricao, ValorQuarto);
        }

        public static void AlterarQuarto(
            int Id,
            string Descricao,
            double ValorQuarto
        )
        {
            Quarto quarto = Quarto.GetQuartoById(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                Descricao = quarto.Descricao;
            }

            if (ValorQuarto <= 0)
            {
                throw new Exception("O valor não poderá ser negativo ou igual a zero.");
            }
            else
            {
                ValorQuarto = quarto.ValorQuarto;
            }

            Quarto.AlterarQuarto(Id, Descricao, ValorQuarto);
        }

        public static Quarto RemoveQuarto(int Id)
        {
            try
            {
                Quarto quarto = Quarto.GetQuartoById(Id);
                Quarto.RemoverQuarto(quarto);
                return quarto;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao remover o Quarto.");
            }
        }
    }
}