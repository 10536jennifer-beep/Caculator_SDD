using Microsoft.Extensions.DependencyInjection;
using System;
using Caculator_SDD.Models;     // 引用模型
using Caculator_SDD.ViewModels; // 引用 ViewModel

namespace Caculator_SDD.Infrastructure
{
    public static class ServiceConfigurator
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // ============================================================
            // 👇 關鍵修正：註冊 CalculatorEngine
            // 意思是：當有人要求 ICaculatorEngine 介面時，請提供 CalculatorEngine 實作
            // ============================================================
            services.AddTransient<ICaculatorEngine, CaculatorEngine>();

            // 註冊 ViewModel
            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}