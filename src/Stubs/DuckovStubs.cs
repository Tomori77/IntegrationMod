// Minimal stubs to allow building without Duckov installed
namespace Duckov.Modding
{
    // Placeholder for legacy behaviour-based loader
    public class ModBehaviour { }
    // Placeholder for class-based loader
    public class Mod { }
}

namespace SodaCraft.Localizations
{
    public static class LocalizationManager
    {
        public static System.Action<UnityEngine.SystemLanguage>? OnSetLanguage;
        public static void SetOverrideText(string key, string value) { }
    }
}

namespace ItemStatsSystem
{
    public class Item { }
}