using System;
using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class Auth
    {
        public static Colaborador Colaborador;
        public static Colaborador ColaboradorAuth;

        public static Hospede Hopede;
        public static Hospede HospedeAuth;

        public static void ColaboradorLogado(string Matricula, string Senha)
        {
            try
            {
                Colaborador colaborador = Colaborador.GetColaboradores()
                    .Where(it => it.Matricula == Matricula
                        && BCrypt.Net.BCrypt.Verify(Matricula, it.Senha)).First();
                
                ColaboradorAuth = colaborador;
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }

        public static void HospedeLogado(string CPF, string Senha)
        {
            try
            {
                Hospede hospede = Hospede.GetHospedes()
                    .Where(it => it.CPF == CPF
                        && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)).First();
                
                HospedeAuth = hospede;
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
    }
}