using Models;
using System;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class HospedeController
    {
        public static Hospede IncluirHospede(
            string Nome,
            DateTime DataNascimento,
            string CPF,
            string Senha,
            string NumeroCartao,
            string CVVcartao,
            string DataValidadeCartao,
            string FormaPagamento,
            string NomeMae
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Campo referente ao Nome esta inválido.");
            }

            if (DataNascimento == null || DataNascimento < DateTime.Now)
            {
                throw new Exception("A data não pode ser nula ou retroativa.");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválida.");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            Regex regexCpf = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(CPF) || !regexCpf.IsMatch(CPF))
            {
                throw new Exception("CPF inválido");
            }

            Regex regexNumeros = new Regex("[0-9]");
            if (String.IsNullOrEmpty(NumeroCartao) || !regexNumeros.IsMatch(NumeroCartao))
            {
                throw new Exception("Campo referente ao Número do Cartão está inválido.");
            }

            if (String.IsNullOrEmpty(CVVcartao) || !regexNumeros.IsMatch(CVVcartao))
            {
                throw new Exception("Campo referente ao CVV está inválido.");
            }

            Regex regexDataCartao = new Regex("0[1-9]|1[0-2]");
            if (String.IsNullOrEmpty(DataValidadeCartao) || !regexDataCartao.IsMatch(DataValidadeCartao))
            {
                throw new Exception("Validado do cartão inválida..");
            }

            if (String.IsNullOrEmpty(FormaPagamento))
            {
                throw new Exception("Forma de pagamento inválida.");
            }

            if (String.IsNullOrEmpty(NomeMae))
            {
                throw new Exception("Nome da mãe inválido.");
            }

            return new Hospede(
                Nome,
                DataNascimento,
                CPF,
                Senha,
                NumeroCartao,
                CVVcartao,
                DataValidadeCartao,
                FormaPagamento,
                NomeMae
            );
        }

        public static Hospede AlterarHospede(
            int Id,
            string Nome,
            DateTime DataNascimento,
            string CPF,
            string Senha,
            string NumeroCartao,
            string CVVcartao,
            string DataValidadeCartao,
            string FormaPagamento,
            string NomeMae
        )
        {
            Hospede hospede = Hospede.GetHospedeById(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                Nome = hospede.Nome;
            }

            if (DataNascimento == null || DataNascimento < DateTime.Now)
            {
                throw new Exception("A data não pode ser nula ou retroativa.");
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                Senha = hospede.Senha;
            }

            Regex regexCpf = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (!(String.IsNullOrEmpty(CPF) || !regexCpf.IsMatch(CPF)))
            {
                CPF = hospede.CPF;
            }

            Regex regexNumeros = new Regex("[0-9]");
            if (!(String.IsNullOrEmpty(NumeroCartao) || !regexNumeros.IsMatch(NumeroCartao)))
            {
                NumeroCartao = hospede.NumeroCartao;
            }

            if (String.IsNullOrEmpty(CVVcartao) || !regexNumeros.IsMatch(CVVcartao))
            {
                CVVcartao = hospede.CVVcartao;
            }

            Regex regexDataCartao = new Regex("0[1-9]|1[0-2]");
            if (!(String.IsNullOrEmpty(DataValidadeCartao) || !regexDataCartao.IsMatch(DataValidadeCartao)))
            {
                DataValidadeCartao = hospede.DataValidadeCartao;
            }

            if (!(String.IsNullOrEmpty(FormaPagamento)))
            {
                FormaPagamento = hospede.FormaPagamento;
            }

            if (!(String.IsNullOrEmpty(NomeMae)))
            {
                NomeMae = hospede.NomeMae;
            }

            return hospede;
        }

        public static Hospede RemoveHospede(int Id)
        {
            try
            {
                Hospede hospede = Hospede.GetHospedeById(Id);
                Hospede.RemoverHospede(hospede);
                return hospede;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao remover o Hospéde.");
            }
        }
    }
}