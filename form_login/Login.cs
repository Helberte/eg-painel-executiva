using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eg_painel.classes.system_settings;
using eg_painel.form_login;

namespace eg_painel.form_login
{
    public partial class Form_login_inicial : Form
    {
        readonly string  texto_padrao_ed_usuario = "Usuário";
        readonly string texto_padrao_ed_senha = "Senha";
        FontFamily? montserrat;

        string[] caracterInvalid = new string[] { "'", "!",  "#", "$", "%", 
            "&", "*", "(", ")", "-", "\\", "\n", ";", ",", "´", "`", "/", 
            "+", "=", "ç","^","~","]","[", "{", "}","?", "|","\"",":","°","º", "<",">","ª","§","æ","Æ"," ","¨" };

        
        public Form_login_inicial()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ed_usuario.Text = texto_padrao_ed_usuario;
            ed_senha.Text = texto_padrao_ed_senha;

            montserrat = Settings.GetFontMontserrat();
            
            EstilizaTelaLogin();
            ArredondaCantos(panel_center);

            lbl_esqueceu_senha.MouseLeave += Lbl_esqueceu_senha_MouseLeave; 
            lbl_esqueceu_senha.MouseMove += Lbl_esqueceu_senha_MouseMove; 

            this.Opacity = 1;
            this.Focus();
        }

        private void Lbl_esqueceu_senha_MouseMove(object? sender, MouseEventArgs e)
        {
            if(sender is Label label) {
                if (label != null)
                    label.ForeColor = System.Drawing.Color.FromArgb(9, 28, 38);
            }            
        }

        private void Lbl_esqueceu_senha_MouseLeave(object? sender, EventArgs e)
        {
            Label? label = sender as Label;

            if (label != null)            
                label.ForeColor = System.Drawing.Color.FromArgb(24, 81, 117);                        
        }

        void EstilizaTelaLogin()
        {
            panel_center.Size = new Size(400, 500);
            panel_center.Location = new Point((this.Width / 2) - (panel_center.Width / 2), (this.Height / 2) - (panel_center.Height / 2) - 20);
            panel_center.Anchor = AnchorStyles.None;

            this.MinimumSize = new Size(480, 600);

            ed_senha.ForeColor = Color.FromArgb(160, 156, 153);

            iconPictureBox_logo.Size = new Size(239, 70);
            iconPictureBox_logo.Location = new Point((panel_center.Width / 2) - (iconPictureBox_logo.Width / 2), 60);

            ed_usuario.Width = 287;
            ed_senha.Width = 287;
            ed_usuario.BorderStyle = BorderStyle.Fixed3D;
            ed_usuario.Location = new Point((panel_center.Width / 2) - (ed_usuario.Width / 2), iconPictureBox_logo.Location.Y + iconPictureBox_logo.Height + 50);
            ed_senha.Location = new Point((panel_center.Width / 2) - (ed_senha.Width / 2), ed_usuario.Location.Y + ed_usuario.Height + 15);
            ed_senha.BorderStyle = BorderStyle.Fixed3D;

            lbl_usuario.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl_usuario.Location = new Point(ed_usuario.Left - 4, ed_usuario.Location.Y - lbl_usuario.Height - 3);
            lbl_usuario.ForeColor = System.Drawing.Color.FromArgb(24, 81, 117);

            pictureBox_bt_acessar.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            pictureBox_bt_acessar.Size = new Size(140, 39);
            pictureBox_bt_acessar.Location = new Point(ed_senha.Left, ed_senha.Location.Y + ed_senha.Height + 50);

            checkBox_lembrar.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            checkBox_lembrar.ForeColor = System.Drawing.Color.FromArgb(24, 81, 117);
            checkBox_lembrar.Location = new Point((ed_senha.Left + ed_senha.Width) - checkBox_lembrar.Width + 5, pictureBox_bt_acessar.Location.Y + 7);

            lbl_esqueceu_senha.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl_esqueceu_senha.ForeColor = System.Drawing.Color.FromArgb(24, 81, 117);
            lbl_esqueceu_senha.Location = new Point((panel_center.Width / 2) - (lbl_esqueceu_senha.Width / 2), pictureBox_bt_acessar.Top + pictureBox_bt_acessar.Height + 40);
        }

