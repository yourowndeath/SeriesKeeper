using System;
using Microsoft.Owin.Hosting;
using SeriesKeeperCore;

namespace SeriesBot
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // Endpoint musst be configured with netsh:  
            // netsh http add urlacl url=https://+:8443/ user=<username>
            // netsh http add sslcert ipport:0.0.0.0:8443 certhash=3WdBRYSxcxYRpUVbtYAmu_6aTR51reT5eShguMbVTSV appid={89CA23AE-444A-43DD-A1AE-1CED22B056FD}
            using (WebApp.Start<Startup>("http://*:8080/"))
            {
                Bot.SetApi("490656810:AAHWvgxKV3ro_8XbCtbu1ZwHBSLSiThT7Bw");
                // Register WebHook 
                Bot.Api.SetWebhook("https://d4c6e938.ngrok.io:443/WebHook").Wait();

                Console.WriteLine("Server Started");

                // Stop Server after <Enter>
                Console.ReadLine();

                // Unregister WebHook
                Bot.Api.SetWebhook().Wait();
            }
        }
    }
}
