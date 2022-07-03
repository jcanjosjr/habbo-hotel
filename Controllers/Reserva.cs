using System;
using Models;

namespace Controllers
{
    public class ReservaControllers
    {
        public static Reserva CriarReserva(
            int IdQuarto,
            int IdHospede,
            DateTime DataEntrada
        )
        {
            try
            {
                Quarto.GetQuartoById(IdQuarto);
                Hospede.GetHospedeById(IdHospede);

                if (DataEntrada == null || DataEntrada < DateTime.Now)
                {
                    throw new Exception("A data não pode ser nula ou retroativa.");
                }

                if(Reserva.ChecaConflitoReserva(0, IdHospede, IdQuarto, DataEntrada))
                {
                    throw new Exception("Desculpe, já possuímos reserva neste dia.");
                }

                return new Reserva(IdQuarto, IdHospede, DataEntrada);
            }
            catch
            {
                throw new Exception("Possuímos um erro ao Cadastrar a Reserva.");
            }
        }

        public static void AlterarReserva(
            int Id,
            int IdQuarto,
            DateTime DataEntrada
        )
        {
            try
            {
                Reserva reserva = Reserva.ReservaGetById(Id);
                Quarto.GetQuartoById(Id);

                if (DataEntrada == null || DataEntrada < DateTime.Now)
                {
                    throw new Exception("A data não pode ser nula ou retroativa.");
                }
                else
                {
                    reserva.DataEntrada = DataEntrada;
                }

                Reserva.AlterarReserva(Id, DataEntrada, IdQuarto);
            }
            catch
            {
                throw new Exception("Possuímos um erro ao Alterar a Reserva.");
            }
        }

        public static Reserva RemoveReserva(int Id)
        {
            try
            {
                Reserva reserva = Reserva.ReservaGetById(Id);
                Reserva.RemoverReserva(reserva);
                return reserva;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao Remover a Reserva.");
            }
        }
    }
}