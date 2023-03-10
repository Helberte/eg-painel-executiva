using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(Settings.GetFontMontserrat(), 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 89, 83);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 226, 226);
            // ajusta altura da linha do cabeçalho
            dataGridView.ColumnHeadersHeight = 43;

            dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(112, 140, 237);

            // mudar de cor quando seleciona a linha / texto
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(222, 232, 248);
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 88, 255);

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
                Image = System.Drawing.Image.FromFile("seta_columns.png"),
                Width = 45
            };
            dataGridView.Columns.Insert(0, columnPlay);
        }

        public static void SetSettingsForm(Form form)
        {
            form.Text = string.Empty;
            form.ControlBox = false;
            form.WindowState = FormWindowState.Normal;

            form.BackColor = System.Drawing.Color.FromArgb(249, 245, 242);
            form.Font = new Font(Settings.GetFontMontserrat() ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);

            System.Drawing.Icon icon = new System.Drawing.Icon(@"imagens\logoEGP.ico");
            form.Icon = icon;

            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowInTaskbar = true;

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "";
            form.WindowState = FormWindowState.Normal;
        }

        public static void SetSettingsHeader(System.Windows.Forms.Panel panel,
                                IconPictureBox iconPictureBox,
                                IconChar iconChar,
                                System.Windows.Forms.Label titleText,
                                string caption)
        {
            panel.Dock = DockStyle.Top;
            panel.Height = 69;
            panel.BackColor = System.Drawing.Color.FromArgb(236, 233, 230);
            panel.BorderStyle = BorderStyle.None;

            iconPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            iconPictureBox.BackColor = System.Drawing.Color.FromArgb(236, 233, 230);
            iconPictureBox.IconChar = iconChar;
            iconPictureBox.IconColor = System.Drawing.Color.Black;
            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox.Size = new Size(34, 32);

            panel.Controls.Add(iconPictureBox);

            iconPictureBox.Location = new Point(31, (panel.Height / 2) - (iconPictureBox.Height / 2));

            titleText.Text = caption;
            titleText.Font = new Font(Settings.GetFontMontserrat() ?? FontFamily.GenericSansSerif, 13, FontStyle.Regular);
            titleText.BackColor = System.Drawing.Color.Transparent;
            titleText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            panel.Controls.Add(titleText);

            titleText.Location = new Point(iconPictureBox.Location.X + iconPictureBox.Width + 3, (panel.Height / 2) - (titleText.Height / 2) - 2);                        
        }

        public static IconPictureBox GetIconPictureBoxBtnContolsForm(IconChar iconChar)
        {            
            IconPictureBox btn = new IconPictureBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = System.Drawing.Color.Transparent,
                IconChar = iconChar,
                IconColor = System.Drawing.Color.Black,
                IconFont = IconFont.Auto,
                Size = new Size(30, 30),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            return btn;
        }
    }
}
