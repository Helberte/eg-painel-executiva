using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using eg_painel.classes;
using eg_painel.classes.system_settings;
using FontAwesome.Sharp;

namespace eg_painel.forms
{
    public partial class CadastroPessoas : Form
    {
        public CadastroPessoas()
        {
            InitializeComponent();

            Settings.SetSettingsForm(this);
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;            
        }

        private void CadastroPessoas_Load(object sender, EventArgs e)
        {
            SettingsDefaultForm();
            GridPopulate();

        }
        private async void GridPopulate()
        {
            ClassCadastroPessoa cad = new();

            List<string[]>? array_rows = new List<string[]>();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "CPF";
            dataGridView1.Columns[1].Name = "NOME";
            dataGridView1.Columns[2].Name = "APELIDO";
            dataGridView1.Columns[3].Name = "DATA NASCIMENTO";
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "DEFICIENTE VISUAL", Visible = true });
            dataGridView1.Columns[4].ReadOnly = true;
            array_rows = await cad.GetPessoas();

            if (array_rows is not null)
            {
                foreach (var item in array_rows)
                {
                    dataGridView1.Rows.Add(item[0], item[1], item[2], item[3], item[4] == "1" ? true : false);
                }
            }

            Settings.AddColumnPlay(dataGridView1);
            Settings.StylesDataGridView(dataGridView1);
            Ajusta_largura_colunas_usuarios(dataGridView1);
        }
        void SettingsDefaultForm()
        {
            IconPictureBox iconLogo = new IconPictureBox();
            System.Windows.Forms.Label titleText = new System.Windows.Forms.Label();

            Settings.SetSettingsHeader(this.panel1, iconLogo, IconChar.User, titleText, "Cadastro de Pessoas");
            IconPictureBox btnClose = Settings.GetIconPictureBoxBtnContolsForm(IconChar.WindowClose);
            IconPictureBox btnMaximize = Settings.GetIconPictureBoxBtnContolsForm(IconChar.WindowMaximize);
            IconPictureBox btnMinimize = Settings.GetIconPictureBoxBtnContolsForm(IconChar.SquareMinus);

            panel1.Controls.Add(btnClose);
            btnClose.Location = new Point(panel1.Width - btnClose.Width - 31, (panel1.Height / 2) - (btnClose.Height / 2));
            panel1.Controls.Add(btnMaximize);
            btnMaximize.Location = new Point(btnClose.Location.X - btnClose.Width - 10, (panel1.Height / 2) - (btnMaximize.Height / 2));
            panel1.Controls.Add(btnMinimize);
            btnMinimize.Location = new Point(btnMaximize.Location.X - btnMaximize.Width - 10, (panel1.Height / 2) - (btnMinimize.Height / 2));

            btnClose.Click += BtnClose_Click;
            btnMaximize.Click += BtnMaximize_Click;
            btnMinimize.Click += BtnMinimize_Click; 

            iconLogo.MouseDown += panel1_MouseDown;
            titleText.MouseDown += panel1_MouseDown; 

            System.Windows.Forms.Button? btnNew = Settings.GetButtonDefault(this, "Novo");
            System.Windows.Forms.Button? btnEdit = Settings.GetButtonDefault(this, "Editar");
            System.Windows.Forms.Button? btnSave = Settings.GetButtonDefault(this, "Salvar");
            Settings.positionButtonX = 0;
            Settings.accumulatePositionButton = 0;

            if (btnNew is not null)
            {
                btnNew.Click += BtnNew_Click;
                btnNew.MouseEnter += BtnNew_MouseEnter;
                btnNew.MouseLeave += BtnNew_MouseLeave;
            }
            if (btnEdit is not null)
            {
                btnEdit.Click += BtnEdit_Click;
                btnEdit.MouseEnter += BtnNew_MouseEnter;
                btnEdit.MouseLeave += BtnNew_MouseLeave;
            }
            if (btnSave is not null)
            {
                btnSave.Click += BtnSave_Click;
                btnSave.MouseEnter += BtnNew_MouseEnter;
                btnSave.MouseLeave += BtnNew_MouseLeave;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNew_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackgroundImage = System.Drawing.Image.FromFile("button_default.png");
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void BtnNew_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button button)
            {
                button.BackgroundImage = System.Drawing.Image.FromFile("button_default_hover.png");
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnMaximize_Click(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnMinimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        void Ajusta_largura_colunas_usuarios(DataGridView dataGrid)
        {
            // largura das colunas
            dataGrid.Columns["CPF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["NOME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["APELIDO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["DATA NASCIMENTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["DEFICIENTE VISUAL"].Width = 100;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object? sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }       
    }
}
