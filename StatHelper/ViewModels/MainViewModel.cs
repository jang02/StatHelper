using StatHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
