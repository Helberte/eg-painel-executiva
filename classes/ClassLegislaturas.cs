using eg_painel.classes.connection_bd;
using eg_painel.form_login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eg_painel.classes
{
    internal class ClassLegislaturas
    {
        public async Task<List<string[]>?> GetLegislaturas()
        {
            if (Connection.SetDataSource())
            {
                if (Connection.dataSource is not null)
                {
                    string query_selector = "";
                    query_selector = "select le.data_inicial, le.data_final, le.numero_cadeiras, le.quorum_abertura from legislatura le " +
                                        " join entidade ent on le.fk_entidade = ent.id " +
                                        " where ent.id = " + Manage_login.Id_camara;


                    await using var command = Connection.dataSource.CreateCommand(query_selector);
                    await using var reader = await command.ExecuteReaderAsync();

                    List<string[]> rows = new List<string[]>();

                    while (await reader.ReadAsync())
                    {
                        string[] row = { reader["data_inicial"].ToString() ?? "",
                                         reader["data_final"].ToString() ?? "",
                                         reader["numero_cadeiras"].ToString() ?? "",
                                         reader["quorum_abertura"].ToString() ?? "" };


                        row[0] = row[0].Substring(0, 10);
                        row[1] = row[1].Substring(0, 10);

                        rows.Add(row);
                    }

                    return rows;
                }
            }
            return null;
        }
    }
}
