using StatHelper.Views;

namespace StatHelper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ItemsListView itemsListView, StatSummaryView statSummaryView, AddItemView addItemView)
        {
            ItemListView = itemsListView;
            StatSummaryView = statSummaryView;
            AddItemView = addItemView;
        }

        public ItemsListView ItemListView { get; }
        public StatSummaryView StatSummaryView { get;}
        public AddItemView AddItemView { get; }

    }
}
