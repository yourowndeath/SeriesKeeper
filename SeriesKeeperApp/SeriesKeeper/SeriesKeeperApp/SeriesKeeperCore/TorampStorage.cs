using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace SeriesKeeperCore
{
    /// <inheritdoc />
    /// <summary>Хранилище данных с сайта toramp.com</summary>
    /// <seealso cref="T:SeriesKeeperCore.IStorage" />
    public class TorampStorage : IStorage
    {
        #region Поля
        /// <summary>Основной адрес сайта.</summary>
        private const string Url = "http://www.toramp.com";

        /// <summary>Главная страница сайта.</summary>
        private const string SeriesUrl = "schedule.php";

        /// <summary>Элемент сождержащий информацию о сериях.</summary>
        private const string SeriesList = "schedule-list";

        /// <summary>Класс элемента, содержащего год.</summary>
        private const string YearClass = "year";

        /// <summary>Класс дополнительных страниц.</summary>
        private const string PagesClass = "schedule-ddd";

        private const string PageLinkClass = "page_link";

        /// <summary>Класс элемента, содержащего оригинальное название.</summary>
        private const string HeadLineClass = "original-headline";

        /// <summary>Выражение для обрезки жанра.</summary>
        private const string GenreString = "Жанр:";

        /// <summary>Выражение для обрезки статуса.</summary>
        private const string StatusString = "Статус:";
        #endregion

        #region Методы

        #region IStorage
        /// <inheritdoc />
        public List<Series> GetSeries()
        {
            var html = $"{Url}/{SeriesUrl}";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var result = GetSeriesFromPage(htmlDoc);
            for (var i = 0; i < 131; i++)
                result.AddRange(GetSeriesFromPage(web.Load($"{html}?page={i}")));

            return result;
        }

        /// <inheritdoc />
        public List<Series> GetSeries(int year)
        {
            return GetParametrizeSeries("all", "all", year.ToString());
        }

        /// <inheritdoc />
        public List<Series> GetSeries(GenreType genreType)
        {
            var genreParam = genreType == GenreType.All ? "all" : ((int)genreType).ToString();
            return GetParametrizeSeries(genreParam, "all", "all");
        }

        /// <inheritdoc />
        public List<Series> GetSeries(SeriesStatus seriesStatus)
        {
            var seriesParam = seriesStatus == SeriesStatus.Opened ? "o" : ((int)seriesStatus).ToString();
            return GetParametrizeSeries("all", seriesParam, "all");
        }

        /// <inheritdoc />
        public List<Series> GetSeries(GenreType genreType, SeriesStatus seriesStatus)
        {
            var genreParam = genreType == GenreType.All ? "all" : ((int)genreType).ToString();
            var seriesParam = seriesStatus == SeriesStatus.Opened ? "o" : ((int)seriesStatus).ToString();
            return GetParametrizeSeries(genreParam, seriesParam, "all");
        }

        /// <inheritdoc />
        public List<Series> GetSeries(GenreType genreType, SeriesStatus seriesStatus, int year)
        {
            var genreParam = genreType == GenreType.All ? "all" : ((int)genreType).ToString();
            var seriesParam = seriesStatus == SeriesStatus.Opened ? "o" : ((int)seriesStatus).ToString();
            return GetParametrizeSeries(genreParam, seriesParam, year.ToString());
        }
        #endregion

        /// <summary>Возвращает список сериалов согласно заданным параметрам</summary>
        /// <param name="genre">Жанр.</param>
        /// <param name="status">Статус.</param>
        /// <param name="year">Год выпуска.</param>
        /// <returns>Список сериалов.</returns>
        private static List<Series> GetParametrizeSeries(string genre, string status, string year)
        {
            var html = $"{Url}/{SeriesUrl}";
            var web = new HtmlWeb();
            var serviseUrl = $"{html}?genre={genre}&status={status}&year={year}";
            var htmlDoc = web.Load(serviseUrl);
            var additional = htmlDoc.DocumentNode.SelectNodes($"//div[@class='{PagesClass}']/a[@class='{PageLinkClass}']");
            var result = GetSeriesFromPage(htmlDoc);
            if (additional == null)
                return result;
            foreach (var node in additional)
            {
                var lnk = node.GetAttributeValue("href", "#");
                var doc = web.Load($"{Url}/{lnk}");
                result.AddRange(GetSeriesFromPage(doc));
            }
            return result;
        }

        /// <summary>Парсит сериалы с предоставленной страницы.</summary>
        /// <param name="doc">Страница.</param>
        /// <returns>Список сериалов.</returns>
        private static List<Series> GetSeriesFromPage(HtmlDocument doc)
        {
            var result = new List<Series>();
            var series = doc.DocumentNode.SelectNodes($"//table[@id='{SeriesList}']/tr");
            if (series == null)
                return result;

            foreach (var node in series)
            {
                var url = node.ChildNodes[3].SelectSingleNode("a").GetAttributeValue("href", "#");
                var descriptionNode = node.ChildNodes[5];
                var title = descriptionNode.SelectSingleNode("a").GetAttributeValue("Title", "tst");
                var year = descriptionNode.SelectSingleNode($"span[@class='{YearClass}']").InnerText;
                var originalHeadLine = descriptionNode.SelectSingleNode($"span[@class='{HeadLineClass}']").InnerText;
                var additionalDiv = descriptionNode.SelectSingleNode("div");
                var seasonCount = additionalDiv.ChildNodes[1].SelectSingleNode("a").InnerText;
                var status = additionalDiv.ChildNodes[3].InnerText;
                var genre = additionalDiv.ChildNodes[5].InnerText;
                var reg = new Regex(GenreString);
                genre = reg.Replace(genre, "").Trim();
                reg = new Regex(StatusString);
                status = reg.Replace(status, "").Trim();
                result.Add(new Series(title, year, originalHeadLine, seasonCount, status, genre, url));

            }
            return result;
        }
        #endregion
    }
}
