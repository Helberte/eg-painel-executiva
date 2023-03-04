using eg_painel.classes.connection_bd;
using eg_painel.form_login;
using System.Net.NetworkInformation;

namespace eg_painel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Connection_file file = new Connection_file();

            if (file.LerArquivo())
            {
                try
                {
                    var ping = new Ping();
                    var resposta = ping.Send(file.Ip ?? "localhost", 3);

                    if ((resposta != null) && (resposta.Status == IPStatus.Success))
                    {

                        // To customize application configuration such as set high DPI settings or default font,
                        // see https://aka.ms/applicationconfiguration.
                        ApplicationConfiguration.Initialize();

                        Form_login_inicial login = new Form_login_inicial();
                        login.ShowDialog();

                        if (Manage_login.Status == 1)
                        {
                            Application.Run(new Form1());
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Servidor não encontrado," +
                            " aplicação não será iniciada.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problemas na inicialização: IP: " + file.Ip + "\n" + e.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }
    }
}