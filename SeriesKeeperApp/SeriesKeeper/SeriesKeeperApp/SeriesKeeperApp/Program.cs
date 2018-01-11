using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesKeeperCore;

namespace SeriesKeeperApp
{
    class Program
    {
         static  void Main(string[] args)
        {
            var st = new TorampStorage();
            var res =st.GetSeries(2007);
            res = st.GetSeries(GenreType.Anime);
            res = st.GetSeries(GenreType.Anime, SeriesStatus.Opened);
            res = st.GetSeries(SeriesStatus.Opened);
            res = st.GetSeries(GenreType.Anime, SeriesStatus.Opened,2008);
            res = st.GetSeries(2008);
        }
    }
}
