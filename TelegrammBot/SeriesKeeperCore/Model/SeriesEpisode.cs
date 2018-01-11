using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesKeeperCore
{
    public class SeriesEpisode
    {
        public SeriesEpisode(string number, string title, string date,SeriesSeason parent)
        {
            var res = number.Split('x');
            SeasonNumber = int.Parse(res[0]);
            EpisodeNumber = int.Parse(res[1]);
            Title = title;
            if (DateTime.TryParse(date, out var targetDate))
                ReleaseDate = targetDate;
            Parent = parent;
        }

        public int SeasonNumber { get; }

        public int EpisodeNumber { get; }

        public string Title { get; }

        public DateTime ReleaseDate { get; }

        public SeriesSeason Parent { get; }
    }
}
