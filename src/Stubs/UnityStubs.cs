// Minimal Unity stubs to compile outside game
namespace UnityEngine
{
    public static class Debug
    {
        public static void Log(object message) { }
    }

    public enum SystemLanguage
    {
        ChineseSimplified,
        English
    }
}