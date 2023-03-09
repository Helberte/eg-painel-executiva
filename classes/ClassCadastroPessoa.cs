using eg_painel.classes.connection_bd;
using eg_painel.form_login;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eg_painel.classes
{
    internal class ClassCadastroPessoa
    {
        public async Task<List<string[]>?> GetPessoas()
        {
            if (Connection.SetDataSource())
            {
                if (Connection.dataSource is not null)
                {
                    string query_selector = "";
                    query_selector = "select pe.cpf cpf, pe.nome nome, pe.apelido_exibicao apelido, " +
                                        " pe.data_nascimento data, pe.deficiente_visual from pessoa pe " +
                                        " where fk_entidade = " + Manage_login.Id_camara +
                                        " and status = '1' ";


                    await using var command = Connection.dataSource.CreateCommand(query_selector);
                    await using var reader = await command.ExecuteReaderAsync();

                    List<string[]> rows = new List<string[]>();

                    while (await reader.ReadAsync())
                    {
                        string[] row = { reader["cpf"].ToString() ?? "",
                                         reader["nome"].ToString() ?? "",
                                         reader["apelido"].ToString() ?? "",
                                         reader["data"].ToString() ?? "",
                                         reader["deficiente_visual"].ToString() ?? "" };
                                               
                       
                        row[1] = row[1].ToUpper();
                        row[2] = row[2].ToUpper();
                        row[3] = row[3].Substring(0,10);

                        rows.Add(row);
                    }

                    return rows;
                }
            }
            return null;
        }
    }
}
