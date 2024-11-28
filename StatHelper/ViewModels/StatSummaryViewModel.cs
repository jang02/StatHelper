using StatHelper.Services;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace StatHelper.ViewModels
{
    public class StatSummaryViewModel : ViewModelBase
    {

        private readonly ItemService _itemService;
        
        public int MissingAttack
        {
            get
            {
                return _itemService.Items.Sum(item => Int32.Parse(item.MissingAttack));
            }
            set
            {
                return;
            }
        }
        public int MissingCritDmg
        {
            get
            {
                return _itemService.Items.Sum(item => Int32.Parse(item.MissingCritDmg));
            }
            set
            {
                return;
            }
        }
        public double MissingDmg
        {
            get
            {
                return _itemService.Items.Sum(item => Double.Parse(item.MissingDmg));
            }
            set
            {
                return;
            }
        }
        public StatSummaryViewModel(ItemService itemService)
        {
            _itemService = itemService;
            itemService.Items.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedMethod);

            foreach (ItemViewModel item in _itemService.Items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }

        }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(MissingAttack));
            OnPropertyChanged(nameof(MissingCritDmg));
            OnPropertyChanged(nameof(MissingDmg));

            if (e.NewItems == null)
            {
                return;
            }

            foreach (ItemViewModel item in e.NewItems)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }

        }

        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(MissingAttack));
            OnPropertyChanged(nameof(MissingCritDmg));
            OnPropertyChanged(nameof(MissingDmg));
        }
    }


}
