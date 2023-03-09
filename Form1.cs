using eg_painel.form_login;
using eg_painel.forms;
using eg_painel.classes;
using FontAwesome.Sharp;
using MZControls;
using eg_painel.classes.system_settings;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace eg_painel
{
    public partial class Form_principal : Form
    {
        // font
        System.Drawing.FontFamily? montserrat;
        // https://cbsa.com.br/post/c---utilizar-fontes-ttf-sem-instalar---privatefontcollection.aspx


        IconPictureBox? mostra_menu_lateral;
        PictureBox? opc_menu_rapido;
        Panel? border_left_button;

        class_verifica_acessos? acessos;
        List<IconButton> lista_botoes_menu_lateral_esquerdo = new List<IconButton>();
        List<Label> lista_labels_opcoes_menu_lateral_esquerdo = new List<Label>();

        DateTime? data;

        Label? lbl_painel_operador;
        Label? lbl_cab_hora;

        IconPictureBox? btn_close_form;
        IconPictureBox? btn_minimize_form;
        IconPictureBox? btn_maximize_form;
        IconButton? botao_lat_esquerda;
        IconButton? botao_ativo_esquerda;
        IconPictureBox? seta_baixo;
        IconButton? botao;

        string[]? array_menus;
        string? todos_menus = "";

        public Form_principal()
        {
            this.Opacity = 0;

            InitializeComponent();

            montserrat = Settings.GetFontMontserrat();

            panel_cab_1.MouseDown += Mover_tela_cabecalho_MouseDown;

            border_left_button = new Panel();
            seta_baixo = new IconPictureBox();

            border_left_button.Size = new Size(5, 55);
            border_left_button.BackColor = System.Drawing.Color.FromArgb(0, 88, 255);

            seta_baixo.Size = new Size(20, 20);
            seta_baixo.IconChar = IconChar.ChevronDown;
            seta_baixo.SizeMode = PictureBoxSizeMode.CenterImage;
            seta_baixo.IconColor = System.Drawing.Color.FromArgb(0, 88, 255);
            seta_baixo.IconSize = 22;
            seta_baixo.BackColor = System.Drawing.Color.FromArgb(222, 232, 248);

            mzSombraPanel_lateral_esquerda.Controls.Add(border_left_button);
            mzSombraPanel_lateral_esquerda.Controls.Add(seta_baixo);

            border_left_button.Visible = false;
            seta_baixo.Visible = false;
                                  
        }

        private void Mover_tela_cabecalho_MouseDown(object? sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // permite mudar a posição do form através do panel bar e sem a barra nativa do form

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form_principal_Load(object sender, EventArgs e)
        {
            acessos = new class_verifica_acessos(Manage_login.Id_usuario);

            DesenhaTelaInicial();

            if (mostra_menu_lateral is not null)
            {
                mostra_menu_lateral.Size = new Size(27, 27);
                mostra_menu_lateral.BorderStyle = BorderStyle.None;

                this.Controls.Add(mostra_menu_lateral);

                mostra_menu_lateral.Visible = false;

                mostra_menu_lateral.Click += Mostra_menu_lateral_Click; ;
                toolTip1.SetToolTip(mostra_menu_lateral, "Clique para abrir o menu lateral");

                mostra_menu_lateral.IconChar = IconChar.Bars;
                mostra_menu_lateral.IconFont = IconFont.Auto;
                mostra_menu_lateral.IconColor = System.Drawing.Color.FromArgb(0, 120, 111);
                mostra_menu_lateral.BackColor = System.Drawing.Color.Transparent;
                mostra_menu_lateral.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            timer_hora.Start();           
        }

        private void Mostra_menu_lateral_Click(object? sender, EventArgs e)
        {
            if (mostra_menu_lateral is not null)            
                mostra_menu_lateral.Visible = false;                
            
            panel_menu_lateral.Visible = true;
        }

        void DesenhaTelaInicial()
        {
            // configurações da janela principal

            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1000, 500);
            this.BackgroundImage = SetImageOpacity(Image.FromFile(@"imagens\fundo_camara.png"), 0.25F);
            this.BackgroundImageLayout = ImageLayout.Center;

            lbl_painel_operador = new Label();
            lbl_cab_hora = new Label();
            btn_minimize_form = new IconPictureBox();
            btn_maximize_form = new IconPictureBox();
            btn_close_form = new IconPictureBox();
            mostra_menu_lateral = new IconPictureBox();

            // cabeçalho, logos etc
            panel_cab_1.Height = 50;
            panel_cab_1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            panel_cab_1.AutoScroll = false;

            // painel do operador
            lbl_painel_operador.Text = "Painel do Operador";
            lbl_painel_operador.AutoSize = true;
            lbl_painel_operador.MouseDown += Mover_tela_cabecalho_MouseDown;

            panel_cab_1.Controls.Add(lbl_painel_operador);

            lbl_painel_operador.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            lbl_painel_operador.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
            lbl_painel_operador.Location = new Point(15, (panel_cab_1.Height / 2) - (lbl_painel_operador.Height / 2));

            // usuario
            lbl_usuario.AutoSize = true;
            lbl_usuario.Text = "Usuário:";
            lbl_usuario.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            lbl_usuario.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);

            lbl_nome_usuario.AutoSize = true;

            #region Adiciona abreviaturas no nome da pessoa
            lbl_nome_usuario.Text = "";

            string[] palavras_nome = Manage_login.Nome_Usuario.Split(' ');
            string abreviaturas = "";

            if (palavras_nome.Length >= 3)
            {
                for (int i = 0; i < palavras_nome.Length; i++)
                {
                    if (i + 1 == palavras_nome.Length - 1)
                        lbl_nome_usuario.Text += palavras_nome[0] + " " + abreviaturas + palavras_nome[palavras_nome.Length - 1];
                    else
                    {
                        if (string.IsNullOrWhiteSpace(lbl_nome_usuario.Text))
                            abreviaturas += palavras_nome[i + 1][0].ToString() + ". ";
                    }
                }
            }
            else
                lbl_nome_usuario.Text = Manage_login.Nome_Usuario;
            #endregion

            lbl_nome_usuario.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl_nome_usuario.ForeColor = System.Drawing.Color.FromArgb(46, 84, 123);

            panel_cab_usuario.Left = lbl_painel_operador.Width + lbl_painel_operador.Left + 30;
            panel_cab_usuario.Width = lbl_usuario.Width + lbl_nome_usuario.Width + 20;
            panel_cab_usuario.Height = panel_cab_1.Height;
            panel_cab_usuario.Location = new Point(panel_cab_usuario.Left, 0);

            lbl_usuario.Left = (panel_cab_usuario.Width / 2) - ((lbl_usuario.Width + lbl_nome_usuario.Width) / 2);
            lbl_usuario.Location = new Point(lbl_usuario.Left, (panel_cab_usuario.Height / 2) - (lbl_usuario.Height / 2));

            lbl_nome_usuario.Left = lbl_usuario.Left + lbl_usuario.Width;
            lbl_nome_usuario.Top = lbl_usuario.Top;

            // logo
            pictureBox_logo.Width = 240;
            pictureBox_logo.Height = panel_cab_1.Height;
            pictureBox_logo.Left = (panel_cab_1.Width / 2) - (pictureBox_logo.Width / 2);
            pictureBox_logo.Location = new Point(pictureBox_logo.Left, 0);
            pictureBox_logo.Anchor = AnchorStyles.None;

            // nome da cidade da camara
            lbl_nome_cidade.AutoSize = true;

            data = DateTime.Now;

            lbl_nome_cidade.Text = "Ji-Paraná - RO " + String.Format("{0: dd}", data).Trim() + "/" + String.Format("{0: MM}", data).Trim() + "/" + String.Format("{0: yyyy}", data).Trim();
            lbl_nome_cidade.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl_nome_cidade.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);

            panel_cab_camara.Width = lbl_nome_cidade.Width + 25;
            panel_cab_camara.Height = panel_cab_1.Height;

            lbl_nome_cidade.Left = (panel_cab_camara.Width / 2) - (lbl_nome_cidade.Width / 2);
            lbl_nome_cidade.Location = new Point(lbl_nome_cidade.Left, (panel_cab_camara.Height / 2) - (lbl_nome_cidade.Height / 2));

            // hora
            lbl_cab_hora.Text = String.Format("{0: HH}", data).Trim() + ":" + String.Format("{0: mm}", data).Trim();
            lbl_cab_hora.AutoSize = true;
            lbl_cab_hora.MouseDown += Mover_tela_cabecalho_MouseDown;

            panel_cab_1.Controls.Add(lbl_cab_hora);

            lbl_cab_hora.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 15, FontStyle.Regular);
            lbl_cab_hora.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
            lbl_cab_hora.Location = new Point((panel_cab_1.Width - lbl_cab_hora.Width) - 15, (panel_cab_1.Height / 2) - (lbl_cab_hora.Height / 2));
            lbl_cab_hora.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // posição nome da cidade da camara
            panel_cab_camara.Left = panel_cab_1.Width - lbl_cab_hora.Width - panel_cab_camara.Width - 35;
            panel_cab_camara.Location = new Point(panel_cab_camara.Left, 0);

            // cria panel contendo o menu superior =  mzSombraPanel_menu_superior
            MZSombraPanel mzSombraPanel_menu_superior = new MZSombraPanel();
            this.Controls.Add(mzSombraPanel_menu_superior);

            PictureBox pictureBox_logo_camara = new PictureBox();
            mzSombraPanel_menu_superior.Controls.Add(pictureBox_logo_camara);

            // logo da camara no panel menu
            pictureBox_logo_camara.BackgroundImage = Image.FromFile(@"imagens\logo_camara.png");
            pictureBox_logo_camara.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_logo_camara.Width = 168;
            pictureBox_logo_camara.Dock = DockStyle.Left;
            pictureBox_logo_camara.BackColor = System.Drawing.Color.Transparent;

            lbl_exibir_no_painel.Text = "Exibir no Painel";
            lbl_exibir_no_painel.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            lbl_exibir_no_painel.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);

            iconPictureBox_exibir_ao_publico.Width = 18;
            iconPictureBox_exibir_ao_publico.Height = 18;
            iconPictureBox_exibir_ao_publico.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox_exibir_ao_publico.BorderStyle = BorderStyle.None;

            // barra de menu rápido superior
            mzSombraPanel_menu_superior.TipoDeSombra = MZSombraPanel.ShadowsPanel.Desplasada;
            mzSombraPanel_menu_superior.Dock = DockStyle.None;
            mzSombraPanel_menu_superior.Width = this.Width - 25;
            mzSombraPanel_menu_superior.Height = 89;
            mzSombraPanel_menu_superior.Location = new Point(8, panel_cab_1.Height);
            mzSombraPanel_menu_superior.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            mzSombraPanel_menu_superior.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            mzSombraPanel_menu_superior.AutoScroll = true;

            // panel exibir no painel
            panel_menu_lateral.Height = this.Height - mzSombraPanel_menu_superior.Location.Y - mzSombraPanel_menu_superior.Height - 60;
            panel_menu_lateral.Width = 160;
            panel_menu_lateral.Left = this.Width - panel_menu_lateral.Width - 26;
            panel_menu_lateral.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            panel_menu_lateral.BorderStyle = BorderStyle.FixedSingle;
            panel_menu_lateral.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panel_menu_lateral.Location = new Point(panel_menu_lateral.Left, mzSombraPanel_menu_superior.Location.Y + mzSombraPanel_menu_superior.Height + 10);
            panel_menu_lateral.BorderStyle = BorderStyle.None;
            panel_menu_lateral.MinimumSize = new Size(160, 500);            
            panel_menu_lateral.SizeChanged += Panel_menu_lateral_SizeChanged;

            // botao que mostra o menu lateral direito
            mostra_menu_lateral.Location = new Point(this.Width - mostra_menu_lateral.Width - 18, mzSombraPanel_menu_superior.Location.Y + mzSombraPanel_menu_superior.Height + 23);

            iconPictureBox_exibir_ao_publico.Left = 8;
            iconPictureBox_exibir_ao_publico.Location = new Point(iconPictureBox_exibir_ao_publico.Left, 20);
            iconPictureBox_exibir_ao_publico.IconColor = System.Drawing.Color.FromArgb(0, 120, 111);
            iconPictureBox_exibir_ao_publico.BackColor = System.Drawing.Color.Transparent;
            iconPictureBox_exibir_ao_publico.IconFont = IconFont.Auto;
            iconPictureBox_exibir_ao_publico.Size = new Size(27, 27);

            lbl_exibir_no_painel.Left = iconPictureBox_exibir_ao_publico.Location.X + iconPictureBox_exibir_ao_publico.Width;
            lbl_exibir_no_painel.Location = new Point(lbl_exibir_no_painel.Left, 22);

            AdicionandoItensMenuLateral(panel_menu_lateral);
            ArredondaCantos(panel_menu_lateral);

            mzSombraPanel_lateral_esquerda.Width = 218;
            mzSombraPanel_lateral_esquerda.Height = 570;
            mzSombraPanel_lateral_esquerda.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            mzSombraPanel_lateral_esquerda.Location = new Point(8, mzSombraPanel_menu_superior.Top + mzSombraPanel_menu_superior.Height + 10);
            mzSombraPanel_lateral_esquerda.Height = this.Height - mzSombraPanel_lateral_esquerda.Location.Y - 200;
            mzSombraPanel_lateral_esquerda.MinimumSize = new Size(218, 500);
            mzSombraPanel_lateral_esquerda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            mzSombraPanel_lateral_esquerda.AutoScroll = true;
            if (mzSombraPanel_lateral_esquerda is MZSombraPanel) // caso troque o componente para ser o mzsombraPanel
            {
                MZSombraPanel mz_sombra = (MZSombraPanel)mzSombraPanel_lateral_esquerda;
                mz_sombra.TipoDeSombra = MZSombraPanel.ShadowsPanel.Desplasada;
            }

            // adiciona os menus rápidos
            AdicionaMenusRapidos(mzSombraPanel_menu_superior, pictureBox_logo_camara);

            // adiciona menus laterais gerais
            AdicionaMenuLateralEsquerda();

            // botão minimizar
            btn_minimize_form.IconChar = IconChar.WindowMinimize;
            btn_minimize_form.BackgroundImageLayout = ImageLayout.Center;
            btn_minimize_form.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_minimize_form.Width = 30;
            btn_minimize_form.Height = 30;
            btn_minimize_form.IconFont = IconFont.Solid;
            btn_minimize_form.Padding = new Padding(0, 0, 0, 8);
            btn_minimize_form.IconColor = System.Drawing.Color.FromArgb(46, 84, 123);
            this.Controls.Add(btn_minimize_form);
            btn_minimize_form.Location = new Point(15, this.Height - btn_minimize_form.Height - (btn_minimize_form.Height / 2));
            btn_minimize_form.BringToFront();
            btn_minimize_form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btn_minimize_form.Click += Btn_minimize_form_Click; ;

            // botão maximizar
            btn_maximize_form.IconChar = IconChar.WindowMaximize;
            btn_maximize_form.BackgroundImageLayout = ImageLayout.Center;
            btn_maximize_form.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_maximize_form.Width = 30;
            btn_maximize_form.Height = 30;
            btn_maximize_form.IconFont = IconFont.Solid;
            btn_maximize_form.IconColor = System.Drawing.Color.FromArgb(46, 84, 123);
            this.Controls.Add(btn_maximize_form);
            btn_maximize_form.Location = new Point(btn_minimize_form.Left + btn_minimize_form.Width + 5, this.Height - btn_maximize_form.Height - (btn_maximize_form.Height / 2));
            btn_maximize_form.BringToFront();
            btn_maximize_form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btn_maximize_form.Click += Btn_maximize_form_Click; ;

            // botão fechar
            btn_close_form.IconChar = IconChar.WindowClose;
            btn_close_form.BackgroundImageLayout = ImageLayout.Center;
            btn_close_form.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_close_form.Width = 30;
            btn_close_form.Height = 30;
            btn_close_form.IconFont = IconFont.Solid;
            btn_close_form.IconColor = System.Drawing.Color.FromArgb(46, 84, 123);
            this.Controls.Add(btn_close_form);
            btn_close_form.Location = new Point(btn_maximize_form.Left + btn_maximize_form.Width + 5, this.Height - btn_close_form.Height - (btn_close_form.Height / 2));
            btn_close_form.BringToFront();
            btn_close_form.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btn_close_form.Click += Btn_close_form_Click; ;
        }

        private void Btn_close_form_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_maximize_form_Click(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void Btn_minimize_form_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        async void AdicionaMenuLateralEsquerda()
        {
            // carregar acessos do banco
            if (acessos is not null)            
                todos_menus = await acessos.RetornaMenusLateraisEsquerdo();

            if (todos_menus is not null)            
                array_menus = todos_menus.Split('\n');  

            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Cadastros", "cadastro", 0, 0, IconChar.Home));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Registros", "registro", 1, 1, IconChar.ChartSimple));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Acessar", "acesso", 2, 2, IconChar.Envelope));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Exibir no Painel", "exibir_no_painel", 3, 3, IconChar.FileLines));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Configurações", "configuracoes", 4, 4, IconChar.Gear));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Relatórios", "relatorio", 5, 5, IconChar.Clipboard));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Ajuda", "ajuda", 6, 6, IconChar.CircleQuestion));
            lista_botoes_menu_lateral_esquerdo.Add(CriaBotaoLateralEsquerda(" Sair", "sair", 7, 7, IconChar.CircleLeft));
        }
        IconButton CriaBotaoLateralEsquerda(string text, string label, int ordemBotao, int qt_button, IconChar icone)
        {
            botao_lat_esquerda = new IconButton();

            botao_lat_esquerda.BackColor = System.Drawing.Color.Transparent;
            botao_lat_esquerda.Height = 55;
            botao_lat_esquerda.Width = 190;
            botao_lat_esquerda.Text = text;
            mzSombraPanel_lateral_esquerda.Controls.Add(botao_lat_esquerda);
            botao_lat_esquerda.Tag = ordemBotao;
            botao_lat_esquerda.Location = new Point(5, 18 + (botao_lat_esquerda.Height * qt_button));
            botao_lat_esquerda.FlatStyle = FlatStyle.Flat;
            botao_lat_esquerda.FlatAppearance.BorderSize = 0;
            botao_lat_esquerda.Font = new Font(montserrat ?? FontFamily.GenericSansSerif, 11, FontStyle.Regular);
            botao_lat_esquerda.IconChar = icone;
            botao_lat_esquerda.IconColor = System.Drawing.Color.FromArgb(0, 120, 111);
            botao_lat_esquerda.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
            botao_lat_esquerda.TextImageRelation = TextImageRelation.ImageBeforeText;
            botao_lat_esquerda.IconSize = 28;
            botao_lat_esquerda.TextAlign = ContentAlignment.MiddleLeft;
            botao_lat_esquerda.ImageAlign = ContentAlignment.MiddleLeft;
            botao_lat_esquerda.Padding = new Padding(10, 0, 0, 0);

            botao_lat_esquerda.Click += Botao_lat_esquerda_Click; ;

            botao_lat_esquerda.BackgroundImage = null;

            return botao_lat_esquerda;
        }

        private void Botao_lat_esquerda_Click(object? sender, EventArgs e)
        {
            DesativaBotaoEsquerda();

            botao = sender as IconButton;

            if (botao is not null)
            {
                botao.BackgroundImage = Image.FromFile(@"imagens\botao_menu_lateral_esquerdo.png");
                botao.BackgroundImageLayout = ImageLayout.Stretch;
                botao.ForeColor = System.Drawing.Color.FromArgb(0, 88, 255);
                botao.IconColor = System.Drawing.Color.FromArgb(0, 88, 255);

                botao_ativo_esquerda = botao;

                if (seta_baixo is not null)
                {
                    seta_baixo.Location = new Point(botao.Width - seta_baixo.Width, botao.Location.Y + ((botao.Height / 2) - (seta_baixo.Height / 2)));
                    seta_baixo.Visible = true;
                }

                if (border_left_button is not null)
                {
                    border_left_button.Location = new Point(5, botao.Location.Y);
                    border_left_button.Visible = true;
                }                

                RemoveBotoesOpcoesMenuLateralEsquerdo();
                CriaBotoesOpcoesMenuLateralEsquerdo(botao);
            }            
        }
        void RemoveBotoesOpcoesMenuLateralEsquerdo()
        {
            if (lista_labels_opcoes_menu_lateral_esquerdo.Count != 0)
            {
                foreach (Label item in lista_labels_opcoes_menu_lateral_esquerdo)
                {
                    mzSombraPanel_lateral_esquerda.Controls.Remove(item);
                    item.Dispose();
                }
                lista_labels_opcoes_menu_lateral_esquerdo.Clear();
            }
        }
        void CriaBotoesOpcoesMenuLateralEsquerdo(IconButton botaoSender)
        {
            string primeira_parte = "", segunda_parte = "", terceira_parte = "", quarta_parte = "";
            int totalAltura = 0;

            // descobre quantas opções terá neste menu para somar o total de sua altura

            if (array_menus is not null)
            {
                for (int i = 0; i < array_menus.Length; i++)
                {
                    if (!string.IsNullOrEmpty(array_menus[i]))
                    {
                        primeira_parte = array_menus[i].Substring(array_menus[i].IndexOf(";") + 1);
                        segunda_parte = primeira_parte.Substring(primeira_parte.IndexOf(";") + 1);
                        terceira_parte = segunda_parte.Substring(segunda_parte.IndexOf(";") + 1);
                        quarta_parte = terceira_parte.Substring(0, terceira_parte.IndexOf(";"));

                        var tagButtonStart = botaoSender.Tag ?? "";

                        if (quarta_parte == tagButtonStart.ToString())
                        {
                            totalAltura += 23;
                        }      
                    }
                }
            }            

            RerganizaAlturaBotoes(botaoSender, totalAltura);

            int qtOpcoes = 0;
            string label = "";

            // se clicar no botão de sair, pergunta se deseja mesmo sair
            var tagButton = botaoSender.Tag ?? "";

            if ((int)tagButton == 7)
            {
                if (seta_baixo is not null)                
                    seta_baixo.Visible = false;
                                
                DialogResult result = MessageBox.Show("Deseja mesmo sair?", "Você está saindo do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                // cria as labls que serão as opções 

                if (array_menus is not null)
                {
                    for (int i = 0; i < array_menus.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(array_menus[i]))
                        {
                            primeira_parte = array_menus[i].Substring(array_menus[i].IndexOf(";") + 1);
                            segunda_parte = primeira_parte.Substring(primeira_parte.IndexOf(";") + 1);
                            terceira_parte = segunda_parte.Substring(segunda_parte.IndexOf(";") + 1);
                            quarta_parte = terceira_parte.Substring(0, terceira_parte.IndexOf(";"));

                            var tagButtonSender = botaoSender.Tag ?? "";
                            if (quarta_parte == tagButtonSender.ToString())
                            {
                                primeira_parte = array_menus[i].Substring(array_menus[i].IndexOf(";") + 1);
                                label = primeira_parte.Substring(0, primeira_parte.IndexOf(";"));

                                lista_labels_opcoes_menu_lateral_esquerdo.Add(CrialabelOpcao(array_menus[i].Substring(0, array_menus[i].IndexOf(";")), botaoSender, qtOpcoes, label));
                                qtOpcoes++;
                            }
                        }
                    }
                }
            }
        }
        Label CrialabelOpcao(string nome, IconButton iconButton, int qtOpcoes, string label)
        {
            Label opcao = new Label();

            opcao.Text = nome;
            opcao.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
            opcao.Font = new Font(montserrat ?? FontFamily.GenericSerif, 10, FontStyle.Regular);
            opcao.AutoSize = false;

            if (botao_lat_esquerda is not null)            
                opcao.Width = botao_lat_esquerda.Width;            
            
            opcao.Height = 23;
            opcao.BackColor = System.Drawing.Color.Transparent;
            opcao.TextAlign = ContentAlignment.MiddleLeft;
            opcao.Padding = new Padding(15, 0, 0, 0);
            opcao.Tag = label;

            mzSombraPanel_lateral_esquerda.Controls.Add(opcao);

            opcao.MouseMove += Opcao_MouseMove; ;
            opcao.MouseLeave += Opcao_MouseLeave; ;
            opcao.MouseClick += Opcao_MouseClick; ;

            opcao.Location = new Point(5, iconButton.Location.Y + iconButton.Height + (23 * qtOpcoes));
            opcao.BringToFront();

            return opcao;
        }

        private void Opcao_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender is Label item)
            {
                var tagItem = item.Tag ?? "";

                if (tagItem.ToString() == "acessos")
                {
                    //form_acessos form_Acessos = new form_acessos();
                    //form_Acessos.ShowDialog();
                }
                else if (tagItem.ToString() == "entidade")
                {
                    using (Entidade entidade = new Entidade())
                    {
                        entidade.ShowDialog();
                    }                         
                }
                else if (tagItem.ToString() == "pessoas")
                {
                    using (CadastroPessoas pessoas = new CadastroPessoas())
                    {
                        pessoas.ShowDialog();
                    }
                }
                else if (tagItem.ToString() == "legislatura")
                {
                    using (Legislaturas legislaturas = new Legislaturas())
                    {
                        legislaturas.ShowDialog();
                    }
                }
            }            
        }

        private void Opcao_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Label item)
                item.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
        }

        private void Opcao_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is Label item)            
                item.ForeColor = System.Drawing.Color.FromArgb(20, 20, 20);           
        }

        void RerganizaAlturaBotoes(IconButton botaoSender, int heightLabls)
        {
            // ajustar altura apenas dos botões que tem a ordem maior que a ordem do botão atual
            
            var tagButton = botaoSender.Tag ?? "";

            int ordem_button_atual = (int)tagButton;
            int controler = 0;

            if (ordem_button_atual != 0) // retira o primeiro botão
            {
                int diferenca = 0;
                for (int i = 1; i <= ordem_button_atual; i++)
                {
                    diferenca = lista_botoes_menu_lateral_esquerdo[i].Location.Y - (lista_botoes_menu_lateral_esquerdo[i - 1].Location.Y + lista_botoes_menu_lateral_esquerdo[i - 1].Height);

                    if (diferenca != 0)
                    {
                        if (i == ordem_button_atual)
                        {
                            lista_botoes_menu_lateral_esquerdo[i].Location = new Point(5, lista_botoes_menu_lateral_esquerdo[i].Location.Y - diferenca);

                            if (border_left_button is not null)                            
                                border_left_button.Location = new Point(5, lista_botoes_menu_lateral_esquerdo[i].Location.Y);
                            
                            if (seta_baixo is not null)                            
                                seta_baixo.Location = new Point(lista_botoes_menu_lateral_esquerdo[i].Width - seta_baixo.Width, lista_botoes_menu_lateral_esquerdo[i].Location.Y + ((lista_botoes_menu_lateral_esquerdo[i].Height / 2) - (seta_baixo.Height / 2)));                                                        
                        }
                        else
                        {
                            lista_botoes_menu_lateral_esquerdo[i].Location = new Point(5, lista_botoes_menu_lateral_esquerdo[i].Location.Y - diferenca);
                        }
                    }
                }
            }

            for (int i = ordem_button_atual + 1; i < lista_botoes_menu_lateral_esquerdo.Count; i++)
            {
                if (controler == 0)
                {
                    lista_botoes_menu_lateral_esquerdo[i].Location = new Point(5, lista_botoes_menu_lateral_esquerdo[i - 1].Location.Y + lista_botoes_menu_lateral_esquerdo[i - 1].Height + heightLabls);
                    controler++;
                }
                else
                {
                    lista_botoes_menu_lateral_esquerdo[i].Location = new Point(5, lista_botoes_menu_lateral_esquerdo[i - 1].Location.Y + lista_botoes_menu_lateral_esquerdo[i - 1].Height);
                }
            }
        }
        void DesativaBotaoEsquerda()
        {
            if (botao_ativo_esquerda != null)
            {
                botao_ativo_esquerda.BackgroundImage = null;
                botao_ativo_esquerda.ForeColor = System.Drawing.Color.FromArgb(0, 120, 111);
                botao_ativo_esquerda.IconColor = System.Drawing.Color.FromArgb(0, 120, 111);
            }
        }
        async void AdicionaMenusRapidos(MZSombraPanel mzSombraPanel_menu_superior, PictureBox pictureBox_logo_camara)
        {
            string? menus_rapidos = "";

            if (acessos is not null)            
                menus_rapidos = await acessos.RetornaMenusRapidos();           
            
            if (!string.IsNullOrEmpty(menus_rapidos))
            {
                string[] menu_rapido = menus_rapidos.Split('\n');
                string nome_imagem = "";
                string nome_substring = "";
                int espaco_entre_categorias = 0;
                int cont_categoria = 1;

                //Entidade;entidade;CADASTRO
                nome_substring = menu_rapido[0].Substring(menu_rapido[0].IndexOf(";") + 1);

                //entidade;CADASTRO
                string categoria_anterior = nome_substring.Substring(nome_substring.IndexOf(";") + 1);
                //CADASTRO

                for (int i = 0; i < menu_rapido.Length - 1; i++)
                {
                    opc_menu_rapido = new PictureBox();
                    opc_menu_rapido.Height = 67;
                    opc_menu_rapido.Width = 67;
                    opc_menu_rapido.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    opc_menu_rapido.BackColor = System.Drawing.Color.Transparent;

                    nome_substring = menu_rapido[i].Substring(menu_rapido[i].IndexOf(";") + 1);
                    nome_imagem = nome_substring.Substring(0, nome_substring.IndexOf(";"));

                    opc_menu_rapido.Image = Image.FromFile(@"imagens\iconesSuperiores\" + nome_imagem + ".png");
                    opc_menu_rapido.SizeMode = PictureBoxSizeMode.Zoom;
                    opc_menu_rapido.Tag = nome_imagem;
                    opc_menu_rapido.Click += Opc_menu_rapido_Click; ;
                    opc_menu_rapido.MouseMove += Opc_menu_rapido_MouseMove; ;
                    opc_menu_rapido.MouseLeave += Opc_menu_rapido_MouseLeave; ;

                    mzSombraPanel_menu_superior.Controls.Add(opc_menu_rapido);

                    // compara a categoria anterior com a atual
                    nome_substring = menu_rapido[i].Substring(menu_rapido[i].IndexOf(";") + 1);
                    if (categoria_anterior == nome_substring.Substring(nome_substring.IndexOf(";") + 1))
                    {
                        opc_menu_rapido.Location = new Point((pictureBox_logo_camara.Left + pictureBox_logo_camara.Width) + (67 * i) + espaco_entre_categorias, 7);
                    }
                    else
                    {
                        opc_menu_rapido.Location = new Point((pictureBox_logo_camara.Left + pictureBox_logo_camara.Width) + (67 * i) + (37 * cont_categoria), 7);

                        espaco_entre_categorias = 37 * cont_categoria;
                        cont_categoria++;
                    }

                    toolTip1.IsBalloon = false;
                    toolTip1.ToolTipIcon = ToolTipIcon.Info;
                    toolTip1.ToolTipTitle = "Menu";
                    toolTip1.SetToolTip(opc_menu_rapido, menu_rapido[i].Substring(0, menu_rapido[i].IndexOf(";")));

                    nome_substring = menu_rapido[i].Substring(menu_rapido[i].IndexOf(";") + 1);
                    categoria_anterior = nome_substring.Substring(nome_substring.IndexOf(";") + 1);
                }
            }
        }

        private void Opc_menu_rapido_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                if (pictureBox.Tag is not null)
                {
                    FileInfo file = new FileInfo(@"imagens\iconesSuperiores\" + pictureBox.Tag.ToString() + ".png");

                    if (file.Exists)
                        pictureBox.Image = Image.FromFile(@"imagens\iconesSuperiores\" + pictureBox.Tag.ToString() + ".png");
                }
            }
        }

        private void Opc_menu_rapido_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                if (pictureBox.Tag is not null)
                {
                    FileInfo file = new FileInfo(@"imagens\iconesSuperiores\" + pictureBox.Tag.ToString() + "_2.png");
                    if (file.Exists)
                        pictureBox.Image = Image.FromFile(@"imagens\iconesSuperiores\" + pictureBox.Tag.ToString() + "_2.png");
                }                    
            }            
        }

        private void Opc_menu_rapido_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {                
                if(pictureBox.Tag is not null)
                    MessageBox.Show(pictureBox.Tag.ToString());
            }            
        }

        void AdicionandoItensMenuLateral(Panel panel_lateral)
        {
            PictureBox ultimo;

            CriaBotaoLateralDireito(panel_lateral, "pauta_do_dia", 0);
            CriaBotaoLateralDireito(panel_lateral, "ata", 1);
            CriaBotaoLateralDireito(panel_lateral, "palavra_livre", 2);
            CriaBotaoLateralDireito(panel_lateral, "discussao", 3);
            CriaBotaoLateralDireito(panel_lateral, "votacao", 4);
            ultimo = CriaBotaoLateralDireito(panel_lateral, "mensagens", 5);

            panel_lateral.Height = ultimo.Location.Y + ultimo.Height + 20;

        }
        PictureBox CriaBotaoLateralDireito(Panel panel_lateral, string imagem, int qtBotoes)
        {
            PictureBox botoes_laterais_direito = new PictureBox();

            botoes_laterais_direito.Size = new Size(115, 110);
            botoes_laterais_direito.Tag = imagem;
            botoes_laterais_direito.Image = Image.FromFile(@"imagens\iconesControlLateral\nao_permite_mostrar\" + imagem + ".png");
            botoes_laterais_direito.SizeMode = PictureBoxSizeMode.Zoom;

            panel_lateral.Controls.Add(botoes_laterais_direito);

            botoes_laterais_direito.Location = new Point((panel_lateral.Width / 2) - (botoes_laterais_direito.Width / 2), lbl_exibir_no_painel.Top + lbl_exibir_no_painel.Height + 17 + (botoes_laterais_direito.Height * qtBotoes) + (10 * qtBotoes));

            return botoes_laterais_direito;
        }
        private void Panel_menu_lateral_SizeChanged(object? sender, EventArgs e)
        {
            if (sender is Panel panel)            
                ArredondaCantos(panel);                     
        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;

            // fonte
            //https://stackoverflow.com/questions/23114282/are-we-able-to-set-opacity-of-the-background-image-of-a-panel
            //https://www.codeproject.com/Tips/201129/Change-Opacity-of-Image-in-C
        }
        private void ArredondaCantos(Control control)
        {
            using (GraphicsPath forma = new GraphicsPath())
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

        private void mzSombraPanel_lateral_esquerda_SizeChanged(object sender, EventArgs e)
        {
            if (sender is Panel panel)            
                ArredondaCantos(panel);
            else if(sender is MZSombraPanel sombraPanel)            
                ArredondaCantos(sombraPanel);   
        }

        private void iconPictureBox_exibir_ao_publico_Click(object sender, EventArgs e)
        {
            panel_menu_lateral.Visible = false;

            if (mostra_menu_lateral is not null)
            {
                mostra_menu_lateral.BringToFront();
                mostra_menu_lateral.Visible = true;
            }            
        }

        private void timer_hora_Tick(object sender, EventArgs e)
        {
            data = DateTime.Now;
            if (lbl_cab_hora is not null)            
                lbl_cab_hora.Text = String.Format("{0: HH}", data).Trim() + ":" + String.Format("{0: mm}", data).Trim();
                        
            lbl_nome_cidade.Text = "JI-PARANÁ - RO " + String.Format("{0: dd}", data).Trim() + "/" + String.Format("{0: MM}", data).Trim() + "/" + String.Format("{0: yyyy}", data).Trim();
        }

        private void Form_principal_Shown(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
    }
}