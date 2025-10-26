using System;
using System.Collections.Generic;

namespace IntegrationMod
{
    /// <summary>
    /// 提供基础整合服务，用于注册和管理功能模块，方便测试。
    /// </summary>
    public static class IntegrationService
    {
        private static readonly HashSet<string> _features = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static bool _initialized = false;

        public static bool Initialized => _initialized;
        public static IReadOnlyCollection<string> Features => _features;

        public static void Initialize()
        {
            _initialized = true;
            // 可在此处注册默认功能模块
            RegisterFeature("core");
        }

        public static void Shutdown()
        {
            _initialized = false;
            _features.Clear();
        }

        public static void RegisterFeature(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name 不能为空", nameof(name));
            _features.Add(name.Trim());
        }

        public static bool HasFeature(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return _features.Contains(name.Trim());
        }
    }
}