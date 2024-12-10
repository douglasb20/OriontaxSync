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
        public static ToolTip tool = new ToolTip { ShowAlways = true, InitialDelay = 200 };
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
            this.Close();
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

                if (ConfigReader.GetConfigValue("primeiro_acesso") == "1")
                {
                    btSaveConfig.Enabled = true;
                }
                else
                {
                    this.MouseMove += Form_MouseMove; // Detecta o movimento do mouse
                }
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

            if (txtNomeCliente.Text == string.Empty || txtCnpjCliente.Text == string.Empty)
            {
                Funcoes.ErrorMessage("Obrigatório informar cliente e/ou cnpj nas configurações.");
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
            ConfigReader.SetConfigValue("mail_pwd", Funcoes.Encrypt(txtMailPass.Text.Trim().ToLower()));
            ConfigReader.SetConfigValue("mail_from", txtMailFrom.Text.Trim());
            ConfigReader.SetConfigValue("mail_suport", txtMailSuport.Text.Trim());

            
            if (ConfigReader.GetConfigValue("primeiro_acesso") == "0")
            {
                ConfigReader.SetConfigValue("primeiro_acesso", "1");
                this.DialogResult = DialogResult.OK;
            }
            this.Close();

        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.TesteConn(txtDbHost.Text, txtDbUser.Text, txtDbPwd.Text);
                Funcoes.ChamaAlerta("Conexão aberta com sucesso");
                btSaveConfig.Enabled = true;
            }
            catch (Exception ex)
            {
                Funcoes.ErrorMessage(ex.Message);
                btSaveConfig.Enabled = false;
            }
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            btSaveConfig.Enabled = false;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifica se o mouse está sobre o botão desabilitado
            if (!btSaveConfig.Enabled && btSaveConfig.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                tool.Show("Faça um teste de conexão para habilitar este botão", btSaveConfig, btSaveConfig.Width / 2, btSaveConfig.Height / 2);
            }
            else
            {
                tool.Hide(btSaveConfig); // Oculta o ToolTip quando o mouse não estiver sobre o botão
            }
        }
    }
}
