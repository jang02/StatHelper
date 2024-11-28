using StatHelper.ViewModels;
using System.Windows.Controls;

namespace StatHelper.Views
{
    /// <summary>
    /// Interaction logic for ItemsListView.xaml
    /// </summary>
    public partial class ItemsListView : Border
    {
        public ItemsListView(ItemListViewModel itemListViewModel)
        {
            DataContext = itemListViewModel;
            InitializeComponent();
        }
    }
}
