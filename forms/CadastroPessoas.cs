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

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }

        private async void CadastroPessoas_Load(object sender, EventArgs e)
        {
            ClassCadastroPessoa cad = new();

            List<string[]>? array_rows = new List<string[]>();

            dataGridView1.ColumnCount = 4;           
            dataGridView1.Columns[0].Name = "CPF";
            dataGridView1.Columns[1].Name = "NOME";
            dataGridView1.Columns[2].Name = "APELIDO";
            dataGridView1.Columns[3].Name = "DATA NASCIMENTO";
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "DEFICIENTE VISUAL", Visible = true });
            dataGridView1.Columns[4].ReadOnly= true;
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            
        }

        private void CadastroPessoas_Resize(object sender, EventArgs e)
        {            
            //if (panel_name.Width == panel_name.MaximumSize.Width)
            //{
            //    panel_cpf.Location = new Point(panel_name.Left + panel_name.Width + 5, panel_cpf.Top);
            //    panel_cpf.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            //    lbl_cpf.Location = new Point(panel_cpf.Location.X, lbl_cpf.Top);
            //    lbl_cpf.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //}
            //else
            //{
            //    panel_cpf.Location = new Point(panel_name.Left + panel_name.Width + 5, panel_cpf.Top);
            //    panel_cpf.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            //    lbl_cpf.Location = new Point(panel_cpf.Location.X, lbl_cpf.Top);
            //    lbl_cpf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            //}            
        }
    }
}
