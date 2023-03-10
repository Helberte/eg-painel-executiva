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

namespace eg_painel.forms
{
    public partial class Entidade : Form
    {
        public Entidade()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }       

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void Entidade_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
    }
}
