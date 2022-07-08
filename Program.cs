using Views;
using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;

public class Program
{
    public static void Main(string[] args)
    {
        // CreateHostBuilder(args).Build().Run();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Controllers.ColaboradorController.CriarColaborador("ADMIN","admin","admin");
        Application.Run(new Views.Login());
    }
}

