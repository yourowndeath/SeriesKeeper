using System.ComponentModel;

namespace SeriesKeeperCore
{
    /// <summary>Тип жанра.</summary>
    public enum GenreType
    {
        [Description("Все")]
        All = 0,

        [Description("зарубежные")]
        Foreign = 1,

        [Description("российские")]
        Russian = 2,

        [Description("комедия")]
        Comedy = 3,

        [Description("ситком")]
        Strait = 4,

        [Description("боевик")]
        Action = 5,

        [Description("фантастика")]
        Fantastic = 6,

        [Description("детектив")]
        Detective = 7,

        [Description("криминал")]
        Crime = 8,

        [Description("триллер")]
        Thriller = 9,

        [Description("драма")]
        Drama = 10,

        [Description("мелодрама")]
        Melodrama = 11,

        [Description("фэнтези")]
        Fantasy = 12,

        [Description("приключения")]
        Adventure = 13,

        [Description("мюзикл")]
        Musical = 14,

        [Description("ужасы")]
        Horror = 16,

        [Description("мистика")]
        Mystic = 17,

        [Description("вестерн")]
        Western = 18,

        [Description("ток-шоу")]
        TalkShow = 19,

        [Description("спорт")]
        Sport = 20,

        [Description("мультфильм")]
        Cartoon = 21,

        [Description("биография")]
        Biography = 22,

        [Description("аниме")]
        Anime = 23,

        [Description("документальный")]
        Documentary = 24,

        [Description("семейный")]
        Family = 25,

        [Description("история")]
        History = 26,

        [Description("романтика")]
        Romance = 27,
    }
}
