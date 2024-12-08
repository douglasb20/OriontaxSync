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
            this.Dispose(true);
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
            try
            {

                ToolTip tool = new ToolTip();
                tool.SetToolTip(icoInfo, "Para ter multiplas datas de recebimento, use ponto e virgula(;)\r\nExemplo: 06;10;15");

                // DATABASE
                txtDbHost.Text = ConfigReader.GetConfigValue("dbhost").Trim();
                txtDbUser.Text = ConfigReader.GetConfigValue("dbuser").Trim();
                txtDbPwd.Text = Funcoes.Decrypt(ConfigReader.GetConfigValue("dbpwd")).Trim();

                // SISTEMA
                txtDiaEnvios.Text = ConfigReader.GetConfigValue("dia_envio").Trim();
                txtDiaReceb.Text = ConfigReader.GetConfigValue("dia_recebimento").Trim();
                txtCnpjCliente.Text = ConfigReader.GetConfigValue("cliente_cnpj").Trim();
                txtNomeCliente.Text = ConfigReader.GetConfigValue("cliente_nome").Trim();
                txtToken.Text = Funcoes.Decrypt(ConfigReader.GetConfigValue("token")).Trim();

                // MAIL
                txtMailHost.Text = ConfigReader.GetConfigValue("mail_host").Trim();
                txtMailPort.Text = ConfigReader.GetConfigValue("mail_port").Trim();
                txtMailUser.Text = ConfigReader.GetConfigValue("mail_user").Trim();
                txtMailPass.Text = Funcoes.Decrypt(ConfigReader.GetConfigValue("mail_pwd")).Trim();
                txtMailFrom.Text = ConfigReader.GetConfigValue("mail_from").Trim();
                txtMailSuport.Text = ConfigReader.GetConfigValue("mail_suport").Trim();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            if (txtDiaEnvios.Text == "" || txtDiaReceb.Text == "")
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

            // DATABASE
            ConfigReader.SetConfigValue("dbhost", txtDbHost.Text.Trim());
            ConfigReader.SetConfigValue("dbuser", txtDbUser.Text.Trim());
            ConfigReader.SetConfigValue("dbpwd", Funcoes.Encrypt(txtDbPwd.Text.Trim().ToLower()));

            // SISTEMA
            ConfigReader.SetConfigValue("dia_envio", txtDiaEnvios.Text.Trim());
            ConfigReader.SetConfigValue("dia_recebimento", txtDiaReceb.Text.Trim());
            ConfigReader.SetConfigValue("cliente_cnpj", txtCnpjCliente.Text.Trim());
            ConfigReader.SetConfigValue("ciente_nome", txtNomeCliente.Text.Trim());
            ConfigReader.SetConfigValue("token", Funcoes.Encrypt(txtToken.Text.Trim()));

            // MAIL
            ConfigReader.SetConfigValue("mail_host", txtMailHost.Text.Trim());
            ConfigReader.SetConfigValue("mail_port", txtMailPort.Text.Trim());
            ConfigReader.SetConfigValue("mail_user", txtMailUser.Text.Trim());
            ConfigReader.SetConfigValue("mail_pwd", Funcoes.Encrypt( txtMailPass.Text.Trim().ToLower() ));
            ConfigReader.SetConfigValue("mail_from", txtMailFrom.Text.Trim());
            ConfigReader.SetConfigValue("mail_suport", txtMailSuport.Text.Trim());

            this.Dispose(true);
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            Connection.TesteConn(txtDbHost.Text, txtDbUser.Text, txtDbPwd.Text);
            Funcoes.ChamaAlerta("Conexão aberta com sucesso");
        }
    }
}
