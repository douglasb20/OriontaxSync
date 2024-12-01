namespace OriontaxSync
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTopBar = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnConfig = new FontAwesome.Sharp.IconButton();
            this.btnSendProd = new FontAwesome.Sharp.IconButton();
            this.btnReceiveProd = new FontAwesome.Sharp.IconButton();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblData = new System.Windows.Forms.Label();
            this.lblAcao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTopBar
            // 
            this.lblTopBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopBar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTopBar.Location = new System.Drawing.Point(0, 0);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Size = new System.Drawing.Size(280, 30);
            this.lblTopBar.TabIndex = 2;
            this.lblTopBar.Text = "label1";
            this.lblTopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 20;
            this.btnClose.Location = new System.Drawing.Point(245, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 18;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(210, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.btnMinimize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 19;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVersion.Location = new System.Drawing.Point(2, 226);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(41, 13);
            this.lblVersion.TabIndex = 20;
            this.lblVersion.Text = "version";
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(113)))), ((int)(((byte)(145)))));
            this.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnConfig.IconColor = System.Drawing.Color.White;
            this.btnConfig.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfig.IconSize = 25;
            this.btnConfig.Location = new System.Drawing.Point(237, 204);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(35, 35);
            this.btnConfig.TabIndex = 21;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnSendProd
            // 
            this.btnSendProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(113)))), ((int)(((byte)(145)))));
            this.btnSendProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnSendProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendProd.ForeColor = System.Drawing.Color.White;
            this.btnSendProd.IconChar = FontAwesome.Sharp.IconChar.CloudUploadAlt;
            this.btnSendProd.IconColor = System.Drawing.Color.White;
            this.btnSendProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSendProd.IconSize = 25;
            this.btnSendProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendProd.Location = new System.Drawing.Point(74, 63);
            this.btnSendProd.Name = "btnSendProd";
            this.btnSendProd.Size = new System.Drawing.Size(140, 30);
            this.btnSendProd.TabIndex = 22;
            this.btnSendProd.Text = "        Enviar Produtos";
            this.btnSendProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendProd.UseVisualStyleBackColor = false;
            this.btnSendProd.Click += new System.EventHandler(this.btnSendProd_Click);
            // 
            // btnReceiveProd
            // 
            this.btnReceiveProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(113)))), ((int)(((byte)(145)))));
            this.btnReceiveProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnReceiveProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveProd.ForeColor = System.Drawing.Color.White;
            this.btnReceiveProd.IconChar = FontAwesome.Sharp.IconChar.CloudDownload;
            this.btnReceiveProd.IconColor = System.Drawing.Color.White;
            this.btnReceiveProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReceiveProd.IconSize = 25;
            this.btnReceiveProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiveProd.Location = new System.Drawing.Point(74, 108);
            this.btnReceiveProd.Name = "btnReceiveProd";
            this.btnReceiveProd.Size = new System.Drawing.Size(140, 30);
            this.btnReceiveProd.TabIndex = 23;
            this.btnReceiveProd.Text = "        Receber Produtos";
            this.btnReceiveProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiveProd.UseVisualStyleBackColor = false;
            this.btnReceiveProd.Click += new System.EventHandler(this.btnReceiveProd_Click);
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.ForeColor = System.Drawing.SystemColors.Control;
            this.lblData.Location = new System.Drawing.Point(71, 159);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(35, 13);
            this.lblData.TabIndex = 24;
            this.lblData.Text = "label1";
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAcao.Location = new System.Drawing.Point(71, 146);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(35, 13);
            this.lblAcao.TabIndex = 25;
            this.lblAcao.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.lblAcao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnReceiveProd);
            this.Controls.Add(this.btnSendProd);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTopBar;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private System.Windows.Forms.Label lblVersion;
        private FontAwesome.Sharp.IconButton btnConfig;
        private FontAwesome.Sharp.IconButton btnSendProd;
        private FontAwesome.Sharp.IconButton btnReceiveProd;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblAcao;
    }
}

