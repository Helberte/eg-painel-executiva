namespace eg_painel
{
    partial class Form_principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_principal));
            this.panel_cab_1 = new System.Windows.Forms.Panel();
            this.panel_cab_camara = new System.Windows.Forms.Panel();
            this.lbl_nome_cidade = new System.Windows.Forms.Label();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_cab_usuario = new System.Windows.Forms.Panel();
            this.lbl_nome_usuario = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.mzSombraPanel_lateral_esquerda = new System.Windows.Forms.Panel();
            this.panel_menu_lateral = new System.Windows.Forms.Panel();
            this.lbl_exibir_no_painel = new System.Windows.Forms.Label();
            this.iconPictureBox_exibir_ao_publico = new FontAwesome.Sharp.IconPictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_hora = new System.Windows.Forms.Timer(this.components);
            this.panel_cab_1.SuspendLayout();
            this.panel_cab_camara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.panel_cab_usuario.SuspendLayout();
            this.panel_menu_lateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_exibir_ao_publico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_cab_1
            // 
            this.panel_cab_1.Controls.Add(this.panel_cab_camara);
            this.panel_cab_1.Controls.Add(this.pictureBox_logo);
            this.panel_cab_1.Controls.Add(this.panel_cab_usuario);
            this.panel_cab_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cab_1.Location = new System.Drawing.Point(0, 0);
            this.panel_cab_1.Name = "panel_cab_1";
            this.panel_cab_1.Size = new System.Drawing.Size(986, 76);
            this.panel_cab_1.TabIndex = 0;
            // 
            // panel_cab_camara
            // 
            this.panel_cab_camara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_cab_camara.Controls.Add(this.lbl_nome_cidade);
            this.panel_cab_camara.Location = new System.Drawing.Point(699, 0);
            this.panel_cab_camara.Name = "panel_cab_camara";
            this.panel_cab_camara.Size = new System.Drawing.Size(287, 76);
            this.panel_cab_camara.TabIndex = 2;
            this.panel_cab_camara.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // lbl_nome_cidade
            // 
            this.lbl_nome_cidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_nome_cidade.Location = new System.Drawing.Point(44, 33);
            this.lbl_nome_cidade.Name = "lbl_nome_cidade";
            this.lbl_nome_cidade.Size = new System.Drawing.Size(197, 19);
            this.lbl_nome_cidade.TabIndex = 0;
            this.lbl_nome_cidade.Text = "CÂMARA MUNICIPAL DE JI-PARANÁ";
            this.lbl_nome_cidade.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = global::eg_painel.Properties.Resources.logo_ep;
            this.pictureBox_logo.Location = new System.Drawing.Point(374, 0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(214, 76);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 1;
            this.pictureBox_logo.TabStop = false;
            this.pictureBox_logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // panel_cab_usuario
            // 
            this.panel_cab_usuario.Controls.Add(this.lbl_nome_usuario);
            this.panel_cab_usuario.Controls.Add(this.lbl_usuario);
            this.panel_cab_usuario.Location = new System.Drawing.Point(0, 0);
            this.panel_cab_usuario.Name = "panel_cab_usuario";
            this.panel_cab_usuario.Size = new System.Drawing.Size(249, 76);
            this.panel_cab_usuario.TabIndex = 0;
            this.panel_cab_usuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // lbl_nome_usuario
            // 
            this.lbl_nome_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_nome_usuario.AutoSize = true;
            this.lbl_nome_usuario.Location = new System.Drawing.Point(81, 33);
            this.lbl_nome_usuario.Name = "lbl_nome_usuario";
            this.lbl_nome_usuario.Size = new System.Drawing.Size(95, 13);
            this.lbl_nome_usuario.TabIndex = 1;
            this.lbl_nome_usuario.Text = "Evandro de Souza";
            this.lbl_nome_usuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(29, 33);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(46, 13);
            this.lbl_usuario.TabIndex = 0;
            this.lbl_usuario.Text = "Usuário:";
            this.lbl_usuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mover_tela_cabecalho_MouseDown);
            // 
            // mzSombraPanel_lateral_esquerda
            // 
            this.mzSombraPanel_lateral_esquerda.Location = new System.Drawing.Point(12, 170);
            this.mzSombraPanel_lateral_esquerda.Name = "mzSombraPanel_lateral_esquerda";
            this.mzSombraPanel_lateral_esquerda.Size = new System.Drawing.Size(200, 380);
            this.mzSombraPanel_lateral_esquerda.TabIndex = 1;
            this.mzSombraPanel_lateral_esquerda.SizeChanged += new System.EventHandler(this.mzSombraPanel_lateral_esquerda_SizeChanged);
            // 
            // panel_menu_lateral
            // 
            this.panel_menu_lateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_menu_lateral.AutoScroll = true;
            this.panel_menu_lateral.Controls.Add(this.lbl_exibir_no_painel);
            this.panel_menu_lateral.Controls.Add(this.iconPictureBox_exibir_ao_publico);
            this.panel_menu_lateral.Location = new System.Drawing.Point(774, 170);
            this.panel_menu_lateral.Name = "panel_menu_lateral";
            this.panel_menu_lateral.Size = new System.Drawing.Size(200, 380);
            this.panel_menu_lateral.TabIndex = 2;
            // 
            // lbl_exibir_no_painel
            // 
            this.lbl_exibir_no_painel.AutoSize = true;
            this.lbl_exibir_no_painel.Location = new System.Drawing.Point(62, 30);
            this.lbl_exibir_no_painel.Name = "lbl_exibir_no_painel";
            this.lbl_exibir_no_painel.Size = new System.Drawing.Size(79, 13);
            this.lbl_exibir_no_painel.TabIndex = 1;
            this.lbl_exibir_no_painel.Text = "Exibir no Painel";
            // 
            // iconPictureBox_exibir_ao_publico
            // 
            this.iconPictureBox_exibir_ao_publico.BackColor = System.Drawing.Color.White;
            this.iconPictureBox_exibir_ao_publico.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_exibir_ao_publico.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.iconPictureBox_exibir_ao_publico.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_exibir_ao_publico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox_exibir_ao_publico.IconSize = 38;
            this.iconPictureBox_exibir_ao_publico.Location = new System.Drawing.Point(12, 19);
            this.iconPictureBox_exibir_ao_publico.Name = "iconPictureBox_exibir_ao_publico";
            this.iconPictureBox_exibir_ao_publico.Size = new System.Drawing.Size(39, 38);
            this.iconPictureBox_exibir_ao_publico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox_exibir_ao_publico.TabIndex = 0;
            this.iconPictureBox_exibir_ao_publico.TabStop = false;
            this.iconPictureBox_exibir_ao_publico.Click += new System.EventHandler(this.iconPictureBox_exibir_ao_publico_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Menu";
            // 
            // timer_hora
            // 
            this.timer_hora.Interval = 1000;
            this.timer_hora.Tick += new System.EventHandler(this.timer_hora_Tick);
            // 
            // Form_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 572);
            this.Controls.Add(this.panel_menu_lateral);
            this.Controls.Add(this.mzSombraPanel_lateral_esquerda);
            this.Controls.Add(this.panel_cab_1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_principal";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_principal_Load);
            this.Shown += new System.EventHandler(this.Form_principal_Shown);
            this.panel_cab_1.ResumeLayout(false);
            this.panel_cab_camara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.panel_cab_usuario.ResumeLayout(false);
            this.panel_cab_usuario.PerformLayout();
            this.panel_menu_lateral.ResumeLayout(false);
            this.panel_menu_lateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_exibir_ao_publico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_cab_1;
        private Panel panel_cab_camara;
        private Label lbl_nome_cidade;
        private PictureBox pictureBox_logo;
        private Panel panel_cab_usuario;
        private Label lbl_nome_usuario;
        private Label lbl_usuario;
        private Panel mzSombraPanel_lateral_esquerda;
        private Panel panel_menu_lateral;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_exibir_ao_publico;
        private Label lbl_exibir_no_painel;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer timer_hora;
    }
}