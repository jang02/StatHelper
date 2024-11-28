using StatHelper.ViewModels;
using System.Windows.Controls;

namespace StatHelper.Views
{
    /// <summary>
    /// Interaction logic for StatSummaryView.xaml
    /// </summary>
    public partial class StatSummaryView : Border
    {
        public StatSummaryView(StatSummaryViewModel statSummaryViewModel)
        {
            DataContext = statSummaryViewModel;
            InitializeComponent();
        }
    }
}
