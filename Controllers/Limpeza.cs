using Models;
using System;

namespace Controllers
{
    public class LimpezaController
    {
        public static Limpeza IncluirLimpeza(
            int IdReserva,
            int IdColaborador,
            DateTime DataLimpeza
        )
        {
            Reserva.ReservaGetById(IdReserva);
            Colaborador.GetColaboradorById(IdColaborador);

            if (DataLimpeza == null || DataLimpeza < DateTime.Now)
            {
                throw new Exception("A data não pode ser nula ou retroativa.");
            }

            return new Limpeza(IdReserva, IdColaborador, DataLimpeza);
        }

        public static Limpeza AlterarLimpeza(
            int Id,
            int IdReserva,
            int IdColaborador,
            DateTime DataLimpeza
        )
        {
            Limpeza limpeza = Limpeza.LimpezaGetById(Id);
            Reserva reserva = Reserva.ReservaGetById(Id);
            Colaborador colaborador = Colaborador.GetColaboradorById(Id);

            if (DataLimpeza == null || DataLimpeza < DateTime.Now)
            {
                throw new Exception("A data não pode ser nula ou retroativa.");
            }

            return limpeza;
        }

        public static Limpeza RemoveLimpeza(int Id)
        {
            try
            {
                Limpeza limpeza = Limpeza.LimpezaGetById(Id);
                Limpeza.RemoverLimpeza(limpeza);
                return limpeza;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao remover a Limpeza.");
            }
        }
    }
}