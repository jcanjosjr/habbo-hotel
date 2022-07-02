using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Limpeza
    {
        public int Id { get; set; }
        // Cada limpeza é associado a uma reserva.
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }
        // Cada limpeza é associada a um colaborador.
        public int IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        // Data de limpeza.
        public DateTime DataLimpeza { get; set; }


        public Limpeza() { }

        public Limpeza(
            int IdReserva,
            int IdColaborador,
            DateTime DataLimpeza
        )
        {
            this.IdReserva = IdReserva;
            this.IdColaborador = IdColaborador;
            this.DataLimpeza = DataLimpeza;

            Context db = new Context();
            db.Limpezas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Reserva ID: {this.IdReserva}"
                + $"\n Nome Colaborador: {this.Colaborador.Nome}"
                + $"\n Data da Limpeza: {this.DataLimpeza}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Limpeza.ReferenceEquals(this, obj))
            {
                return false;
            }
            Limpeza it = (Limpeza)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarLimpeza(
            int Id,
            int IdReserva,
            int IdColaborador,
            DateTime DataLimpeza
        )
        {
            try
            {
                Limpeza limpeza = LimpezaGetById(Id);
                limpeza.IdReserva = IdReserva;
                limpeza.IdColaborador = IdColaborador;
                limpeza.DataLimpeza = DataLimpeza;

                Context db = new Context();
                db.Limpezas.Update(limpeza);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static IEnumerable<Limpeza> GetLimpezas()
        {
            try
            {
                Context db = new Context();
                return (from Limpeza in db.Limpezas select Limpeza);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static Limpeza GetLimpeza(int IdReserva, int IdColaborador)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Limpeza> Limpezas = from Limpeza in db.Limpezas
                                                where Limpeza.IdReserva == IdReserva && Limpeza.IdColaborador == IdColaborador
                                                select Limpeza;

                return Limpezas.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }

        }

        public static Limpeza LimpezaGetById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Limpeza> Limpezas = from Limpeza in db.Limpezas
                                                where Limpeza.Id == Id
                                                select Limpeza;

                return Limpezas.First();               
            }
            catch
            {
                
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");;
            }
        }

        public static IEnumerable<Limpeza> LimpezaGetByIdReserva(int IdReserva)
        {
            try
            {
                Context db = new Context();
                return (from Limpeza in db.Limpezas
                        where Limpeza.IdReserva == IdReserva
                        select Limpeza);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverLimpeza(Limpeza limpeza)
        {
            try
            {
                Context db = new Context();
                db.Limpezas.Remove(limpeza);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
    }
}