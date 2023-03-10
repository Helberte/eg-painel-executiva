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
using eg_painel.classes.system_settings;
using FontAwesome.Sharp;

namespace eg_painel.forms
{
    public partial class FormAccess : Form
    {
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
       
        private void FormAccess_Load(object sender, EventArgs e)
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
    }
}
