using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Caculator_SDD.Infrastructure;
using Caculator_SDD.ViewModels;
using System;

namespace Caculator_SDD
{
    public partial class App : Application
    {
        private Window m_window;

        // 這是讓全域都能存取 DI 容器的屬性
        public IServiceProvider Services { get; private set; }

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // 初始化 DI 容器
            Services = ServiceConfigurator.ConfigureServices();

            m_window = new MainWindow();
            m_window.Activate();
        }
    }
}