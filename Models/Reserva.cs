using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public bool Pago { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataEntrada { get; set; }
        public double ValorTotalReserva { get; set; }
        // Cada Reserva é associada a um Quarto.
        public int IdQuarto { get; set; }
        public Quarto Quarto { get; set; }
        // Cada Reserva é associada a um Hóspede.
        public int IdHospede { get; set; }
        public Hospede Hospede { get; set; }

        public Reserva() { }

        public Reserva(
            int IdQuarto,
            int IdHospede,
            DateTime DataEntrada
        )
        {
            this.IdQuarto = IdQuarto;
            this.IdHospede = IdHospede;
            this.DataEntrada = DataEntrada;
            this.Pago = false;
            
            // Checa o Quarto:
            if (this.Quarto.Reservado == false)
            {
                this.Quarto.Reservado = true;
            }
            else
            {
                throw new System.Exception("Quarto já consta reservado.");
            }

            Context db = new Context();
            db.Reservas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ------------------------------------"
                + $"\n ID da Reserva: {this.Id}"
                + $"\n Quarto: {this.Quarto.NroQuarto}"
                + $"\n Nome do Hóspede: {this.Hospede.Nome}"
                + $"\n Data da Entrada: {this.DataEntrada}"
                + $"\n Valor total: R$ {this.ValorTotalReserva}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !Reserva.ReferenceEquals(this, obj))
            {
                return false;
            }
            Reserva it = (Reserva)obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarReserva(
            int Id,
            DateTime DataEntrada,
            int IdQuarto
        )
        {
            try
            {
                Reserva reserva = ReservaGetById(Id);
                reserva.DataEntrada = DataEntrada;
                reserva.IdQuarto = IdQuarto;

                Context db = new Context();
                db.Reservas.Update(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException ("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void ValorTotal(int Id, int IdQuarto, int IdDespesa)
        {
            try
            {
                Reserva reserva = ReservaGetById(Id);
                Quarto quarto = Quarto.GetQuartoById(Id);
                Despesa despesa = Despesa.DespesaGetById(Id);

                reserva.ValorTotalReserva = quarto.ValorQuarto + despesa.ValorTotalDespesa;

                Context db = new Context();
                db.Reservas.Update(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void EfetuarPagamento(int Id)
        {
            try
            {
                Reserva reserva = ReservaGetById(Id);
                reserva.Pago = true;

                Context db = new Context();
                db.Reservas.Update(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RegistrarSaida(int Id)
        {
            try
            {
                Reserva reserva = ReservaGetById(Id);
                Quarto quarto = Quarto.GetQuartoById(reserva.IdQuarto);
                if (reserva.Pago == true)
                {
                    reserva.DataSaida = DateTime.Now;
                    quarto.Reservado = false;
                }
                else
                {
                    throw new SystemException("O pagamento não foi efetuado.");
                }

                Context db = new Context();
                db.Reservas.Update(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static IEnumerable<Reserva> GetReservas()
        {
            try
            {
                Context db = new Context();
                return (from Reserva in db.Reservas select Reserva);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static Reserva GetQuartoByIdReserva(int IdQuarto, int IdHospede)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Reserva> Reservas = from Reserva in db.Reservas
                                                where Reserva.IdQuarto == IdQuarto && Reserva.IdHospede == IdHospede
                                                select Reserva;

                return Reservas.First();
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }

        }

        public static Reserva ReservaGetById(int Id)
        {
            try
            {
                Context db = new Context();
                IEnumerable<Reserva> Reservas = from Reserva in db.Reservas
                                                where Reserva.Id == Id
                                                select Reserva;

                return Reservas.First();               
            }
            catch
            {
                
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");;
            }
        }

        public static IEnumerable<Reserva> ReservaGetByIdHospede(int IdHospede)
        {
            try
            {
                Context db = new Context();
                return (from Reserva in db.Reservas
                        where Reserva.IdHospede == IdHospede
                        select Reserva);
            }
            catch
            {
                throw new SystemException("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void RemoverReserva(Reserva reserva)
        {
            try
            {
                Context db = new Context();
                db.Reservas.Remove(reserva);
                db.SaveChanges();
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        // Este método tem como função, checar se teremos conflito na agenda de reserva.
        public static bool ChecaConflitoReserva(
            int IdAtual,
            int IdHospede,
            int IdQuarto,
            DateTime DataEntrada
        )
        {
            try
            {
                IEnumerable<Reserva> reservas = 
                    from Reserva in Reserva.GetReservas()
                    where Reserva.DataEntrada == DataEntrada
                    && Reserva.IdHospede == IdHospede
                    && Reserva.IdQuarto == IdQuarto
                    && Reserva.Id != IdAtual
                select Reserva;

                return reservas.Count() > 0;
            }
            catch
            {
                throw new SystemException("Não conseguimos efetuar a conexão com o banco de dados.");
            }
        }
    }
}
