namespace eg_painel.form_login
{
    partial class Form_login_inicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login_inicial));
            this.panel_center = new System.Windows.Forms.Panel();
            this.lbl_esqueceu_senha = new System.Windows.Forms.Label();
            this.checkBox_lembrar = new System.Windows.Forms.CheckBox();
            this.pictureBox_bt_acessar = new FontAwesome.Sharp.IconButton();
            this.ed_senha = new System.Windows.Forms.TextBox();
            this.ed_usuario = new System.Windows.Forms.TextBox();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.iconPictureBox_logo = new FontAwesome.Sharp.IconPictureBox();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_center
            // 
            this.panel_center.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_center.BackColor = System.Drawing.Color.White;
            this.panel_center.Controls.Add(this.lbl_esqueceu_senha);
            this.panel_center.Controls.Add(this.checkBox_lembrar);
            this.panel_center.Controls.Add(this.pictureBox_bt_acessar);
            this.panel_center.Controls.Add(this.ed_senha);
            this.panel_center.Controls.Add(this.ed_usuario);
            this.panel_center.Controls.Add(this.lbl_usuario);
            this.panel_center.Controls.Add(this.iconPictureBox_logo);
            this.panel_center.Location = new System.Drawing.Point(191, 12);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(418, 489);
            this.panel_center.TabIndex = 0;
            // 
            // lbl_esqueceu_senha
            // 
            this.lbl_esqueceu_senha.AutoSize = true;
            this.lbl_esqueceu_senha.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_esqueceu_senha.Location = new System.Drawing.Point(136, 402);
            this.lbl_esqueceu_senha.Name = "lbl_esqueceu_senha";
            this.lbl_esqueceu_senha.Size = new System.Drawing.Size(135, 16);
            this.lbl_esqueceu_senha.TabIndex = 6;
            this.lbl_esqueceu_senha.Text = "Esqueceu sua senha?";
            // 
            // checkBox_lembrar
            // 
            this.checkBox_lembrar.AutoSize = true;
            this.checkBox_lembrar.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_lembrar.Location = new System.Drawing.Point(258, 307);
            this.checkBox_lembrar.Name = "checkBox_lembrar";
            this.checkBox_lembrar.Size = new System.Drawing.Size(102, 20);
            this.checkBox_lembrar.TabIndex = 5;
            this.checkBox_lembrar.Text = "Lembrar-me";
            this.checkBox_lembrar.UseVisualStyleBackColor = true;
            // 
            // pictureBox_bt_acessar
            // 
            this.pictureBox_bt_acessar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bt_acessar.BackgroundImage = global::eg_painel.Properties.Resources.borda_botao_acessar;
            this.pictureBox_bt_acessar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_bt_acessar.FlatAppearance.BorderSize = 0;
            this.pictureBox_bt_acessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pictureBox_bt_acessar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pictureBox_bt_acessar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            this.pictureBox_bt_acessar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.pictureBox_bt_acessar.IconColor = System.Drawing.Color.Black;
            this.pictureBox_bt_acessar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pictureBox_bt_acessar.Location = new System.Drawing.Point(58, 295);
            this.pictureBox_bt_acessar.Name = "pictureBox_bt_acessar";
            this.pictureBox_bt_acessar.Size = new System.Drawing.Size(138, 43);
            this.pictureBox_bt_acessar.TabIndex = 4;
            this.pictureBox_bt_acessar.Text = "ACESSAR";
            this.pictureBox_bt_acessar.UseVisualStyleBackColor = false;
            this.pictureBox_bt_acessar.Click += new System.EventHandler(this.pictureBox_bt_acessar_Click);
            // 
            // ed_senha
            // 
            this.ed_senha.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ed_senha.Location = new System.Drawing.Point(59, 224);
            this.ed_senha.MaxLength = 100;
            this.ed_senha.Name = "ed_senha";
            this.ed_senha.Size = new System.Drawing.Size(301, 27);
            this.ed_senha.TabIndex = 3;
            this.ed_senha.Tag = "Senha";
            this.ed_senha.Enter += new System.EventHandler(this.ed_senha_Enter);
            this.ed_senha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ed_senha_KeyPress);
            this.ed_senha.Leave += new System.EventHandler(this.ed_senha_Leave);
            // 
            // ed_usuario
            // 
            this.ed_usuario.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ed_usuario.Location = new System.Drawing.Point(58, 176);
            this.ed_usuario.MaxLength = 100;
            this.ed_usuario.Name = "ed_usuario";
            this.ed_usuario.Size = new System.Drawing.Size(301, 27);
            this.ed_usuario.TabIndex = 2;
            this.ed_usuario.Tag = "Usuário";
            this.ed_usuario.TextChanged += new System.EventHandler(this.ed_usuario_TextChanged);
            this.ed_usuario.Enter += new System.EventHandler(this.ed_usuario_Enter);
            this.ed_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ed_usuario_KeyPress);
            this.ed_usuario.Leave += new System.EventHandler(this.ed_usuario_Leave);
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(58, 150);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(47, 15);
            this.lbl_usuario.TabIndex = 1;
            this.lbl_usuario.Text = "Usuário";
            // 
            // iconPictureBox_logo
            // 
            this.iconPictureBox_logo.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox_logo.BackgroundImage = global::eg_painel.Properties.Resources.logo_ep;
            this.iconPictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconPictureBox_logo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_logo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox_logo.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox_logo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox_logo.IconSize = 71;
            this.iconPictureBox_logo.Location = new System.Drawing.Point(81, 52);
            this.iconPictureBox_logo.Name = "iconPictureBox_logo";
            this.iconPictureBox_logo.Size = new System.Drawing.Size(256, 71);
            this.iconPictureBox_logo.TabIndex = 0;
            this.iconPictureBox_logo.TabStop = false;
            // 
            // Form_login_inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.panel_center);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_login_inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login EG-Painel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel_center.ResumeLayout(false);
            this.panel_center.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_center;
        private Label lbl_esqueceu_senha;
        private CheckBox checkBox_lembrar;
        private FontAwesome.Sharp.IconButton pictureBox_bt_acessar;
        private TextBox ed_senha;
        private TextBox ed_usuario;
        private Label lbl_usuario;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_logo;
    }
}