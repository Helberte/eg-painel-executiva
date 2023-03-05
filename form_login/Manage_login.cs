using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eg_painel.classes.connection_bd;
using Microsoft.VisualBasic.Logging;
using Npgsql;

namespace eg_painel.form_login
{
    internal class Manage_login
    {
        private string usuario_login = "";
        private string senha = "";

        public static int Status = 0;
        public static int ID_Usuario = 0;
        public static string Nome_Usuario = "";

        public Manage_login(string usuario_login, string senha)
        {
            this.usuario_login = usuario_login;
            this.senha = senha;
        }

        public async Task<int> ValidateUser()
        {
            int retorno = 0;
            if (this.usuario_login.ToUpper() == "ADMINISTRADOR")
            {
                if (this.senha == "12345678")
                {
                    Manage_login.Status = 1;
                    Manage_login.ID_Usuario = -1;
                    Manage_login.Nome_Usuario = "Administrador";
                    retorno = 1;
                }
                else
                {
                    MessageBox.Show("Senha incorreta!", "Tente novamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    retorno = 0;
                }
            }
            else
            {
                try
                {
                    if (Connection.SetDataSource())
                    {
                        if (Connection.dataSource is not null)
                        {
                            await using var command = Connection.dataSource.CreateCommand("select u.id, u.login from usuarios u where login = 'roberto' and senha = '1'");
                            await using var reader = await command.ExecuteReaderAsync();
                           
                            while (await reader.ReadAsync())
                            {
                                Manage_login.Status = 1;
                                MessageBox.Show(reader["id"].ToString(), reader["login"].ToString());
                                retorno = 1;
                            }
                        }                        
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    retorno = 0;
                }
            }            

            return retorno;
        }
    }
}
