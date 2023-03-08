using eg_painel.form_login;
using eg_painel.forms;


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

        private void button2_Click(object sender, EventArgs e)
        {
            using (Entidade entidade = new Entidade())
            {
                entidade.ShowDialog();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (CadastroPessoas cadPessoas = new())
            {
                cadPessoas.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Legislaturas legislaturas = new())
            {
                legislaturas.ShowDialog();
            }
        }
    }
}