using App1.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App1.Service
{
    public class ViaCepService
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string content = wc.DownloadString(NovoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(content);
            
            if (endereco.cep == null) return null;

            return endereco;
        }
    }
}
