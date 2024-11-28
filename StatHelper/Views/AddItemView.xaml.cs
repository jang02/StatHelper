using StatHelper.ViewModels;
using System.Windows.Controls;

namespace StatHelper.Views
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : Border
    {
        public AddItemView(AddItemViewModel addItemViewModel)
        {
            DataContext = addItemViewModel;
            InitializeComponent();
        }

    }
}
