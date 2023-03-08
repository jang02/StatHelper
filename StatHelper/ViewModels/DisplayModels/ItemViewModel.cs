using StatHelper.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace StatHelper.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {

        private readonly Item _item;
        public string Name => _item.Equipment.Name;
        public string Type => _item.Equipment.ItemType.ToString();
        public Equipment Equipment => _item.Equipment;
        public string Attack
        {
            get => _item.Attack.ToString();
            set
            {
                if (_item.ChangeAttack(value))
                {
                    OnPropertyChanged(nameof(MissingAttack));
                    OnPropertyChanged(nameof(MissingDmg));
                }
                else
                {
                    return;
                }
            }
        }
        public string MaxAttack => _item.Equipment.MaxAttack.ToString();
        public string CritDmg
        {
            get => _item.CritDmg.ToString();
            set
            {
                if (_item.ChangeCritDmg(value))
                {
                    OnPropertyChanged(nameof(MissingCritDmg));
                    OnPropertyChanged(nameof(MissingDmg));
                }
                else
                {
                    return;
                }
            }
        }
        public string MaxCritDmg => _item.Equipment.MaxCritDmg.ToString();
        public string MissingAttack
        {
            get
            {
                if (_item.Equipment.ItemType == ItemType.Pet)
                {
                    if (_item.Equipment.MaxAttack == 0)
                    {
                        return "0";
                    }
                    return (Equipment.PetMaxAttack - _item.Attack).ToString();
                }

                return (_item.Equipment.MaxAttack - _item.Attack).ToString();
            }
        }
        public string MissingCritDmg
        {
            get
            {
                if (_item.Equipment.ItemType == ItemType.Pet)
                {
                    if (_item.Equipment.MaxCritDmg == 0)
                    {
                        return "0";
                    }
                    return (Equipment.PetMaxCdmg - _item.CritDmg).ToString();
                }

                return (_item.Equipment.MaxCritDmg - _item.CritDmg).ToString();
            }
        }
        public string MissingDmg
        {
            get
            {
                if (_item.Equipment.ItemType == ItemType.Pet)
                {
                    return ((_item.Equipment.MaxAttack == 0 ? 0 : Equipment.PetMaxAttack - _item.Attack) * 1.8 + (_item.Equipment.MaxCritDmg == 0 ? 0 : Equipment.PetMaxCdmg - _item.CritDmg)).ToString();
                }

                return ((_item.Equipment.MaxAttack - _item.Attack) * 1.8 + (_item.Equipment.MaxCritDmg - _item.CritDmg)).ToString();
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        public ItemViewModel(Item item)
        {
            _item = item;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
