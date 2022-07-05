using System;
using System.Linq;
using System.Windows.Forms;
using Views;

public class Program
{
    public static void Main(string[] args)
    {
        // CreateHostBuilder(args).Build().Run();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Views.Login());
    }
}

