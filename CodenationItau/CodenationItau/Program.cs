using System;
using ConsoleApp1.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        private static IConfigurationRoot Configuration = new SettingsInjection().GetSettings();

        public async void Execute()
        {
            string json;

            //-------------------------------------------------------------------------

            Console.WriteLine("\n\n1 - Iniciando requisição...");


            //request para a api
            //url + token
            var urlGet = Configuration["Routes:RouteGenerateToken"] + Configuration["Token"];
            json = await new HttpRequests(urlGet).Get();


            Console.WriteLine("Resultado: \n");
            Console.WriteLine(json);

            //salva os dados da requisição em um arquivo
            new Files().Save(json);



            //-------------------------------------------------------------------------

            Console.WriteLine("\n\n\n\n2 - Descriptando a frase...");
            Console.WriteLine("Resultado: \n");

            //pega os dados do JSON salvo
            var jsonSaved = new Files().Get();

            //transforma o JSON num objeto de Answer
            var answerDeserialized = JsonConvert.DeserializeObject<Answer>(jsonSaved);

            //decifra a frase contida no JSON
            var phraseDecripted = new CaesarCipher().Decrypt(answerDeserialized.Cifrado, answerDeserialized.NumeroCasas);
            Console.WriteLine(phraseDecripted);

            //atribui a frase decriptada ao objeto...
            answerDeserialized.Decifrado = phraseDecripted;


            //-------------------------------------------------------------------------

            Console.WriteLine("\n\n\n\n3 - Realizando resumo criptográfico");
            Console.WriteLine("Resultado: \n");

            //realiza o resumo criptografico da frase decifrada
            var cryptographicResume = new Sha1().Generate(answerDeserialized.Decifrado);
            Console.WriteLine(cryptographicResume);

            //atribui o resumo criptografico ao objeto...
            answerDeserialized.ResumoCriptografico = cryptographicResume;



            //-------------------------------------------------------------------------
            Console.WriteLine("\n\n\n\n4 - Novo JSON");
            Console.WriteLine("Resultado: \n");

            var newJson = JsonConvert.SerializeObject(answerDeserialized, Formatting.Indented);
            Console.WriteLine(newJson);



            //-------------------------------------------------------------------------
            Console.WriteLine("\n\n\n\n5 - Salvando novo JSON");
            Console.WriteLine("Resultado: \n");

            //salva os dados do novo json no arquivo
            new Files().Save(newJson);

            Console.WriteLine("\nSalvo com sucesso...");



            //-------------------------------------------------------------------------
            Console.WriteLine("\n\n\n\n6 - Enviando arquivo para API do Codenation");
            Console.WriteLine("Resultado: \n");

            var bytesJson = new Files().ConvertFileInBytes();

            //request para a api
            //url + token
            var urlPost = Configuration["Routes:RouteSubmitResponse"] + Configuration["Token"];
            
            new HttpRequests(urlPost).Post(bytesJson);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Iniciando...\n");
                new Program().Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n\n\n\nOcorreu o seguinte erro: \n" + ex.Message.ToString());
            }
            


            Console.ReadKey();
        }
    }
}
