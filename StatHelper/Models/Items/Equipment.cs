using Ardalis.SmartEnum;
using StatHelper.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatHelper.Models
{
    public sealed class Equipment : SmartEnum<Equipment>
    {
        //TF Information
        public static readonly Equipment TFArmor = new("Nostalgia Armor", 0, Options.TF, 4, ItemType.Armor, 732, 1543);
        public static readonly Equipment TFWeapon = new("Nostalgia Weapon", 1, Options.TF, 1, ItemType.Weapon, 0, 3263);
        public static readonly Equipment TFFat = new("Nostalgia Fat", 2, Options.TF, 2, ItemType.Accessory, 786, 0);
        public static readonly Equipment TFRings = new("Nostalgia Rings", 3, Options.TF, 2, ItemType.Accessory, 465, 1428);


        public ItemType ItemType { get; }
        public Options Option { get; }
        public int Limit { get; }
        public int MaxAttack { get; }
        public int MaxCritDmg { get; }

        public Equipment(string name, int value, Options option, int limit, ItemType type, int maxAttack, int maxCdmg) : base(name, value)
        {
            ItemType = type;
            Option = option;
            Limit = limit;
            MaxAttack = maxAttack;
            MaxCritDmg = maxCdmg;
        }

        public bool CanChangeAttack()
        {
            return MaxAttack != 0;
        }
        public bool CanChangeCritDmg()
        {
            return MaxCritDmg != 0;
        }

    }
}
