﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                AcceptEncodingBuilder acceptEncoding = new AcceptEncodingBuilder();
                acceptEncoding.Add(AcceptEncodingType.Gzip);
                acceptEncoding.Add(AcceptEncodingType.Compress, 0.5f);

                client.DefaultRequestHeaders.Add("Accept-Encoding", acceptEncoding.Build());

                string echo = await client.GetStringAsync(new Uri("http://scooterlabs.com/echo"));

                Console.WriteLine(echo);
            }
        }
    }
}