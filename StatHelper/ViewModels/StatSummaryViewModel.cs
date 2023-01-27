using StatHelper.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StatHelper.ViewModels
{
    public class StatSummaryViewModel : ViewModelBase
    {

        private readonly ObservableCollection<ItemViewModel> _items;
        
        public int MissingAttack
        {
            get
            {
                return _items.Sum(item => Int32.Parse(item.MissingAttack));
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
                return _items.Sum(item => Int32.Parse(item.MissingCritDmg));
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
                return _items.Sum(item => Double.Parse(item.MissingDmg));
            }
            set
            {
                return;
            }
        }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }


        public StatSummaryViewModel(ItemService itemService)
        {
            _items = itemService.Items;
            _items.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedMethod);

            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri("pack://application:,,,/StatHelper;component/Images/image.png");
            bmi.EndInit();
            _image = bmi;

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
