using StatHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatHelper.Services
{
    public class ItemService : ServiceBase
    {

        public readonly ObservableCollection<ItemViewModel> Items;

        public ItemService()
        {
            Items = new ObservableCollection<ItemViewModel>();
        }
    }
}
