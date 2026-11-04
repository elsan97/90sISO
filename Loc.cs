using System.Collections.Generic;
public static class Loc
{
    public static bool IsRussian = true;
    public static string Get(string key) => IsRussian ? _ru[key] : _en[key];

    private static Dictionary<string, string> _ru = new Dictionary<string, string> {
        { "Build", "Собрать ISO" }, { "Extract", "Распаковать" }, { "Edit", "Редактировать" },
        { "Write", "Записать на USB" }, { "Mount", "Смонтировать" }, { "About", "О программе" }
    };

    private static Dictionary<string, string> _en = new Dictionary<string, string> {
        { "Build", "Build ISO" }, { "Extract", "Extract" }, { "Edit", "Edit ISO" },
        { "Write", "Write to USB" }, { "Mount", "Mount" }, { "About", "About" }
    };
}