        static void ArredondaCantos(Control control)
        {
            using (GraphicsPath forma = new())
            {
                forma.AddRectangle(new Rectangle(1, 1, control.Width, control.Height));
                forma.AddRectangle(new Rectangle(1, 1, 10, 10));
                forma.AddPie(1, 1, 20, 20, 180, 90);
                forma.AddRectangle(new Rectangle(control.Width - 12, 1, 12, 13));
                forma.AddPie(control.Width - 24, 1, 24, 26, 270, 90);
                forma.AddRectangle(new Rectangle(1, control.Height - 10, 10, 10));
                forma.AddPie(1, control.Height - 20, 20, 20, 90, 90);
                forma.AddRectangle(new Rectangle(control.Width - 12, control.Height - 13, 13, 13));
                forma.AddPie(control.Width - 24, control.Height - 26, 24, 26, 0, 90);
                forma.SetMarkers();

                control.Region = new Region(forma);
            }

            //https://pt.stackoverflow.com/questions/528084/%C3%89-poss%C3%ADvel-fazer-bordas-arredondadas-no-combobox-do-windows-forms-c
        }

        private void ed_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ed_usuario.ForeColor = Color.Black;

            foreach (var item in caracterInvalid)
            {
                if (e.KeyChar == Convert.ToChar(item))
                {
                    e.Handled = true;
                    break;
                }
            }
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ed_senha.Focus();
            }
            else
            if (string.IsNullOrWhiteSpace(Convert.ToString(e.KeyChar)))
            {
                e.Handled = true;
            }           
        }

        private void ed_usuario_Enter(object sender, EventArgs e)
        {
            if (ed_usuario.Text == texto_padrao_ed_usuario)
            {
                ed_usuario.Clear();
                ed_usuario.ForeColor = Color.Black;
            }
        }

        private void ed_usuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ed_usuario.Text))
            {
                ed_usuario.Text = texto_padrao_ed_usuario;
                ed_usuario.ForeColor = Color.FromArgb(160, 156, 153);
            }
        }

        //private void ed_senha_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar))
        //    {
        //        if (e.KeyChar != (char)Keys.Back)
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //}

        private void ed_senha_Enter(object sender, EventArgs e)
        {
            if (ed_senha.Text == texto_padrao_ed_senha)
            {
                ed_senha.Clear();
                ed_senha.PasswordChar = '*';
                ed_senha.ForeColor = Color.Black;
            }
        }

        private void ed_senha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ed_senha.Text))
            {
                ed_senha.ForeColor = Color.FromArgb(160, 156, 153);
                ed_senha.PasswordChar = '\u0000';
                ed_senha.Text = texto_padrao_ed_senha;
            }
        }

        private async void pictureBox_bt_acessar_Click(object sender, EventArgs e)
        {
            List<string> campos_empty = new List<string>();
         
            foreach (Control item in panel_center.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = item.Text.Replace(texto_padrao_ed_usuario, "");
                    item.Text = item.Text.Replace(texto_padrao_ed_senha, "");

                    if (String.IsNullOrEmpty(item.Text.ToString()))                                         
                        campos_empty.Add(Convert.ToString(item.Tag));    
                }
            }
            if (campos_empty.Count > 0)
            {
                string fields = "";

                foreach (var item in campos_empty)
                {
                    fields += item + ", ";
                }

                if (campos_empty.Count == 1)                
                    MessageBox.Show("O campo [" + fields.Remove(fields.Length - 2) + "] não pode ficar vazio.", "Existe um campo vazio!", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                else                    
                    MessageBox.Show("Os campos [" + fields.Remove(fields.Length - 2) + "] não podem ficar vazios.", "Existem campos vazios!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ed_usuario.Focus();
                ed_senha.Text = texto_padrao_ed_senha;
                ed_senha.ForeColor = Color.FromArgb(160, 156, 153);
            }
            else
            {
                panel_center.Cursor = Cursors.AppStarting;

                Manage_login login = new Manage_login(ed_usuario.Text, ed_senha.Text);
                int validate = await login.ValidateUser();

                panel_center.Cursor = Cursors.Default;

                if (validate == 1)
                    this.Close();
            }                  
        }

        
        private void ed_senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ed_senha.ForeColor = Color.Black;
        }

        private void ed_usuario_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                foreach (var item in caracterInvalid)
                {
                    textBox.Text = textBox.Text.Replace(item, "");
                }
            }
        }
    }
}
