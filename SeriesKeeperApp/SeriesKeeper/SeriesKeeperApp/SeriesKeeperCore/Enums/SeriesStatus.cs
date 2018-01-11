using System.ComponentModel;

namespace SeriesKeeperCore
{
    /// <summary>Статус сериала.</summary>
    public enum SeriesStatus
    {
        [Description("Выходит")]
        Opened = 0,

        [Description("Завершен/закрыт")]
        Closed = 1,

        [Description("Решается дальнейшая судьба проекта")]
        ComingUnknown = 3,

        [Description("Вернется зимой")]
        ComingWinter = 4,

        [Description("Вернется весной")]
        ComingSpring = 5,

        [Description("Вернется летом")]
        ComingSummer = 6,

        [Description("Вернется осенью")] 
        ComingAutumn = 7,

        [Description("Вернется «неизвестно»")]
        Unknown = 8
    }
}
