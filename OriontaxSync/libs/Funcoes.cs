using System;
using System.Configuration;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace OriontaxSync.libs
{
    static class Funcoes
    {
        private const string SecretKey = "9rv7rg9p3ox26vtr1i91p4j57gp5d6ja";
        private const string SecretIv = "l0mticdy4rm9l472jstnfolseud929j4";

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

        public static string Encrypt(string plainText)
        {
            try
            {
                byte[] key = GenerateKey(SecretKey);
                byte[] iv = GenerateIV(SecretIv);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = (key);
                    aes.IV = (iv);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                        return Base64UrlEncode(cipherBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                byte[] key = GenerateKey(SecretKey);
                byte[] iv = GenerateIV(SecretIv);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        byte[] cipherBytes = Base64UrlDecode(cipherText);
                        byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                        return Encoding.UTF8.GetString(plainBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private static string Base64UrlEncode(byte[] input)
        {
            string base64 = Convert.ToBase64String(input);
            return base64.Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        private static byte[] Base64UrlDecode(string input)
        {
            string base64 = input.Replace("-", "+").Replace("_", "/");
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        private static byte[] GenerateKey(string secret)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(secret));
            }
        }
        private static byte[] GenerateIV(string secretIv)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] fullHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(secretIv));
                byte[] iv = new byte[16];
                Array.Copy(fullHash, iv, 16); // Pega os primeiros 16 bytes
                return iv;
            }
        }
    }
}
