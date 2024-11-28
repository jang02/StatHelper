using StatHelper.Services;
using System.Collections.ObjectModel;

namespace StatHelper.ViewModels
{
    public class ItemListViewModel : ViewModelBase
    {
        public ObservableCollection<ItemViewModel> Items { get; }

        public ItemListViewModel(ItemService itemService)
        {
            Items = itemService.Items;
            
        }

    }
}
