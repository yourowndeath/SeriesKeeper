using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SeriesKeeperCore;
using Telegram.Bot.Types;

namespace SeriesBot
{
    public class WebHookController : ApiController
    {
        public async Task<IHttpActionResult> Post(Update update)
        {
            var message = update.Message;

            Console.WriteLine("Received Message from {0}", message.Chat.Id);
            if (message.Type == MessageType.TextMessage)
            {
                if (message.Text == "/start")
                    await Bot.Api.SendTextMessage(message.Chat.Id, Globals.StartMessage);
                else if (Globals.TodayString.Contains(message.Text))
                {
                    var storage = new TorampStorage().GetToday();
                    if (storage == null || storage.Count == 0)
                        await Bot.Api.SendTextMessage(message.Chat.Id,
                            "К сожалению на сегодня выхода сериалов не планируется.");
                    var result = new StringBuilder();
                    result.Append("На сегодня запланирован выход:\r\n");
                    foreach (var elem in storage)
                        result.Append($"{elem.Parent.Parent.Title} {elem.Title} \r\n");

                    await Bot.Api.SendTextMessage(message.Chat.Id,result.ToString());
                }
                else if (Globals.HelloString.Contains(message.Text))
                    await Bot.Api.SendTextMessage(message.Chat.Id, "И вам не хворать");
            }

            return Ok();
        }
    }
}
