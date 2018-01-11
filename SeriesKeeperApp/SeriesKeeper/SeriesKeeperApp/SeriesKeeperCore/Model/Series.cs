using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeriesKeeperCore
{
    /// <summary>Класс сериала.</summary>
    public class Series
    {
        #region Поля
        /// <summary>Регулярное выражение для формата xxxx-xxxx.</summary>
        private const string YearRegex = @"\d{4}";
        #endregion

        #region Конструкторы
        /// <summary>Создает новый экземпляр класса <see cref="Series"/>. </summary>
        /// <param name="title">Наименование сериала.</param>
        /// <param name="years">Год выпуска и год завершения в формате (yyyy-yyyy).</param>
        /// <param name="originalHeadline">Оригинальное название.</param>
        /// <param name="seasonCount">Количество сезонов.</param>
        /// <param name="status">Статус сериала.</param>
        /// <param name="genre">Жанр сериала.</param>
        public Series(string title, string years, string originalHeadline, string seasonCount, string status, string genre,string url)
        {
            Title = title;
            OriginalHeadline = originalHeadline;
            if (int.TryParse(seasonCount, out var count))
                SeasonsCount = count;

            Status = Globals.GetValueFromDescription<SeriesStatus>(status);
            GenreList = genre.Split(',').Select(param=>param.Trim()).ToList();
            Url = url;
            ParseDate(years);
        }
        #endregion

        #region Свойства

        public string Url { get; }
        /// <summary>Возвращает Наименование сериала</summary>
        public string Title { get; }

        /// <summary>Возвращает оригинальное название сериала.</summary>
        public string OriginalHeadline { get; }

        /// <summary>Возвращает количество сезонов.</summary>
        public int SeasonsCount { get; }

        /// <summary>Возвращает статус.</summary>
        public SeriesStatus Status { get; }

        /// <summary>Возвращает список жанров.</summary>
        public IEnumerable<string> GenreList { get; }

        /// <summary>Возвращает год начала сериала.</summary>
        public string StartYear { get; private set; }

        /// <summary>Возвращает год окончания сериала.</summary>
        public string EndYear { get; private set; }

        /// <summary>Возвращает период вещания.</summary>
        public string Duration => $"{StartYear}-{EndYear}";
        #endregion

        #region Методы
        /// <summary>Разбирает дату трансляции сериала.</summary>
        /// <param name="year">Годы трансляции в формате (yyyy-yyyy).</param>
        public void ParseDate(string year)
        {
            var reg = new Regex(YearRegex);
            var res = reg.Matches(year);
            switch (res.Count)
            {
                case 0:
                {
                    StartYear = "?";
                    EndYear = "?";
                    break;
                }

                case 1:
                {
                    StartYear = res[0].Value;
                    EndYear = "?";
                    break;
                }
                case 2:
                {
                    StartYear = res[0].Value;
                    EndYear = res[1].Value;
                    break;
                }
            }
        }
        #endregion
    }
}
