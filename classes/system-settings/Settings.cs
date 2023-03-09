using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eg_painel.classes.system_settings
{
   
    internal class Settings
    {
        private FontFamily montserrat;
        static Settings? config;
    

        private Settings()
        {
            montserrat = new FontFamily("Montserrat");
        }
        public static FontFamily GetFontMontserrat()
        {
            if (config is null)
            {
                config = new Settings();
                return config.montserrat;
            }
            return config.montserrat;
        }

        public static void StylesDataGridView(DataGridView dataGridView)
        {
            // permite que altere a altura do cabeçalho
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ESTA PROPRIEDADE PERMITE ALTERAR OS ESTILOS PARA O CABEÇALHO
            dataGridView.EnableHeadersVisualStyles = false;

            // pripriedades para o cabeçalho
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(48, 75, 109);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(Settings.GetFontMontserrat(), 10, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(251, 250, 246);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            // ajusta altura da linha do cabeçalho
            dataGridView.ColumnHeadersHeight = 43;

            dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(112, 140, 237);

            // mudar de cor quando seleciona a linha / texto
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 150, 65);
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(255, 255, 254);

            // Coloca a cor de fundo nas linhas
            dataGridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 254);
            dataGridView.RowsDefaultCellStyle.Font = new Font(Settings.GetFontMontserrat(), 12, FontStyle.Regular);
            dataGridView.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(110, 102, 100);

            // configurações para todas as células

            // alinha o conteudo dentro da célula
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // deixa que eu escolha a autura de cada linha, ao invés de ficar por padrão
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // indica que o usuário não vai poder editar linhas
            dataGridView.ReadOnly = true;

            //controles do grid completo
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 254);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // estilo da borda do cabeçalho
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersVisible = true;

            // quando clicar, seleciona a linha inteira
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // o usuário não poderá selecionar muitas linhas
            dataGridView.MultiSelect = false;

            // retira a primeira coluna 
            dataGridView.RowHeadersVisible = false;

            // retira a ultima linha adicionada automaticamente, é utilizada para adicionar novas linhas
            dataGridView.AllowUserToAddRows = false;

            // não deixa o usuário deletar as linhas do grid
            dataGridView.AllowUserToDeleteRows = false;

            SetHeightRowsDataGridView(dataGridView);
        }
        private static void SetHeightRowsDataGridView(DataGridView dataGrid)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
                dataGrid.Rows[i].Height = 35;
        }

        public static void AddColumnPlay(DataGridView dataGridView)
        {
            DataGridViewImageColumn columnPlay = new DataGridViewImageColumn()
            {
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.NotSet,
                Image = Image.FromFile("seta_columns.png"),
                Width = 45
            };
            dataGridView.Columns.Insert(0, columnPlay);
        }
    }
}
