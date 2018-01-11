using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SeriesBot
{
    internal static class Bot
    {
        public static Api Api { get; set; }

        public static void SetApi(string apiKey)
        {
            Api = new Api(apiKey); //"490656810:AAHWvgxKV3ro_8XbCtbu1ZwHBSLSiThT7Bw");
        }

    }
}
