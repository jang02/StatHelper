using StatHelper.Models;
using StatHelper.Services;
using System.ComponentModel;
using System.Linq;

namespace StatHelper.ViewModels.Commands
{
    public class AddItemCommand : CommandBase
    {
        private readonly AddItemViewModel _addItemViewModel;
        private readonly ItemService _itemService;
        public AddItemCommand(AddItemViewModel addItemViewModel, ItemService itemService)
        {
            _addItemViewModel = addItemViewModel;
            _itemService = itemService;

            _addItemViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _addItemViewModel.Attack > 0 || _addItemViewModel.CritDmg > 0 && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            if(_itemService.Items.Where(item => item.Equipment.Equals(_addItemViewModel.SelectedItemOption)).Count() >= _addItemViewModel.SelectedItemOption.Limit)
            {
                return;
            }

            int attack = _addItemViewModel.Attack;
            int critDmg = _addItemViewModel.CritDmg;

            if (attack > _addItemViewModel.SelectedItemOption.MaxAttack)
            {
                attack = _addItemViewModel.SelectedItemOption.MaxAttack;
            }
            if (critDmg > _addItemViewModel.SelectedItemOption.MaxCritDmg)
            {
                critDmg = _addItemViewModel.SelectedItemOption.MaxCritDmg;
            }

            _itemService.Items.Add(new ItemViewModel(new Item(
                attack,
                critDmg,
                _addItemViewModel.SelectedItemOption
                )));
        }


        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddItemViewModel.Attack) || e.PropertyName == nameof(AddItemViewModel.CritDmg))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
