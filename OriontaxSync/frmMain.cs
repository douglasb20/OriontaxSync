using OriontaxSync.libs;
using System.Collections.Generic;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace OriontaxSync
{
    public partial class frmMain : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        public static Dictionary<string, string> config;
        public static string caminho = Path.GetDirectoryName(Application.ExecutablePath);
        public static string fileConfig = "config.conf";
        public static string pathConfig = Path.Combine(caminho, fileConfig);
        public string titulo = ConfigurationManager.AppSettings["appTitle"];
        private void InitializeSystray()
        {
            // Criar o ícone de notificação
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); // Substitua pelo caminho do seu ícone
            notifyIcon.Visible = false;
            notifyIcon.Text = titulo + " | OrintaxSync";

            // Criar o menu de contexto para o ícone
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Abrir", null, ShowMainForm);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("Sair", null, ExitApp);

            // Atribuir o menu de contexto ao ícone
            notifyIcon.ContextMenuStrip = contextMenu;

            // Evento de click no ícone para restaurar a janela
            notifyIcon.DoubleClick += (sender, e) => ShowMainForm(sender, e);
        }

        // Mostrar o formulário principal novamente
        private void ShowMainForm(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; // Restaura o estado da janela
            notifyIcon.Visible = false;
        }

        // Sobrescrever o evento de fechamento do formulário
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Impede o fechamento do formulário
                this.Hide(); // Oculta a janela
            }

            base.OnFormClosing(e);
        }

        // Fechar o aplicativo
        private void ExitApp(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // Remove o ícone do tray
            Application.Exit();
        }
        public frmMain()
        {
            InitializeComponent();
            InitializeSystray();
            this.Paint += new PaintEventHandler(Element_Paint);
        }

        private void Element_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.StartFigure();

            forma.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
            forma.AddLine(20, 0, this.Width - 20, 0);
            forma.AddArc(new Rectangle(this.Width - 20, 0, 20, 20), -90, 90);
            forma.AddLine(this.Width, 20, this.Width, this.Height - 20);
            forma.AddArc(new Rectangle(this.Width - 20, this.Height - 20, 20, 20), 0, 90);
            forma.AddLine(this.Width - 20, this.Height, 20, this.Height);
            forma.AddArc(new Rectangle(0, this.Height - 20, 20, 20), 90, 90);
            forma.CloseFigure();
            this.Region = new Region(forma);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigReader.LoadConfig(pathConfig);
                lblTopBar.Text = "  " + titulo + " | OrintaxSync";
                this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                lblVersion.Text = "Version: " + Application.ProductVersion.ToString();
                tmr.Start();
                string horaAtual = DateTime.Now.ToString("HH:mm:ss");
                lblAcao.Text = "Últ. ação: " + ConfigReader.GetConfigValue("Log", "ultima_acao");
                lblData.Text = "Data ação: " + ConfigReader.GetConfigValue("Log", "data_acao");

            }
            catch (Exception ex)
            {
                if (Funcoes.ErrorMessage(ex.Message) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

        }

        private void lblTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            Funcoes.moverForm(this);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = this.BackColor;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = this.BackColor;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon.Visible = false; // Remove o ícone do tray quando o aplicativo for fechado
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            //string horaAtual = DateTime.Now.ToString("HH:mm:ss");
            //lblData.Text = horaAtual;
        }

        private void btnSendProd_Click(object sender, EventArgs e)
        {
            string dataUltAcao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ConfigReader.SetConfigValue("Log", "data_acao", dataUltAcao);
            ConfigReader.SaveConfig();
            lblAcao.Text = "Últ. ação: " + ConfigReader.GetConfigValue("Log", "ultima_acao");
            lblData.Text = "Data ação: " + dataUltAcao;
            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.ShowDialog();
        }
    }
}
