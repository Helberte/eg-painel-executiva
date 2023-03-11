namespace eg_painel.forms
{
    partial class FormAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccess));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ed_consulta = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_usuarios = new System.Windows.Forms.TabPage();
            this.dataGrid_usuarios = new System.Windows.Forms.DataGridView();
            this.tabPage_acessos = new System.Windows.Forms.TabPage();
            this.dataGrid_acessos = new System.Windows.Forms.DataGridView();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_nome_usuario = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_usuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_usuarios)).BeginInit();
            this.tabPage_acessos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_acessos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 69);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ed_consulta);
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Location = new System.Drawing.Point(9, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 37);
            this.panel2.TabIndex = 16;
            // 
            // ed_consulta
            // 
            this.ed_consulta.BackColor = System.Drawing.Color.White;
            this.ed_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ed_consulta.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ed_consulta.Location = new System.Drawing.Point(8, 5);
            this.ed_consulta.Multiline = true;
            this.ed_consulta.Name = "ed_consulta";
            this.ed_consulta.PlaceholderText = "Pesquise";
            this.ed_consulta.Size = new System.Drawing.Size(324, 23);
            this.ed_consulta.TabIndex = 16;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(338, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(49, 37);
            this.iconButton1.TabIndex = 15;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_usuarios);
            this.tabControl.Controls.Add(this.tabPage_acessos);
            this.tabControl.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(5, 75);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(914, 418);
            this.tabControl.TabIndex = 20;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_usuarios
            // 
            this.tabPage_usuarios.Controls.Add(this.dataGrid_usuarios);
            this.tabPage_usuarios.Location = new System.Drawing.Point(4, 31);
            this.tabPage_usuarios.Name = "tabPage_usuarios";
            this.tabPage_usuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_usuarios.Size = new System.Drawing.Size(906, 383);
            this.tabPage_usuarios.TabIndex = 0;
            this.tabPage_usuarios.Text = "Usuários";
            this.tabPage_usuarios.UseVisualStyleBackColor = true;
            // 
            // dataGrid_usuarios
            // 
            this.dataGrid_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_usuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_usuarios.Location = new System.Drawing.Point(3, 3);
            this.dataGrid_usuarios.Name = "dataGrid_usuarios";
            this.dataGrid_usuarios.RowTemplate.Height = 25;
            this.dataGrid_usuarios.Size = new System.Drawing.Size(900, 377);
            this.dataGrid_usuarios.TabIndex = 0;
            // 
            // tabPage_acessos
            // 
            this.tabPage_acessos.Controls.Add(this.dataGrid_acessos);
            this.tabPage_acessos.Location = new System.Drawing.Point(4, 31);
            this.tabPage_acessos.Name = "tabPage_acessos";
            this.tabPage_acessos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_acessos.Size = new System.Drawing.Size(906, 383);
            this.tabPage_acessos.TabIndex = 1;
            this.tabPage_acessos.Text = "Acessos";
            this.tabPage_acessos.UseVisualStyleBackColor = true;
            // 
            // dataGrid_acessos
            // 
            this.dataGrid_acessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_acessos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_acessos.Location = new System.Drawing.Point(3, 3);
            this.dataGrid_acessos.Name = "dataGrid_acessos";
            this.dataGrid_acessos.RowTemplate.Height = 25;
            this.dataGrid_acessos.Size = new System.Drawing.Size(900, 377);
            this.dataGrid_acessos.TabIndex = 0;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_usuario.Location = new System.Drawing.Point(9, 496);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(74, 22);
            this.lbl_usuario.TabIndex = 21;
            this.lbl_usuario.Text = "Usuário:";
            // 
            // lbl_nome_usuario
            // 
            this.lbl_nome_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_nome_usuario.AutoSize = true;
            this.lbl_nome_usuario.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_nome_usuario.Location = new System.Drawing.Point(83, 496);
            this.lbl_nome_usuario.Name = "lbl_nome_usuario";
            this.lbl_nome_usuario.Size = new System.Drawing.Size(152, 22);
            this.lbl_nome_usuario.TabIndex = 22;
            this.lbl_nome_usuario.Text = "Roberto de Souza";
            // 
            // FormAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(922, 578);
            this.Controls.Add(this.lbl_nome_usuario);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(863, 402);
            this.Name = "FormAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormAccess_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_usuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_usuarios)).EndInit();
            this.tabPage_acessos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_acessos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox ed_consulta;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TabControl tabControl;
        private TabPage tabPage_usuarios;
        private TabPage tabPage_acessos;
        private DataGridView dataGrid_usuarios;
        private DataGridView dataGrid_acessos;
        private Label lbl_usuario;
        private Label lbl_nome_usuario;
    }
}