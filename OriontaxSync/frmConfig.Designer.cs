namespace OriontaxSync
{
    partial class frmConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfigClose = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaEnvios = new System.Windows.Forms.TextBox();
            this.txtDiaReceb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.txtDbPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDbUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnCancelCLose = new System.Windows.Forms.Button();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMailUser = new System.Windows.Forms.TextBox();
            this.txtMailPort = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMailHost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMailPass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMailFrom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMailSuport = new System.Windows.Forms.TextBox();
            this.txtCnpjCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.icoInfo = new FontAwesome.Sharp.IconPictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurações";
            // 
            // lblConfigClose
            // 
            this.lblConfigClose.FlatAppearance.BorderSize = 0;
            this.lblConfigClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConfigClose.ForeColor = System.Drawing.Color.White;
            this.lblConfigClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.lblConfigClose.IconColor = System.Drawing.Color.White;
            this.lblConfigClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lblConfigClose.IconSize = 25;
            this.lblConfigClose.Location = new System.Drawing.Point(730, 0);
            this.lblConfigClose.Name = "lblConfigClose";
            this.lblConfigClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.lblConfigClose.Size = new System.Drawing.Size(30, 30);
            this.lblConfigClose.TabIndex = 1;
            this.lblConfigClose.UseVisualStyleBackColor = true;
            this.lblConfigClose.Click += new System.EventHandler(this.lblConfigClose_Click);
            this.lblConfigClose.MouseEnter += new System.EventHandler(this.lblConfigClose_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dia envios";
            // 
            // txtDiaEnvios
            // 
            this.txtDiaEnvios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaEnvios.Location = new System.Drawing.Point(6, 43);
            this.txtDiaEnvios.Name = "txtDiaEnvios";
            this.txtDiaEnvios.Size = new System.Drawing.Size(225, 21);
            this.txtDiaEnvios.TabIndex = 3;
            // 
            // txtDiaReceb
            // 
            this.txtDiaReceb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaReceb.Location = new System.Drawing.Point(6, 87);
            this.txtDiaReceb.Name = "txtDiaReceb";
            this.txtDiaReceb.Size = new System.Drawing.Size(225, 21);
            this.txtDiaReceb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dia recebimentos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestConn);
            this.groupBox1.Controls.Add(this.txtDbPwd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDbUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDbHost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(265, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 304);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Banco de dados";
            // 
            // btnTestConn
            // 
            this.btnTestConn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnTestConn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConn.ForeColor = System.Drawing.Color.White;
            this.btnTestConn.Location = new System.Drawing.Point(45, 210);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(150, 32);
            this.btnTestConn.TabIndex = 28;
            this.btnTestConn.Text = "Testar conexão";
            this.btnTestConn.UseVisualStyleBackColor = false;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // txtDbPwd
            // 
            this.txtDbPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDbPwd.Location = new System.Drawing.Point(8, 131);
            this.txtDbPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtDbPwd.Name = "txtDbPwd";
            this.txtDbPwd.PasswordChar = '*';
            this.txtDbPwd.Size = new System.Drawing.Size(225, 21);
            this.txtDbPwd.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Senha";
            // 
            // txtDbUser
            // 
            this.txtDbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDbUser.Location = new System.Drawing.Point(8, 87);
            this.txtDbUser.Margin = new System.Windows.Forms.Padding(0);
            this.txtDbUser.Name = "txtDbUser";
            this.txtDbUser.Size = new System.Drawing.Size(225, 21);
            this.txtDbUser.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Usuário";
            // 
            // txtDbHost
            // 
            this.txtDbHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDbHost.Location = new System.Drawing.Point(8, 43);
            this.txtDbHost.Margin = new System.Windows.Forms.Padding(0);
            this.txtDbHost.Name = "txtDbHost";
            this.txtDbHost.Size = new System.Drawing.Size(225, 21);
            this.txtDbHost.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Host";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDiaReceb);
            this.groupBox2.Controls.Add(this.icoInfo);
            this.groupBox2.Controls.Add(this.txtNomeCliente);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtCnpjCliente);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtToken);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDiaEnvios);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 304);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sistema";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToken.Location = new System.Drawing.Point(6, 245);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(225, 50);
            this.txtToken.TabIndex = 7;
            // 
            // btnCancelCLose
            // 
            this.btnCancelCLose.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelCLose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelCLose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnCancelCLose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCLose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelCLose.Location = new System.Drawing.Point(233, 410);
            this.btnCancelCLose.Name = "btnCancelCLose";
            this.btnCancelCLose.Size = new System.Drawing.Size(150, 40);
            this.btnCancelCLose.TabIndex = 28;
            this.btnCancelCLose.Text = "Cancelar";
            this.btnCancelCLose.UseVisualStyleBackColor = false;
            this.btnCancelCLose.Click += new System.EventHandler(this.btnCancelCLose_Click);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btSaveConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveConfig.ForeColor = System.Drawing.Color.White;
            this.btSaveConfig.Location = new System.Drawing.Point(406, 410);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(150, 40);
            this.btSaveConfig.TabIndex = 27;
            this.btSaveConfig.Text = "Salvar";
            this.btSaveConfig.UseVisualStyleBackColor = false;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtMailSuport);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtMailFrom);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMailPass);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMailUser);
            this.groupBox3.Controls.Add(this.txtMailPort);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtMailHost);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(515, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 304);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sistema";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Email User";
            // 
            // txtMailUser
            // 
            this.txtMailUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailUser.Location = new System.Drawing.Point(6, 131);
            this.txtMailUser.Name = "txtMailUser";
            this.txtMailUser.Size = new System.Drawing.Size(225, 21);
            this.txtMailUser.TabIndex = 7;
            // 
            // txtMailPort
            // 
            this.txtMailPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailPort.Location = new System.Drawing.Point(6, 87);
            this.txtMailPort.Name = "txtMailPort";
            this.txtMailPort.Size = new System.Drawing.Size(225, 21);
            this.txtMailPort.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "SMTP Host";
            // 
            // txtMailHost
            // 
            this.txtMailHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailHost.Location = new System.Drawing.Point(6, 43);
            this.txtMailHost.Name = "txtMailHost";
            this.txtMailHost.Size = new System.Drawing.Size(225, 21);
            this.txtMailHost.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "SMTP Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Email Senha";
            // 
            // txtMailPass
            // 
            this.txtMailPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailPass.Location = new System.Drawing.Point(6, 176);
            this.txtMailPass.Name = "txtMailPass";
            this.txtMailPass.PasswordChar = '*';
            this.txtMailPass.Size = new System.Drawing.Size(225, 21);
            this.txtMailPass.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Nome Remetente";
            // 
            // txtMailFrom
            // 
            this.txtMailFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailFrom.Location = new System.Drawing.Point(6, 221);
            this.txtMailFrom.Name = "txtMailFrom";
            this.txtMailFrom.Size = new System.Drawing.Size(225, 21);
            this.txtMailFrom.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(6, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Destinatário Log";
            // 
            // txtMailSuport
            // 
            this.txtMailSuport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailSuport.Location = new System.Drawing.Point(6, 268);
            this.txtMailSuport.Name = "txtMailSuport";
            this.txtMailSuport.Size = new System.Drawing.Size(225, 21);
            this.txtMailSuport.TabIndex = 13;
            // 
            // txtCnpjCliente
            // 
            this.txtCnpjCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnpjCliente.Location = new System.Drawing.Point(6, 131);
            this.txtCnpjCliente.Name = "txtCnpjCliente";
            this.txtCnpjCliente.Size = new System.Drawing.Size(225, 21);
            this.txtCnpjCliente.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "CNPJ cliente";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeCliente.Location = new System.Drawing.Point(6, 176);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(225, 21);
            this.txtNomeCliente.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(6, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "Nome cliente";
            // 
            // icoInfo
            // 
            this.icoInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icoInfo.BackColor = System.Drawing.Color.Transparent;
            this.icoInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.icoInfo.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.icoInfo.IconColor = System.Drawing.Color.White;
            this.icoInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoInfo.IconSize = 16;
            this.icoInfo.Location = new System.Drawing.Point(119, 68);
            this.icoInfo.Name = "icoInfo";
            this.icoInfo.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.icoInfo.Size = new System.Drawing.Size(18, 18);
            this.icoInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icoInfo.TabIndex = 29;
            this.icoInfo.TabStop = false;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(763, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelCLose);
            this.Controls.Add(this.btSaveConfig);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblConfigClose);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton lblConfigClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaEnvios;
        private System.Windows.Forms.TextBox txtDiaReceb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDbHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDbPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDbUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnCancelCLose;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMailUser;
        private System.Windows.Forms.TextBox txtMailPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMailHost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMailFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMailPass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMailSuport;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCnpjCliente;
        private System.Windows.Forms.Label label14;
        private FontAwesome.Sharp.IconPictureBox icoInfo;
    }
}