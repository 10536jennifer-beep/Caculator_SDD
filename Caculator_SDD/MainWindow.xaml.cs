using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Caculator_SDD.ViewModels;

namespace Caculator_SDD
{
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();

            // ±q App ¨ú±o ViewModel
            ViewModel = ((App)Application.Current).Services.GetRequiredService<MainViewModel>();
        }
    }
}