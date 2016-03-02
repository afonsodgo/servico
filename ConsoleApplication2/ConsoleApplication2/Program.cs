using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri uri = new Uri(@"http://api.ima.sp.gov.br/v1/saude?offset=0&limit=10");

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Headers.Add("CLIENT_ID", "yYK6BHZC8FW7");
            webRequest.Headers.Add("ACCESS-TOKEN", "yYK6BHZC8FW7");

            WebResponse response = webRequest.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            String responseData = streamReader.ReadToEnd();

            var resultado = JsonConvert.DeserializeObject<List<Saude>>(responseData);

            foreach (var item in resultado) {

                Console.WriteLine(String.Format("Id: {0}, Local de Atendimento {1} \n", item.ID, item.localAtendimento));

            }


            Console.ReadKey();
        }
    }

    public class Saude
    {

        public string ID { get; set; }
        public string distritoVinculo { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public string localAtendimento { get; set; }
        public string distritoAtendimento { get; set; }
        public string dataAtendimento { get; set; }
        public string codigoTipoAtendimento { get; set; }
        public string descricaoTipoAtendimento { get; set; }
        public string descricaoGrupoAtendimento { get; set; }
        public string codigoGrupoAtendimentoSUS { get; set; }
        public string ocupacaoProfissional { get; set; }
        public string descricaoTipoVinculoSMS { get; set; }
        public string codigoProcedimentoSUS { get; set; }
        public string descricaoProcedimento { get; set; }
        public string codigoAtividadeProfissionalSUS { get; set; }
        public string descricaoAtividadeProfissional { get; set; }
        public string sexo { get; set; }
        public string idade { get; set; }
        public string hora { get; set; }
        public string periodo { get; set; }
        public string dataNascimento { get; set; }
        public string quantidadeRealizada { get; set; }

    }
}
