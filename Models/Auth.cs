using System.Linq;

namespace Models
{
    public class Auth
    {
        public static Colaborador Colaborador;
        public static Hospede Hospede;
        public static bool EstaLogado;
        public static void ColaboradorLogado(string Matricula, string Senha)
        {
            try
            {
                Colaborador colaborador = Colaborador.GetColaboradores()
                    .Where(it => it.Matricula == Matricula
                        && BCrypt.Net.BCrypt.Verify(Senha, it.Senha)).First();
                
                if (colaborador != null)
                {
                    EstaLogado = true;
                    Colaborador = colaborador;
                    Hospede = null;
                }
                else
                {
                    Sair();
                }
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
                
                EstaLogado = true;

                if (hospede != null)
                {
                    EstaLogado = true;
                    Hospede = hospede;
                    Colaborador = null;
                }
                else
                {
                    Sair();
                }
            }
            catch
            {
                throw new System.Exception("Não conseguimos conectar com o Banco de Dados.");
            }
        }
        public static void Sair()
        {
            EstaLogado = false;
            Hospede = null;
            Colaborador = null;
        }
    }
}