﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {

            TestaGet();
            //TestaPost();
            
        }

        static void TestaMocky()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGet()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:62289/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPost()
        {
            string conteudo = "{\"Produtos\":[{\"Id\":6237,\"Preco\":4000.0,\"Nome\":\"X1\",\"Quantidade\":1},{\"Id\":3467,\"Preco\":60.0,\"Nome\":\"Jogo de esporte\",\"Quantidade\":2}],\"Endereco\":\"Rua Vergueiro 3185, 8 andar, Sao Paulo\",\"Id\":1}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:62289/api/carrinho/");
            request.Method = "POST";
            request.ContentType = "application/json";

            byte[] jsonBytes = Encoding.UTF8.GetBytes(conteudo);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();

        }

    }
}
