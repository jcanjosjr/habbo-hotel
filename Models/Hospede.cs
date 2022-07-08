using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Hospede
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string NumeroCartao { get; set; }
        public string CVVcartao {get; set; }
        public string DataValidadeCartao { get; set; }
        public string FormaPagamento { get; set; }
        public string NomeMae { get; set; }
        public static Hospede HospedeAuth;

        public Hospede() { }

        public Hospede(
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
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.CPF = CPF;
            this.Senha = Senha;
            this.NumeroCartao = NumeroCartao;
            this.CVVcartao = CVVcartao;
            this.DataValidadeCartao = DataValidadeCartao;
            this.FormaPagamento = FormaPagamento;
            this.NomeMae = NomeMae;

            Context db = new Context();
            db.Hospedes.Add(this);
            db.SaveChanges();
        }

         public Hospede(
            string Nome,
            DateTime DataNascimento,
            string CPF,
            string Senha,
            string NumeroCartao,
            string CVVcartao,
            string DataValidadeCartao,
            string NomeMae
        )
        {
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.CPF = CPF;
            this.Senha = Senha;
            this.NumeroCartao = NumeroCartao;
            this.CVVcartao = CVVcartao;
            this.DataValidadeCartao = DataValidadeCartao;
            this.NomeMae = NomeMae;

            Context db = new Context();
            db.Hospedes.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Data Nascimento: {this.DataNascimento.ToString("dd/MM/yyyy")}"
                + $"\n Forma de Pagamento: {this.FormaPagamento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Hospede.ReferenceEquals(this, obj))
            {
            return false;
            }

            Hospede it = (Hospede)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarHospede(
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
            try
            {
                Hospede hospede = GetHospedeById(Id);
                hospede.Nome = Nome;
                hospede.DataNascimento = DataNascimento;
                hospede.CPF = CPF;
                hospede.Senha = Senha;
                hospede.NumeroCartao = NumeroCartao;
                hospede.CVVcartao = CVVcartao;
                hospede.DataValidadeCartao = DataValidadeCartao;
                hospede.FormaPagamento = FormaPagamento;
                hospede.NomeMae = NomeMae;

                Context db = new Context();
                db.Hospedes.Update(hospede);
                db.SaveChanges();
            }
            catch 
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }


        public static IEnumerable<Hospede> GetHospedes()
        {
            Context db = new Context();
            return (from Hospede in db.Hospedes select Hospede);
        }

        public static Hospede GetHospedeById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Hospede> hospedes = from Hospede in db.Hospedes
                                                        where Hospede.Id == Id
                                                        select Hospede;

                return hospedes.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverHospede(Hospede hospede)
        {
            try
            {
                Context db = new Context();
                db.Hospedes.Remove(hospede);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void Auth(string CPF, string Senha)
        {
            try
            {
                Hospede hospede = Hospede.GetHospedes()
                    .Where(it => it.CPF == CPF
                        && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)
                    )
                    .First();

                HospedeAuth = hospede;    
            }
            catch
            {
                throw new System.Exception("aaaaaaaaaaaaaaaados.");
            }   
        }
    }
}