using StatHelper.Models;
using StatHelper.Models.Items;
using StatHelper.Services;
using StatHelper.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace StatHelper.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        //select gear set or familiar
        public IEnumerable<Options> SelectableOptions { get; } = Enum.GetValues(typeof(Options)).Cast<Options>();

        private Options _selectedOption;
        public Options SelectedOption
        {
            get
            {
                return _selectedOption;
            }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
                OnOptionSelectionChanged(value);
            }
        }

        //select actual piece
        public IEnumerable<Equipment> ItemOptions { get; private set; } = Equipment.List.Where(s => s.Option == Options.AoV);
        private Equipment _selectedItemOption;
        public Equipment SelectedItemOption
        {
            get
            {
                return _selectedItemOption;
            }
            set
            {
                _selectedItemOption = value;
                OnPropertyChanged(nameof(SelectedItemOption));
                OnItemSelectionChanged(value);
            }
        }

        public bool IsAttackEnabled { get; private set; } = false;
        private int _attack;
        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                try
                {
                    _attack = value;
                    OnPropertyChanged(nameof(Attack));
                }
                catch
                {
                    return;
                }
            }
        }

        public bool IsCritDmgEnabled { get; private set; } = false;
        private int _critDmg;
        public int CritDmg
        {
            get
            {
                return _critDmg;
            }
            set
            {
                try
                {
                    _critDmg = value;
                    OnPropertyChanged(nameof(CritDmg));
                }
                catch
                {
                    return;
                }
            }
        }
        public ICommand AddCommand { get; }


        public AddItemViewModel(ItemService itemService)
        {
            AddCommand = new AddItemCommand(this, itemService);
        }

        private void OnOptionSelectionChanged(Options option)
        {
            ItemOptions = Equipment.List.Where(s => s.Option == option);
            OnPropertyChanged(nameof(ItemOptions));

            IsAttackEnabled = false;
            IsCritDmgEnabled = false;
            OnPropertyChanged(nameof(IsAttackEnabled));
            OnPropertyChanged(nameof(IsCritDmgEnabled));

            _attack = 0;
            _critDmg = 0;
            OnPropertyChanged(nameof(Attack));
            OnPropertyChanged(nameof(CritDmg));

        }

        private void OnItemSelectionChanged(Equipment equipment)
        {
            if (equipment == null)
            {
                return;
            }

            if (equipment.MaxAttack > 0)
            {
                IsAttackEnabled = true;
            }
            else
            {
                IsAttackEnabled = false;
                _attack = 0;
                OnPropertyChanged(nameof(Attack));
            }
            if (equipment.MaxCritDmg > 0)
            {
                IsCritDmgEnabled = true;
            }
            else
            {
                IsCritDmgEnabled = false;
                _critDmg = 0;
                OnPropertyChanged(nameof(CritDmg));
            }
            OnPropertyChanged(nameof(IsAttackEnabled));
            OnPropertyChanged(nameof(IsCritDmgEnabled));
        }

    }
}
