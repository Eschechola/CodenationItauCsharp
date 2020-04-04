using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Utilities
{
    public class HttpRequests
    {
        //injeção de dependência do arquivo de configuração
        private IConfigurationRoot Configuration;
        public string DefaultUrl { get; set; }

        public HttpRequests(string _defaultUrl)
        {
            DefaultUrl = _defaultUrl;
            Configuration = new SettingsInjection().GetSettings();
        }

        public async void Post(byte[] fileBytes)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent("answer");
                    content.Add(new StreamContent(new MemoryStream(fileBytes)), "answer", "answer");

                    //realiza uma requisição POST asincrona para rota padrao:
                    HttpResponseMessage response = await client.PostAsync(DefaultUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(responseContent);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> Get()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //realiza uma requisição POST asincrona para rota padrao:
                    HttpResponseMessage response = await client.GetAsync(DefaultUrl);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    //se a resposta for bem sucedida ele atribui o authID a tabela do banco
                    if (response.IsSuccessStatusCode)
                    {
                        return responseContent;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "";
        }
    }
}
