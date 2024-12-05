using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OriontaxSync.Classes
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log dos detalhes da requisição
            Console.WriteLine("==== Requisição ====");
            Console.WriteLine($"URL: {request.RequestUri}");
            Console.WriteLine($"Método: {request.Method}");

            if (request.Content != null)
            {
                string content = await request.Content.ReadAsStringAsync();
                Console.WriteLine($"Conteúdo: {content}");
            }

            foreach (var header in request.Headers)
            {
                Console.WriteLine($"Header: {header.Key} = {string.Join(", ", header.Value)}");
            }

            // Envia a requisição real e obtém a resposta
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            // Log dos detalhes da resposta
            Console.WriteLine("==== Resposta ====");
            Console.WriteLine($"Status: {response.StatusCode}");
            if (response.Content != null)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Conteúdo da Resposta: {responseContent}");
            }

            return response;
        }
    }
}
