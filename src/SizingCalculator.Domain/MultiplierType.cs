namespace SizingCalculator.Domain;

public enum MultiplierType
{
    /// <summary>
    /// Нет.
    /// </summary>
    None = 0,

    /// <summary>
    /// Сотня.
    /// </summary>
    Hundred = 1,

    /// <summary>
    /// Тысячя.
    /// </summary>
    Thousand = 2,

    /// <summary>
    /// Миллион.
    /// </summary>
    Million = 3,

    /// <summary>
    /// Миллиард.
    /// </summary>
    Billion = 4,

    /// <summary>
    /// Триллион.
    /// </summary>
    Trillion = 5,
}
