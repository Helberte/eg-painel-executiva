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
        static string strConnection = "";
        Connection_file? connection_file;
           

        private Connection()
        {
            connection_file = new();

            if (connection_file.LerArquivo())
            {
                Connection.strConnection = String.Format(
                   "Server={0};Username={1};Database={2};Port={3};Password={4};",
                   connection_file.Ip,
                   connection_file.Usuario,
                   "painelvotacao",
                   "5432",
                   connection_file.Senha);
            }    
        }

        public static string GetStringConnetion()
        {
            Connection connection = new();
            return strConnection;
        }

    }
}
