using StatHelper.Models;
using StatHelper.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
