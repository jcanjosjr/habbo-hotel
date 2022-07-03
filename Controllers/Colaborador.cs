using System;
using Models;

namespace Controllers
{
    public class ColaboradorController
    {
        public static Colaborador CriarColaborador(
            string Nome,
            string Senha,
            string Matricula
        )
        {
            try
            {
                if (String.IsNullOrEmpty(Nome))
                {
                    throw new Exception("Campo referente ao Nome esta inválido.");
                }

                if (String.IsNullOrEmpty(Senha))
                {
                    throw new Exception("Senha inválida.");
                }
                else
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                }

                if (String.IsNullOrEmpty(Matricula))
                {
                    throw new Exception("Campo referente a Matrícula esta inválido.");
                }

                return new Colaborador(Nome, Senha, Matricula);
            }
            catch
            {
                throw new Exception("Possuímos um erro ao cadastrar a Despesa.");
            }
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
                Colaborador colaborador = Colaborador.GetColaboradorById(Id);

                if (!String.IsNullOrEmpty(Nome))
                {
                    Nome = colaborador.Nome;
                }

                if (!String.IsNullOrEmpty(Senha))
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                    Senha = colaborador.Senha;
                }

                if (!String.IsNullOrEmpty(Matricula))
                {
                    Matricula = colaborador.Matricula;
                }

                Colaborador.AlterarColaborador(Id, Nome, Senha, Matricula);
            }
            catch
            {
                throw new Exception("Possuímos um erro ao alterar a Despesa.");
            }
        }

        public static Colaborador RemoveColaborador(int Id)
        {
            try
            {
                Colaborador colaborador = Colaborador.GetColaboradorById(Id);
                Colaborador.RemoverColaborador(colaborador);
                return colaborador;
            }
            catch
            {
                throw new Exception("Possuímos um erro ao remover o Colaborador.");
            }
        }
    }
}