using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesKeeperCore
{
    public class SeriesSeason
    {
        public int SeasonNumber { get; }

        public SeriesSeason(int seasonNumber,Series parent)
        {
            SeasonNumber = seasonNumber;
            Episods = new List<SeriesEpisode>();
            Parent = parent;
        }

        public Series Parent { get; }
        public List<SeriesEpisode> Episods { get; }
    }
}
