using eg_painel.classes.connection_bd;
using eg_painel.form_login;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eg_painel.classes
{
    internal class ClassFormCheckAccesses
    {
        public async Task<List<string[]>?> GetUsers()
        { 
            if (Connection.SetDataSource())
            {
                if (Connection.dataSource is not null)
                {

                    try
                    {
                        string query_selector = "";

                        query_selector = "select usuarios.id, pessoa.nome, usuarios.login, pessoa.cpf from usuarios " +
                                            " join pessoa on usuarios.fk_pessoa = pessoa.cpf " +
                                            " join entidade on pessoa.fk_entidade = entidade.id " +
                                            " where pessoa.status = '1' " +
                                            " and entidade.id = " + Manage_login.Id_camara;

                        await using var command = Connection.dataSource.CreateCommand(query_selector);
                        await using var reader = await command.ExecuteReaderAsync();

                        List<string[]> rows = new List<string[]>();

                        while (await reader.ReadAsync())
                        {
                            string[] row = { reader["id"].ToString() ?? "",
                                         reader["nome"].ToString() ?? "",
                                         reader["login"].ToString() ?? "",
                                         reader["cpf"].ToString() ?? "" };

                            row[1] = row[1].ToUpper();
                            row[2] = row[2].ToUpper();

                            rows.Add(row);
                        }

                        return rows;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro Banco de Dados: " + e.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                                        
                }
            }
            return null;
        }

        public async Task<string?> GetPermissionsUser(int id_user)
        {
            string acessos_usuario = "";

            if (Connection.SetDataSource())
            {
                if (Connection.dataSource is not null)
                {

                    try
                    {
                        string query_selector = "";

                        query_selector = "select acessos.id id_acessos, menu_itens_suspensos.id id_menu_itens_suspensos, " +
                                            " usuarios.id id_usuarios, menu_nomes.posicao_menu, menu_itens_suspensos.nome nome_menu_itens_suspensos, " +
                                            " acessos.acesso, acessos.alterar, acessos.novo, menu_nomes.nome nome_menu_nomes from acessos " +
                                            " join menu_itens_suspensos on acessos.fk_menu_itens_suspensos = menu_itens_suspensos.id " +
                                            " join usuarios on acessos.fk_usuarios = usuarios.id " +
                                            " join pessoa on pessoa.cpf = usuarios.fk_pessoa " +
                                            " join entidade on entidade.id = pessoa.fk_entidade " +
                                            " join menu_nomes on menu_nomes.posicao_menu = menu_itens_suspensos.fk_menu_nomes " +
                                            " where usuarios.id = " + id_user +
                                            " and entidade.id = " + Manage_login.Id_camara +
                                            " order by menu_nomes.posicao_menu asc";

                        await using var command = Connection.dataSource.CreateCommand(query_selector);
                        await using var reader = await command.ExecuteReaderAsync();
                                                
                        while (await reader.ReadAsync())
                        {
                            acessos_usuario += reader["id_usuarios"].ToString() + "_" +
                                           reader["id_menu_itens_suspensos"].ToString() + "_" +
                                           reader["id_acessos"].ToString() + "_" +
                                           reader["posicao_menu"].ToString() + "_" +
                                           reader["nome_menu_itens_suspensos"].ToString() + "_" +
                                           reader["acesso"].ToString() + "_" +
                                           reader["alterar"].ToString() + "_" +
                                           reader["novo"].ToString() + "_" +
                                           reader["nome_menu_nomes"].ToString() + "\n";                            
                        }
                        return acessos_usuario;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocorreu um erro ao analisar as permissões do usuário. " + e.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return null;
        }

        public async Task<bool?> UpdateAccessUser(string queryText, int iterations)
        {
            try
            {
                if (Connection.SetDataSource())
                {
                    if (Connection.dataSource is not null)
                    {                       
                        await using var conn = await Connection.dataSource.OpenConnectionAsync();
                        await using var cmd = new NpgsqlCommand("CALL updateaccessusers( '" + queryText + "', " + iterations + ")", conn);
                                               
                        await cmd.ExecuteNonQueryAsync();

                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro ao gravar as permissões do usuário. " + e.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }



        //public async Task<string?> UpdateAccessUser()
        //{           
        //    try
        //    {
        //        if (Connection.SetDataSource())
        //        {
        //            if (Connection.dataSource is not null)
        //            {
        //                string query = "update acessos set acesso = @ac, alterar = @al, novo = @no " +
        //                                " where fk_menu_itens_suspensos = @me and fk_usuarios = 2 ";

        //                await using var conn = await Connection.dataSource.OpenConnectionAsync();

        //                await using var cmd = new NpgsqlCommand(query, conn)
        //                {
        //                    Parameters=
        //                    {
        //                        new("ac",'1'),
        //                        new("al",'1'),
        //                        new("no",'1'),
        //                        new("me", 2)
        //                    }      
        //                };
        //                await cmd.ExecuteNonQueryAsync();
        //            }                    
        //        }               
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //    return null;
        //}
    }
}
