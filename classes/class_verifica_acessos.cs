using eg_painel.classes.connection_bd;
using eg_painel.form_login;
using eg_painel.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eg_painel.classes
{
    internal class class_verifica_acessos
    {
        int id_usuario;
        public int Id_Menu { get; set; }  // informa para qual posição se refere a lista suspensa, se para o 1 ou 2 etc
        public int Quantidae_nomes_menu { get; private set; }

        public class_verifica_acessos(int id_usuario)
        {
            this.id_usuario = id_usuario;
        }

        public async Task<string?> RetornaMenusRapidos()
        {
            string menus_rapidos = "";
            string comando = "";

            if (id_usuario == -1) // caso seja o administrador
            {                
                comando = "select men.nome, men.LABEL, nom.NOME CATEGORIA " +
                            " from MENU_ITENS_SUSPENSOS men " +
                            " join MENU_NOMES nom on men.fk_menu_nomes = nom.POSICAO_MENU " +
                            " where men.MENU_RAPIDO = '1' " +
                            " order by men.MENU_RAPIDO_ORDEM asc ";
            }
            else
            {
                comando = "select men.nome, men.LABEL, nomes.NOME CATEGORIA from ACESSOS a " +
                           " join USUARIOS us on a.fk_usuarios = us.id " +
                           " join pessoa p on p.CPF = us.fk_pessoa " +
                           " join MENU_ITENS_SUSPENSOS men on men.id = a.FK_MENU_ITENS_SUSPENSOS " +
                           " join MENU_NOMES nomes on men.fk_menu_nomes = nomes.POSICAO_MENU " +
                           " join entidade ent on ent.id = p.fk_entidade " +
                           " where a.ACESSO = '1' " +
                           " and men.MENU_RAPIDO = '1' " +
                           " and us.id = " + Manage_login.Id_usuario +
                           " and ent.id = " + Manage_login.Id_camara +
                           " order by men.MENU_RAPIDO_ORDEM asc ";
            }

            try
            {
                if (Connection.SetDataSource())
                {
                    if (Connection.dataSource is not null)
                    {

                        await using var command = Connection.dataSource.CreateCommand(comando);
                        await using var reader = await command.ExecuteReaderAsync();

                        //List<string[]> rows = new List<string[]>();

                        while (await reader.ReadAsync())
                        {
                            //string[] row = { reader["cpf"].ToString() ?? "",
                            //             reader["nome"].ToString() ?? "",
                            //             reader["apelido"].ToString() ?? "",
                            //             reader["data"].ToString() ?? "",
                            //             reader["deficiente_visual"].ToString() ?? "" };

                            //row[1] = row[1].ToUpper();
                            //row[2] = row[2].ToUpper();
                            //row[3] = row[3].Substring(0, 10);

                            menus_rapidos += reader["nome"].ToString() + ";" + reader["LABEL"].ToString() + ";" + reader["CATEGORIA"].ToString() + "\n";
                                                        
                        }

                        return menus_rapidos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao analisar os menus existentes. " +
                    "Metodo = RetornaMenusRapidos" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
            return "";
        }

        public async Task<string?> RetornaMenusLateraisEsquerdo()
        {
            string todos_menus = "";
            string comando = "";

            if (id_usuario == -1)
            {               
                comando = "select men.nome MENU, men.label, nomes.LABEL CATEGORIA, nomes.POSICAO_MENU POSICAO, men.numero ORDEM " +
                            " from MENU_ITENS_SUSPENSOS men " +
                            " join MENU_NOMES nomes on men.fk_menu_nomes = nomes.POSICAO_MENU " +
                            " order by nomes.POSICAO_MENU asc, men.numero asc ";
            }
            else
            {                
                comando = "select men.nome MENU, men.label, nomes.LABEL CATEGORIA, nomes.POSICAO_MENU POSICAO, men.numero ORDEM from ACESSOS a " +
                            " join USUARIOS us on a.fk_usuarios = us.id " +
                            " join pessoa p on p.cpf = us.fk_pessoa " +
                            " join MENU_ITENS_SUSPENSOS men on men.id = a.FK_MENU_ITENS_SUSPENSOS " +
                            " join MENU_NOMES nomes on men.fk_menu_nomes = nomes.POSICAO_MENU " +
                            " join entidade ent on ent.id = p.fk_entidade " +
                            " where a.ACESSO = '1' " +
                            " and us.id = " + Manage_login.Id_usuario +
                            " and ent.id = " + Manage_login.Id_camara +
                            " order by nomes.POSICAO_MENU asc, men.numero asc ";
            }

            try
            {
                if (Connection.SetDataSource())
                {
                    if (Connection.dataSource is not null)
                    {

                        await using var command = Connection.dataSource.CreateCommand(comando);
                        await using var reader = await command.ExecuteReaderAsync();

                        //List<string[]> rows = new List<string[]>();

                        while (await reader.ReadAsync())
                        {
                            //string[] row = { reader["cpf"].ToString() ?? "",
                            //             reader["nome"].ToString() ?? "",
                            //             reader["apelido"].ToString() ?? "",
                            //             reader["data"].ToString() ?? "",
                            //             reader["deficiente_visual"].ToString() ?? "" };

                            //row[1] = row[1].ToUpper();
                            //row[2] = row[2].ToUpper();
                            //row[3] = row[3].Substring(0, 10);

                            todos_menus += reader["MENU"].ToString() + ";" + reader["LABEL"].ToString() + ";" + reader["CATEGORIA"].ToString() + ";" + reader["POSICAO"].ToString() + ";" + reader["ORDEM"].ToString() + "\n";

                        }

                        return todos_menus;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao analisar os menus existentes da lateral esquerda. " +
                    "Metodo = RetornaMenusLateraisEsquerdo" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
            return "";
        }
    }
}
