using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using eg_painel.classes;
using eg_painel.classes.system_settings;
using FontAwesome.Sharp;

namespace eg_painel.forms
{
    public partial class FormAccess : Form
    {
        //ClassFormCheckAccesses? class_acessos;
        //DataGridViewImageColumn? coluna_imagem_usuarios;
        DataGridViewImageColumn? coluna_imagem_acessos;

        //bool mostrou_form_primeira_vez = false;
        //string acessos = "";
        //int linhas_alteradas = 0;

        int loadStyleGridAccess = 0;

        public FormAccess()
        {
            InitializeComponent();

            Settings.SetSettingsForm(this);
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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
       
        private async void FormAccess_Load(object sender, EventArgs e)
        {
            SettingsDefaultForm();
            ClassFormCheckAccesses classAccess = new ClassFormCheckAccesses();

            dataGrid_acessos.ColumnCount = 4;

            dataGrid_acessos.Columns[0].Name = "id_acessos";
            dataGrid_acessos.Columns[1].Name = "fk_menu_itens_suspensos";
            dataGrid_acessos.Columns[2].Name = "fk_id_pessoa";

            dataGrid_acessos.Columns[0].Visible = false;
            dataGrid_acessos.Columns[1].Visible = false;
            dataGrid_acessos.Columns[2].Visible = false;

            dataGrid_acessos.Columns[3].Name = "ROTINA";
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "ACESSO", Visible = true });
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "ALTERAR", Visible = true });
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "NOVO", Visible = true });
            

            // grid usuários

            dataGrid_usuarios.ColumnCount = 4;
            dataGrid_usuarios.Columns[0].Name = "ID";
            dataGrid_usuarios.Columns[1].Name = "NOME";
            dataGrid_usuarios.Columns[2].Name = "LOGIN";
            dataGrid_usuarios.Columns[3].Name = "CPF";

            List<string[]>? strings = new List<string[]>();

            strings = await classAccess.GetUsers();

            if (strings is not null)
            {
                foreach (string[] item in strings)
                {
                    dataGrid_usuarios.Rows.Add(item);
                }
            }

            Settings.AddColumnPlay(dataGrid_usuarios);
            Settings.StylesDataGridView(dataGrid_usuarios);
            Ajusta_largura_colunas_usuarios();

            // grid acessos

            PreencheGrid_acessos(classAccess);
            Ajusta_largura_colunas_acessos();
            loadStyleGridAccess = 0;
        }
        void Ajusta_largura_colunas_acessos()
        {
            //int largura = (dataGrid_acessos.Width - 45) / 4;

            dataGrid_acessos.Columns["ROTINA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid_acessos.Columns["ACESSO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid_acessos.Columns["ALTERAR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid_acessos.Columns["NOVO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        async void PreencheGrid_acessos(ClassFormCheckAccesses class_acessos)
        {
            //https://social.msdn.microsoft.com/Forums/pt-BR/ecfd6c9c-f4bb-458d-9a7c-0048809fe783/adicionar-registro-no-banco-pelo-datagridview-marcado-com-chekbox?forum=vscsharppt

            string? accessBD = await class_acessos.GetPermissionsUser(Convert.ToInt32(dataGrid_usuarios.CurrentRow.Cells["ID"].Value.ToString()));
            string[]? acessos_usuario = (accessBD is not null) ? accessBD.Split('\n') : null;

            //if (accessBD is not null)            
            //    acessos_usuario = accessBD.Split('\n');

             
            string[] itens;

            //id_usuario                0
            //id_menu_itens_suspensos   1
            //id_acessos                2
            //posicao_menu              3
            //nome_item                 4
            //acesso                    5
            //alterar                   6
            //novo                      7
            //nome_menu                 8
            bool acesso, alterar, novo, existe_a_coluna;

            int id_usuario;
            int id_menu_itens_suspensos;
            int id_acessos;


            existe_a_coluna = false;
            string nome_coluna_imagem = dataGrid_acessos.Columns[0].Name;
            if (coluna_imagem_acessos is not null)
            {
                if (nome_coluna_imagem == coluna_imagem_acessos.Name)
                {
                    existe_a_coluna = true;
                }
            }

            if (acessos_usuario is not null)
            {
                for (int i = 0; i < acessos_usuario.Length - 1; i++)
                {
                    itens = acessos_usuario[i].Split('_');

                    id_usuario = Convert.ToInt32(itens[0]);
                    id_menu_itens_suspensos = Convert.ToInt32(itens[1]);
                    id_acessos = Convert.ToInt32(itens[2]);
                    acesso = Convert.ToInt32(itens[5]) == 1 ? true : false;
                    alterar = Convert.ToInt32(itens[6]) == 1 ? true : false;
                    novo = Convert.ToInt32(itens[7]) == 1 ? true : false;

                    // coluna 0 = "id_acessos";
                    // coluna 1 = "fk_menu_itens_suspensos";
                    // coluna 2 = "fk_id_pessoa";

                    if (existe_a_coluna)
                        dataGrid_acessos.Rows.Add(System.Drawing.Image.FromFile("seta_colunas_grid_3.jpg"),
                                                                    id_acessos,
                                                                    id_menu_itens_suspensos,
                                                                    id_usuario,
                                                                    itens[4],
                                                                    acesso,
                                                                    alterar,
                                                                    novo);
                    else
                        dataGrid_acessos.Rows.Add(id_acessos, id_menu_itens_suspensos, id_usuario, itens[4], acesso, alterar, novo);
                }
                Settings.AddColumnPlay(dataGrid_acessos);
            }
        }
        void Ajusta_largura_colunas_usuarios()
        {
            // largura das colunas
            dataGrid_usuarios.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid_usuarios.Columns["NOME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid_usuarios.Columns["LOGIN"].Width = 250;
            dataGrid_usuarios.Columns["CPF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void SettingsDefaultForm()
        {
            IconPictureBox iconLogo = new IconPictureBox();
            System.Windows.Forms.Label titleText = new System.Windows.Forms.Label();

            Settings.SetSettingsHeader(this.panel1, iconLogo, IconChar.CheckDouble, titleText, "Acessos");
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

            System.Windows.Forms.Button? btnEdit = Settings.GetButtonDefault(this, "Editar");
            System.Windows.Forms.Button? btnSave = Settings.GetButtonDefault(this, "Salvar");
            Settings.positionButtonX = 0;
            Settings.accumulatePositionButton = 0;
           
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

        private void BtnMinimize_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (loadStyleGridAccess == 0)
                {
                    Settings.StylesDataGridView(dataGrid_acessos);
                    dataGrid_acessos.ReadOnly = false;
                    dataGrid_acessos.Columns["ROTINA"].ReadOnly = true;
                    loadStyleGridAccess = 1;
                }
                
            }
        }
    }
}
