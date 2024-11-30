

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace OriontaxSync.libs.DAOSVR
{
    internal class DefaultModel
    {
        public SqlConnection con;
        public string tabela;
        private DataTable queryData;
        public DefaultModel()
        {
            Connect();
        }

        private void Connect()
        {
            try
            {
                con = Connection.con;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void TiraAcentoBD()
        {
            string[] cAcento = { "Á", "À", "Ã", "Â", "É", "Ê", "È", "Í", "Ì", "Î", "Ó", "Ò", "Ô", "Õ", "Ú", "Ù", "Ç", "''" };
            string[] sAcento = { "A", "A", "A", "A", "E", "E", "E", "I", "I", "I", "O", "O", "O", "O", "U", "U", "C", "" };
            SqlCommand cmd = null;
            for (int i = 0; i < cAcento.Length; i++)
            {
                string addDados = String.Format("Update cidades set cid_002=replace(cid_002,'{0}','{1}')", cAcento[i].ToString().ToUpper(), sAcento[i].ToString().ToUpper());
                cmd = new SqlCommand(addDados, con);
                cmd.ExecuteNonQuery();
            }
        }

        protected int ExecuteNonQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                return (int)cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected DataTable ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DefaultModel GetQuery(string where = "", string order = "", string limit = "")
        {
            try
            {
                string query = string.Format("SELECT * FROM {0} ", tabela);
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Concat(query, string.Format(" WHERE {0}", where));
                }

                if (!string.IsNullOrEmpty(order))
                {
                    query = string.Concat(query, string.Format(" ORDER BY {0}", order));
                }

                if (!string.IsNullOrEmpty(limit))
                {
                    query = string.Concat(query, string.Format(" LIMIT {0}", limit));
                }

                queryData = ExecuteQuery(query);
                return this;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataRowCollection ReadAsCollection()
        {
            return queryData.Rows;
        }

        public DataTable ReadAsDataTable()
        {
            return queryData;
        }
        public void InsertMultiplos(List<Dictionary<string, dynamic>> parametros)
        {
            try
            {
                string query = PrepareInsertMultiplo(parametros);
                ExecuteNonQuery(query);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Insert(Dictionary<string, dynamic> parametros)
        {
            try
            {
                string query = PrepareInsert(parametros);
                return ExecuteNonQuery(query);

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Dictionary<string, dynamic> parametros, string where = "")
        {
            if (string.IsNullOrEmpty(where))
            {
                throw new Exception("UPDATE sem WHERE no banco de dados");
            }

            string query = PrepareUpdate(parametros, where);
            ExecuteNonQuery(query);
        }

        private Dictionary<string, string> PrepareParams(Dictionary<string, dynamic> parametros)
        {
            Dictionary<string, string> newParams = new Dictionary<string, string>();

            foreach (KeyValuePair<string, dynamic> el in parametros)
            {
                if (el.Value == null)
                {
                    newParams.Add(el.Key, "null");
                    continue;
                }
                newParams.Add(el.Key, "'" + el.Value.ToString(CultureInfo.InvariantCulture) + "'");
            }

            return newParams;
        }

        private string PrepareInsertMultiplo(List<Dictionary<string, dynamic>> parametros)
        {
            try
            {
                List<Dictionary<string, string>> dados = new List<Dictionary<string, string>>();
                foreach (Dictionary<string, dynamic> el in parametros)
                {
                    dados.Add(PrepareParams(el));
                }
                string[] campos = dados[0].Keys.ToArray();
                string[] valores = { };

                foreach (Dictionary<string, string> item_insert in dados)
                {
                    Array.Resize(ref valores, valores.Length + 1);
                    valores[valores.Length - 1] = "(" + string.Join(",", item_insert.Values) + ")";
                }

                string query = $"INSERT INTO {tabela} ";
                query += $"({string.Join(",", campos)}) VALUES {string.Join(",", valores)}";

                return query;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string PrepareInsert(Dictionary<string, dynamic> parametros)
        {
            try
            {

                Dictionary<string, string> dados = new Dictionary<string, string>();

                dados = PrepareParams(parametros);

                string campos = string.Join(",", dados.Keys.ToArray());
                string valores = string.Join(",", dados.Values.ToArray());

                string query = $"INSERT INTO {tabela} ";
                query += $"({campos}) VALUES ({valores});";

                return query;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string PrepareUpdate(Dictionary<string, dynamic> parametros, string where = "")
        {
            try
            {
                Dictionary<string, string> dados = new Dictionary<string, string>();

                dados = PrepareParams(parametros);
                string[] valores = { };

                foreach (KeyValuePair<string, string> el in dados)
                {
                    Array.Resize(ref valores, valores.Length + 1);
                    valores[valores.Length - 1] = $"{el.Key}={el.Value}";
                }
                string campos = string.Join(",", dados.Keys.ToArray());

                string query = $"UPDATE {tabela} SET";
                query += $" {string.Join(", ", valores)}";

                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Concat(query, $" WHERE {where}");
                }

                return query;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void CloseConnection()
        {
            con.Close();
        }
    }
}
