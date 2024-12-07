using System;
using System.Configuration;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OriontaxSync.libs
{
    static class Funcoes
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void moverForm(Form frm)
        {
            ReleaseCapture();
            SendMessage(frm.Handle, 0x112, 0xf012, 0);
        }

        private static string titulo = ConfigurationManager.AppSettings["appTitle"];

        /// <summary>
        /// Chama um alerta personalizado de erro
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Retorna uma caixa de messagem pré definido</returns>
        public static DialogResult ErrorMessage(string text)
        {
            return MessageBox.Show(text, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Chama um alerta personalizado conforme você define a mensagem e tipo
        /// os tipos são `info`, `question`, `warning` e `error`.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tipo"></param>
        /// <returns>Retorna uma caixa de messagem pre definido</returns>
        public static DialogResult ChamaAlerta(string texto = "", string tipo = "info")
        {
            DialogResult resultado;
            switch (tipo.ToLower())
            {
                case "question":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case "warning":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "error":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            return resultado;

        }

        /// <summary>
        /// Função para adicionar uma máscara específica na string
        /// </summary>
        /// <param name="texto">Texto que irá receber a máscara</param>
        /// <param name="mask"></param>
        /// <returns>Retorna uma string com a máscara definida</returns>
        public static string Mascara(string texto, string mask)
        {
            string ret = "";
            int k = 0;

            for (int i = 0; i <= mask.Length - 1; i++)
            {
                if (mask[i].ToString() == "#")
                {
                    if (!String.IsNullOrEmpty(texto[k].ToString()))
                    {
                        ret += texto[k++].ToString();
                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(mask[i].ToString()))
                    {
                        ret += mask[i].ToString();
                    }

                }
            }

            return ret;
        }

        /// <summary>
        /// Função para tirar acento da string.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Retorna uma string sem os acentos definidos.</returns>
        public static string TiraAcento(string texto)
        {
            try
            {
                texto = texto.Trim();

                if (string.IsNullOrEmpty(texto))
                {
                    return texto;
                }

                texto = texto.ToUpper();
                texto = texto.Replace("Á", "A");
                texto = texto.Replace("À", "A");
                texto = texto.Replace("Ã", "A");
                texto = texto.Replace("Â", "A");
                texto = texto.Replace("É", "E");
                texto = texto.Replace("Ê", "E");
                texto = texto.Replace("È", "E");
                texto = texto.Replace("Í", "I");
                texto = texto.Replace("Ì", "I");
                texto = texto.Replace("Î", "I");
                texto = texto.Replace("Ó", "O");
                texto = texto.Replace("Ò", "O");
                texto = texto.Replace("Ô", "O");
                texto = texto.Replace("Õ", "O");
                texto = texto.Replace("Ú", "U");
                texto = texto.Replace("Ù", "U");
                texto = texto.Replace("Ç", "C");
                texto = texto.Replace("&", "");
                texto = texto.Replace("!", "");
                texto = texto.Replace("*", "");
                texto = texto.Replace(";", "");
                texto = texto.Replace("'", "");

                return texto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal? ConvertToDecimal(object value)
        {
            // Define a cultura invariante (usa ponto como separador decimal)
            var culture = CultureInfo.InvariantCulture;

            if (value == null || (value is string strValue && string.IsNullOrWhiteSpace(strValue)))
                return 0.0M;

            try
            {
                // Se for uma string, tenta converter usando a cultura invariante
                if (value is string str)
                {
                    // Substitui vírgula por ponto para garantir consistência
                    str = str.Replace(",", ".");
                    return decimal.TryParse(str, NumberStyles.Float, culture, out var result) ? result : 0.0M;
                }

                // Se já for decimal, apenas retorna
                if (value is decimal decimalValue)
                {
                    return decimalValue;
                }

                // Tenta converter outros tipos numéricos
                if (value is IConvertible)
                {
                    return Convert.ToDecimal(value, culture);
                }

                return 0.0M;
            }
            catch
            {
                return 0.0M;
            }
        }

    }
}
