using eg_painel.form_login;


namespace eg_painel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_login_inicial login = new Form_login_inicial();
            login.ShowDialog();
        }
    }
}