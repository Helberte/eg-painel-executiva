using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using Npgsql;

namespace eg_painel.classes.connection_bd
{
    internal class Connection
    {
        private static string strConnection = "";
        public static NpgsqlDataSource? dataSource;

        private Connection() {  }
                     
        private static void ReadFileConnection()
        {
            Connection_file connection_file = new();

            if (connection_file.LerArquivo())
            {
                strConnection = String.Format(
                   "Server={0};Username={1};Database={2};Port={3};Password={4};",
                   connection_file.Ip,
                   connection_file.Usuario,
                   "painelvotacao",
                   "5432",
                   connection_file.Senha);
            }
        }

        public static bool SetDataSource()
        {
            bool ret = false;

            try
            {
                if (Connection.dataSource is null)
                {
                    ReadFileConnection();
                    Connection.dataSource = NpgsqlDataSource.Create(Connection.strConnection);                    
                }
                ret = true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erro na conexão com o banco. " + e.Message.ToString());
                ret = false;
            }                    
            return ret;
        }
    }
}
