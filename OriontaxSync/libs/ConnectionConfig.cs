using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriontaxSync.libs
{
    internal class ConnectionConfig
    {
        public static string caminho = Path.GetDirectoryName(Application.ExecutablePath);
        public static string fileConfig = "config.db";
        public static string pathConfig = Path.Combine(caminho, fileConfig);
        public static void Connect()
        {

        }
    }
}
