using StatHelper.Services;
using StatHelper.ViewModels;
using StatHelper.Views;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace StatHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        private MainWindow _mainWindow;

        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<ItemService>();
            services.AddTransient<ItemsListView>();
            services.AddTransient<ItemListViewModel>();
            services.AddTransient<StatSummaryView>();
            services.AddTransient<StatSummaryViewModel>();
            services.AddTransient<AddItemView>();
            services.AddTransient<AddItemViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            _mainWindow.Show();
        }
    }
}
