using StatHelper.Services;
using StatHelper.ViewModels;
using StatHelper.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StatHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ItemService itemService = new ItemService();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(
                    new ItemsListView(new ItemListViewModel(itemService)),
                    new StatSummaryView(new StatSummaryViewModel(itemService)),
                    new AddItemView(new AddItemViewModel(itemService))
                    )
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
