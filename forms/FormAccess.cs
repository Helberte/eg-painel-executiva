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
        DataGridViewImageColumn? coluna_imagem_acessos;

        int loadStyleGridAccess = 0;
        ClassFormCheckAccesses? classAccess;

      
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
            classAccess = new ClassFormCheckAccesses();
            SettingsDefaultForm();
            lbl_usuario.Visible = false;
            lbl_nome_usuario.Visible = false;

            dataGrid_acessos.ColumnCount = 4;

            dataGrid_acessos.Columns.Insert(0, GetColumnPlay());
            dataGrid_acessos.Columns[1].Name = "id_acessos";
            dataGrid_acessos.Columns[2].Name = "fk_menu_itens_suspensos";
            dataGrid_acessos.Columns[3].Name = "fk_id_pessoa";

            dataGrid_acessos.Columns[1].Visible = false;
            dataGrid_acessos.Columns[2].Visible = false;
            dataGrid_acessos.Columns[3].Visible = false;

            dataGrid_acessos.Columns[4].Name = "ROTINA";
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "ACESSO", Visible = true });
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "ALTERAR", Visible = true });
            dataGrid_acessos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "NOVO", Visible = true });
           
            // grid usuários           
            dataGrid_usuarios.ColumnCount = 4;
           
            dataGrid_usuarios.Columns.Insert(0, GetColumnPlay());
            dataGrid_usuarios.Columns[1].Name = "ID";
            dataGrid_usuarios.Columns[2].Name = "NOME";
            dataGrid_usuarios.Columns[3].Name = "LOGIN";
            dataGrid_usuarios.Columns[4].Name = "CPF";
            List<string[]>? strings = new List<string[]>();

            strings = await classAccess.GetUsers();

            if (strings is not null)
            {
                foreach (string[] item in strings)
                {
                    dataGrid_usuarios.Rows.Add(System.Drawing.Image.FromFile("seta_columns.png"), item[0], item[1], item[2], item[3]);
                }
            }

            Settings.StylesDataGridView(dataGrid_usuarios);
            Ajusta_largura_colunas_usuarios();
                        
            loadStyleGridAccess = 0;
        }
        private DataGridViewImageColumn GetColumnPlay()
        {
            DataGridViewImageColumn columnPlay = new DataGridViewImageColumn()
            {
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.NotSet,
                Width = 45,
                Name = "play"
            };
            return columnPlay;
        }
        void Ajusta_largura_colunas_acessos()
        {            
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
                    
                    dataGrid_acessos.Rows.Add(System.Drawing.Image.FromFile("seta_columns.png"), id_acessos, id_menu_itens_suspensos, id_usuario, itens[4], acesso, alterar, novo);
                }
            }
        }
        void Ajusta_largura_colunas_usuarios()
        {
            dataGrid_usuarios.Columns["play"].Width = 45;
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

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            string acessos = "";
            int linhas_alteradas = 0;

            for (int i = 0; i < dataGrid_acessos.Rows.Count; i++)
            {
                int id_acessos = Convert.ToInt32(dataGrid_acessos["id_acessos", i].Value);
                int fk_menu_itens_suspensos = Convert.ToInt32(dataGrid_acessos["fk_menu_itens_suspensos", i].Value);
                int fk_id_pessoa = Convert.ToInt32(dataGrid_acessos["fk_id_pessoa", i].Value);
                int acesso = Convert.ToBoolean(dataGrid_acessos["Acesso", i].Value) ? 1 : 0;
                int alterar = Convert.ToBoolean(dataGrid_acessos["Alterar", i].Value) ? 1 : 0;
                int novo = Convert.ToBoolean(dataGrid_acessos["Novo", i].Value) ? 1 : 0;

                acessos += "id_acessos=" + id_acessos +
                           ";fk_menu_itens_suspensos=" + fk_menu_itens_suspensos +
                           ";id_usuario=" + fk_id_pessoa +
                           ";acesso=" + acesso +
                           ";alterar=" + alterar +
                           ";novo=" + novo + ";|";

                linhas_alteradas++;
                // Modelo da string
                // id_acessos=12;fk_menu_itens_suspensos=0;id_usuario=1;acesso=1;alterar=1;novo=1;\n
            }

            bool? ret = false;
            if (classAccess is not null)            
                ret = await classAccess.UpdateAccessUser(acessos, linhas_alteradas);                       

            if (ret == true)
               tabControl.SelectedTab = tabPage_usuarios;           
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            dataGrid_acessos.ReadOnly = false;
            dataGrid_acessos.Columns["ROTINA"].ReadOnly = true;
            dataGrid_acessos.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 254);
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
                if (dataGrid_usuarios.CurrentRow is not null)
                {
                    // grid acessos
                    if (classAccess is not null)
                    {
                        dataGrid_acessos.Rows.Clear();
                        PreencheGrid_acessos(classAccess);
                        Ajusta_largura_colunas_acessos();
                    }

                    lbl_usuario.Visible = true;
                    lbl_nome_usuario.Visible = true;
                    lbl_nome_usuario.Text = dataGrid_usuarios.CurrentRow.Cells["nome"].Value.ToString();
                }

                if (loadStyleGridAccess == 0) // para que os styles sejam definidos apenas uma vez
                {
                    Settings.StylesDataGridView(dataGrid_acessos);                   
                    loadStyleGridAccess = 1;
                    dataGrid_acessos.RowsDefaultCellStyle.BackColor = System.Drawing.Color.Red;

                }
            }
            else if (tabControl.SelectedIndex == 0)
            {
                lbl_usuario.Visible = false;
                lbl_nome_usuario.Visible = false;
            }
        }

        private void dataGrid_acessos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (sender is DataGridView grid)            
                grid.Rows[e.RowIndex].Height = 35; 
        }
       
    }
}
