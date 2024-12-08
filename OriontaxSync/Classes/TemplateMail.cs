using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontaxSync.Classes
{
    internal class TemplateMail
    {
        public static string JsonTemplate(string jsonContent)
        {
            return $@"
            <html>
            <body style='font-family: Courier New, monospace;'>
                <p>Não foi possível encontrar classe de imposto com os seguintes impostos</p>
                <pre>{jsonContent}</pre>
            </body>
            </html>";
        }

        public static string TableTemplate(string title, List<object> items)
        {
            string rows = string.Join("", items.Select(item => $@"
            <tr>
                <td>{item.GetType().GetProperty("codigo")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("descricao")?.GetValue(item)}</td>
                <td>{item.GetType().GetProperty("cfop")?.GetValue(item)}</td>
            </tr>"));

            return $@"
            <html>
            <body>
                <h2>{title}</h2>
                <table border='1' style='border-collapse: collapse; width: 100%;'>
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Descrição</th>
                            <th>CFOP</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows}
                    </tbody>
                </table>
            </body>
            </html>";
        }

        public static string PlainTextTemplate(string message)
        {
            return $@"
            <html>
            <body>
                <p>{message}</p>
            </body>
            </html>";
        }
    }

}
