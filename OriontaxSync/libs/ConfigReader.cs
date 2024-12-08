using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace OriontaxSync.libs
{
    public static class ConfigReader
    {
        #if USE_API_TEST
        public static string base_url = @"https://oriontax.f5sys.com.br/api/v1/test";
        #else
        public static string base_url = @"https://oriontax.f5sys.com.br/api/v1/";
        #endif

        public static string caminho = Path.GetDirectoryName(Application.ExecutablePath);
        public static string fileDB = "config.db";
        public static string pathDB = Path.Combine(caminho, fileDB);
        public static string connectionString = $"Data Source={pathDB}";
        public static SQLiteConnection con;

        public static void Connect()
        {
            bool newDB = false;

            if (!File.Exists(pathDB))
            {
                newDB = true;
                SQLiteConnection.CreateFile(pathDB);
            }

            con = new SQLiteConnection(connectionString);
            con.Open();

            if (newDB)
            {

                // Criar tabela
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS config (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    key TEXT NOT NULL,
                    value TEXT NOT NULL
                );";
                using (var createTableCmd = new SQLiteCommand(createTableQuery, con))
                {
                    createTableCmd.ExecuteNonQuery();
                    Console.WriteLine("Tabela criada ou já existente.");
                }

                string createValues = @"
                    insert into config(key, value) 
                    values('dbhost', '127.0.0.1'),
                    ('dbpwd', 'dbpwd'),
                    ('dbuser', 'sa'),
                    ('dia_envio', '28'),
                    ('dia_recebimento', '06'),
                    ('token', 'b22e5ab4-f278-49ff-8f7e-e7a94f726601'),
                    ('ultima_acao', 'Envio'),
                    ('data_acao', '04/12/2024 16:29:18'),
                    ('mail_host', ''),
                    ('mail_port', '587'),
                    ('mail_user', ''),
                    ('mail_pwd', ''),
                    ('mail_from', '');
                    
                ";
                using (var createConfigValues = new SQLiteCommand(createValues, con))
                {
                    createConfigValues.ExecuteNonQuery();
                    Console.WriteLine("Configs definidos.");
                }
            }

        }

        public static void SetConfigValue(string key, string value)
        {
            //config.SetValue(section, key, value);
            SQLiteCommand cmd = new SQLiteCommand("UPDATE config SET value=@Value WHERE key=@Key", con);
            cmd.Parameters.AddWithValue("@Key", key.ToLower());
            cmd.Parameters.AddWithValue("@Value", value);
            cmd.ExecuteNonQuery();
        }

        public static string GetConfigValue(string key)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM config WHERE key=@Key", con);
            cmd.Parameters.AddWithValue("@Key", key);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0]["value"].ToString();
        }
    }
}
