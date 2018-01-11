using System;
using System.ComponentModel;

namespace SeriesKeeperCore
{
    /// <summary>Класс с общими функциями и данными.</summary>
    public class Globals
    {
        /// <summary>Возвращает значение нумератора по описанию.</summary>
        /// <typeparam name="T">Тип нумератора.</typeparam>
        /// <param name="description">Описание нумератора.</param>
        /// <returns>Нумератор.</returns>
        /// <exception cref="InvalidOperationException">Переданный тип не является нумератором.</exception>
        /// <exception cref="ArgumentException">Значение нумератора не найдено.</exception>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidOperationException("Переданный тип не является нумератором");

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Значение нумератора не найдено.", nameof(description));
        }
    }
}
