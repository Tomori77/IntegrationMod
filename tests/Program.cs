using System;
using IntegrationMod;

class Program
{
    static int Main()
    {
        try
        {
            // 初始状态
            if (IntegrationService.Initialized) throw new Exception("Service 应为未初始化状态");

            // 初始化
            IntegrationService.Initialize();
            if (!IntegrationService.Initialized) throw new Exception("Service 初始化失败");
            if (!IntegrationService.HasFeature("core")) throw new Exception("默认功能 core 未注册");

            // 注册新功能
            IntegrationService.RegisterFeature("auto_fishing");
            if (!IntegrationService.HasFeature("auto_fishing")) throw new Exception("注册功能失败: auto_fishing");

            // 关闭
            IntegrationService.Shutdown();
            if (IntegrationService.Initialized) throw new Exception("Service 关闭失败");
            if (IntegrationService.Features.Count != 0) throw new Exception("关闭后功能集合应为空");

            Console.WriteLine("所有测试通过 ✅");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"测试失败 ❌: {ex.Message}");
            return 1;
        }
    }
}