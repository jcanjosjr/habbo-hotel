using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Andar { get; set; }
        public bool Reservado { get; set; }
        public string Descricao { get; set; }
        public string NroQuarto { get; set; }
        public double ValorQuarto { get; set; }

        public Quarto() { }
        public Quarto(
            string Andar,
            string NroQuarto,
            string Descricao,
            double ValorQuarto
        )
        {
            this.Andar = Andar;
            this.NroQuarto = NroQuarto;
            this.Descricao = Descricao;
            this.ValorQuarto = ValorQuarto;
            this.Reservado = false;

            Context db = new Context();
            db.Quartos.Add(this);
            db.SaveChanges();
        }


        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Andar: {this.Andar}"
                + $"\n Número do Quarto: {this.NroQuarto}"
                + $"\n Descrição: {this.Descricao}"
                + $"\n Valor do Quarto: R${this.ValorQuarto}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Quarto.ReferenceEquals(this, obj))
            {
                return false;
            }

            Quarto it = (Quarto)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarQuarto(
            int Id,
            string Descricao,
            double ValorQuarto
        )
        {
            try
            {
                Quarto quarto = GetQuartoById(Id);
                quarto.Descricao = Descricao;
                quarto.ValorQuarto = ValorQuarto;

                Context db = new Context();
                db.Quartos.Update(quarto);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void UpdateStatus(
            int Id
        )
        {
            try
            {
                Quarto quarto = GetQuartoById(Id);
                quarto.Reservado = true;

                Context db = new Context();
                db.Quartos.Update(quarto);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static IEnumerable<Quarto> GetQuartos()
        {
            try
            {
                Context db = new Context();
                return (from Quarto in db.Quartos select Quarto);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static IEnumerable<Quarto> GetQuartosSemReserva()
        {
            try
            {
                Context db = new Context();
                /*IEnumerable<Quarto> quartos = from Quarto in db.Quartos
                                                        where Quarto.Reservado == false
                                                        select Quarto;*/

                return (from Quarto in db.Quartos
                        where Quarto.Reservado == false
                        select Quarto);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados");
            }
        }

                public static IEnumerable<Quarto> GetQuartosReservados()
        {
            try
            {
                Context db = new Context();
                /*IEnumerable<Quarto> quartos = from Quarto in db.Quartos
                                                        where Quarto.Reservado == false
                                                        select Quarto;*/

                return (from Quarto in db.Quartos
                        where Quarto.Reservado == true
                        select Quarto);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados");
            }
        }

        public static Quarto GetQuartoById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Quarto> quartos = from Quarto in db.Quartos
                                              where Quarto.Id == Id
                                              select Quarto;

                return quartos.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverQuarto(Quarto quarto)
        {
            try
            {
                Context db = new Context();
                db.Quartos.Remove(quarto);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
    }
}