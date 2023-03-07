using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eg_painel.classes.connection_bd;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eg_painel.form_login
{
    internal class Manage_login
    {
        private string usuario_login = "";
        private string senha = "";

        public static int Status = 0;
        public static int Id_usuario = 0;
        public static int Id_camara = 0;
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
                    Manage_login.Id_usuario = -1;
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
                            bool checks_response = true;
                            string query_selector = "";
                            query_selector = "select us.id usuario_id, us.senha, pe.apelido_exibicao apelido, en.id entidade_id from usuarios us " +
                                                " inner join pessoa pe on us.fk_pessoa = pe.cpf " +
                                                " inner join entidade en on en.id = pe.fk_entidade " +
                                                " where UPPER(us.login) = '" + this.usuario_login.ToUpper() + "' " +
                                                " and pe.status = '1'";


                            await using var command = Connection.dataSource.CreateCommand(query_selector);
                            await using var reader = await command.ExecuteReaderAsync();

                           
                            while (await reader.ReadAsync())
                            {
                                if (!String.IsNullOrEmpty(reader["usuario_id"].ToString()))
                                {

                                    Manage_login.Nome_Usuario = reader["apelido"].ToString() ?? "";
                                    Manage_login.Id_camara = Convert.ToInt32(reader["entidade_id"].ToString());
                                    Manage_login.Id_usuario = Convert.ToInt32(reader["usuario_id"].ToString());
                                                                        
                                    checks_response = false;                                                                    

                                    if (ValidadePassword( await GetPassword(this.usuario_login), this.senha))
                                    {
                                        Manage_login.Status = 1;
                                        retorno = 1;
                                    }
                                    else
                                    {
                                        Manage_login.Status = 0;
                                        retorno = 0;
                                        MessageBox.Show("Senha incorreta para o usuário " + this.usuario_login + ".");
                                    }
                                }
                            }

                            if (checks_response)
                            {
                                Manage_login.Status = 0;
                                retorno = 0;

                                MessageBox.Show("O usuário " + this.usuario_login + " não existe em nossa base de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }                           
                        }                        
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    Manage_login.Status = 0;
                    retorno = 0;
                }
            }            

            return retorno;
        }

        private async Task<string> GetPassword(string user)
        {
            string response = "";
            if (Connection.dataSource is not null)
            {
                string query_selector = "";
                query_selector = "select us.senha as password from usuarios us where UPPER(us.login) = '" + user.ToUpper() + "'";

                await using var command = Connection.dataSource.CreateCommand(query_selector);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    response = reader["password"].ToString() ?? "";
                }
            }
            return response;
        }

        private bool ValidadePassword(string bytesPassword, string password)
        {
            bool response = false;

            string[] passwordDB = bytesPassword.Split("-");
            string passwordBanco = "";
            string passwordInformate = "";

            byte[] salt = new byte[16];
            byte[] passwordDbBytes = new byte[36];

            for (int i = 0; i < passwordDB.Length; i++)
            {
                if (i < salt.Length)
                {
                    salt[i] = Convert.ToByte(passwordDB[i]);
                }
                passwordDbBytes[i] = Convert.ToByte(passwordDB[i]);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 20000, HashAlgorithmName.SHA512);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            passwordBanco = Convert.ToBase64String(passwordDbBytes);
            passwordInformate = Convert.ToBase64String(hashBytes);

            if (passwordBanco == passwordInformate)            
                response = true;
            
            return response;
        }
    }
}
