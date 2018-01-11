using System.Collections.Generic;

namespace SeriesKeeperCore
{
    /// <summary>Интерфейс хранилища данных.</summary>
    public interface IStorage
    {
        /// <summary>Возвращает все доступные сериалы.</summary>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries();

        /// <summary>Возвращает все доступные сериалы по году выпуска.</summary>
        /// <param name="year">Год выпуска.</param>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries(int year);

        /// <summary>Возвращает все доступные сериалы по жанру.</summary>
        /// <param name="genreType">Жанр.</param>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries(GenreType genreType);

        /// <summary>Возвращает все доступные сериалы по статусу.</summary>
        /// <param name="seriesStatus">Статус.</param>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries(SeriesStatus seriesStatus);

        /// <summary>Возвращает все доступные сериалы по критериям.</summary>
        /// <param name="genreType">Жанр.</param>
        /// <param name="seriesStatus">Статус.</param>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries(GenreType genreType, SeriesStatus seriesStatus);

        /// <summary>Возвращает все доступные сериалы по критериям.</summary>
        /// <param name="genreType">Жанр.</param>
        /// <param name="seriesStatus">Статус.</param>
        /// <param name="year">Год выпуска.</param>
        /// <returns>Список сериалов</returns>
        List<Series> GetSeries(GenreType genreType, SeriesStatus seriesStatus, int year);
    }
}
