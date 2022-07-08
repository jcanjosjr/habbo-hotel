using System;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class AuthController
    {
        public static void ColaboradorLogado(string Matricula, string Senha)
        {
            if (String.IsNullOrEmpty(Matricula))
            {
                throw new Exception("Por favor, preencha a matrícula.");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Por favor, preencha a senha.");
            }

            Colaborador.Auth(Matricula, Senha);
        }

        public static void HospedeLogado(string CPF, string Senha)
        {
            if (String.IsNullOrEmpty(CPF))
            {
                throw new Exception("Por favor, preencha a matrícula.");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Por favor, preencha a senha.");
            }

            Hospede.Auth(CPF, Senha);
        }
    }
}