using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Colaborador
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Senha { get; set; }
		public string Matricula { get; set; }
        public static Colaborador ColaboradorAuth;

        public Colaborador() { }

        public Colaborador(
            string Nome,
            string Senha,
            string Matricula
        )
        {
            this.Nome = Nome;
            this.Matricula = Matricula;
            this.Senha = Senha;

            Context db = new Context();
            db.Colaboradores.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Matricula: {this.Matricula}"
                + $"\n Senha: {this.Senha}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Colaborador.ReferenceEquals(this, obj))
            {
            return false;
            }

            Colaborador it = (Colaborador)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarColaborador(
            int Id,
            string Nome,
            string Senha,
            string Matricula
        )
        {
            try
            {
                Colaborador colaborador = GetColaboradorById(Id);
                colaborador.Nome = Nome;
                colaborador.Senha = Senha;
                colaborador.Matricula = Matricula;

                Context db = new Context();
                db.Colaboradores.Update(colaborador);
                db.SaveChanges();
            }
            catch 
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }


        public static IEnumerable<Colaborador> GetColaboradores()
        {
            Context db = new Context();
            return (from Colaborador in db.Colaboradores select Colaborador);
        }

        public static Colaborador GetColaboradorById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Colaborador> colaboradores = from Colaborador in db.Colaboradores
                                                        where Colaborador.Id == Id
                                                        select Colaborador;

                return colaboradores.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverColaborador(Colaborador colaborador)
        {
            try
            {
                Context db = new Context();
                db.Colaboradores.Remove(colaborador);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void Auth(string Matricula, string Senha)
        {
            try
            {
                Colaborador colaborador = Colaborador.GetColaboradores()
                    .Where(it => it.Matricula == Matricula
                        && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)
                    )
                    .First();

                ColaboradorAuth = colaborador;   

            }
            catch
            {
                throw new System.Exception("Aqui 1");
            }   
        }
    }
}