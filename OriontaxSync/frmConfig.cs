using OriontaxSync.libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriontaxSync
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void lblConfigClose_MouseEnter(object sender, EventArgs e)
        {
            lblConfigClose.BackColor = this.BackColor;
        }

        public void CloseConfig()
        {
            ConfigReader.ReloadConfig();
            this.Dispose(true);
        }

        private void changeConfig(TextBox txt, string section, string config)
        {
            ConfigReader.SetConfigValue(section, config, txt.Text.Trim() );
        }

        private void lblConfigClose_Click(object sender, EventArgs e)
        {
            CloseConfig();
        }

        private void btnCancelCLose_Click(object sender, EventArgs e)
        {
            CloseConfig();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtDbHost.Text = ConfigReader.GetConfigValue("Database", "dbhost").Trim();
            txtDbUser.Text = ConfigReader.GetConfigValue("Database", "dbuser").Trim();
            txtDbPwd.Text = ConfigReader.GetConfigValue("Database", "dbpwd").Trim();
            txtDiaEnvios.Text = ConfigReader.GetConfigValue("Sistema", "dia_envio").Trim();
            txtDiaReceb.Text = ConfigReader.GetConfigValue("Sistema", "dia_recebimento").Trim();
            txtToken.Text = ConfigReader.GetConfigValue("Sistema", "token").Trim();
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            if(txtDiaEnvios.Text == "" || txtDiaReceb.Text == "")
            {
                Funcoes.ErrorMessage("Dias não pode ficar vazio");
                return;
            }
            if (int.Parse(txtDiaEnvios.Text) > 28 || int.Parse(txtDiaEnvios.Text) < 1)
            {
                Funcoes.ErrorMessage("Dias não pode ser maior que 28 ou menor que 1");
                return;
            }
            if (int.Parse(txtDiaReceb.Text) > 28 || int.Parse(txtDiaReceb.Text) < 1)
            {
                Funcoes.ErrorMessage("Dias não pode ser maior que 28 ou menor que 1");
                return;
            }
            ConfigReader.SaveConfig();
            this.Dispose(true);
        }

        private void txtDbHost_TextChanged(object sender, EventArgs e)
        {
            changeConfig((TextBox)sender, "Database", "dbhost");
        }

        private void txtDbUser_TextChanged(object sender, EventArgs e)
        {
            changeConfig((TextBox)sender, "Database", "dbuser");
        }

        private void txtDbPwd_TextChanged(object sender, EventArgs e)
        {
            changeConfig((TextBox)sender, "Database", "dbpwd");
        }

        private void txtDiaReceb_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            string dia = ((TextBox)sender).Text != "" ? int.Parse(((TextBox)sender).Text).ToString() : "";
            txt.Text = dia;
            changeConfig(txt, "Sistema", "dia_recebimento");
        }

        private void txtDiaEnvios_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            string dia = ((TextBox)sender).Text != "" ? int.Parse(((TextBox)sender).Text).ToString() : "";
            txt.Text = dia;
            changeConfig(txt, "Sistema", "dia_envio");
        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {
            changeConfig((TextBox)sender, "Sistema", "token");
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            Connection.TesteConn(txtDbHost.Text, txtDbUser.Text, txtDbPwd.Text);
            Funcoes.ChamaAlerta("Conexão aberta com sucesso");
        }
    }
}
