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
        //AOV Information
        public static readonly Equipment AOVWeapon = new("Disorders Weapon", 0, Options.AOV, 1, ItemType.Weapon, 0, 1576);
        public static readonly Equipment AOVArmor = new("Disorders Armor", 1, Options.AOV, 4, ItemType.Armor, 149, 571);
        public static readonly Equipment AOVEarringsAndPendant = new ("Disorders Earrings/Pendant", 2, Options.AOV, 2, ItemType.Accessory, 306, 0);
        public static readonly Equipment AOVRings = new ("Disorders Rings", 3, Options.AOV, 2, ItemType.Accessory, 181, 381);

        //HH Information
        public static readonly Equipment HHWeapon = new ("Primacy Weapon", 10, Options.HH, 1, ItemType.Weapon, 0, 1576);
        public static readonly Equipment HHArmor = new ("Primacy Armor", 11, Options.HH, 4, ItemType.Armor, 156, 599);
        public static readonly Equipment HHEarringsAndPendant = new ("Primacy Earrings/Pendant", 12, Options.HH, 2, ItemType.Accessory, 306, 0);
        public static readonly Equipment HHRings = new ("Primacy Rings", 13, Options.HH, 2, ItemType.Accessory, 181, 381);

        //LF Information
        public static readonly Equipment LFWeapon = new ("Twilight Weapon", 20, Options.LF, 1, ItemType.Weapon, 0, 1743);
        public static readonly Equipment LFArmor = new ("Twilight Armor", 21, Options.LF, 4, ItemType.Armor, 198, 659);
        public static readonly Equipment LFEarringsAndPendant = new ("Twilight Earrings/Pendant", 22, Options.LF, 2, ItemType.Accessory, 321, 0);
        public static readonly Equipment LFRings = new ("Twilight Rings", 23, Options.LF, 2, ItemType.Accessory, 190, 694);

        //VS Information
        public static readonly Equipment VSWeapon = new ("Pale Ashes Weapon", 30, Options.VS, 1, ItemType.Weapon, 0, 2266);
        public static readonly Equipment VSArmor = new ("Pale Ashes Armor", 31, Options.VS, 4, ItemType.Armor, 396, 989);
        public static readonly Equipment VSEarringsAndPendant = new ("Pale Ashes Earrings/Pendant", 32, Options.VS, 2, ItemType.Accessory, 546, 0);
        public static readonly Equipment VSRings = new ("Pale Ashes Rings", 33, Options.VS, 2, ItemType.Accessory, 323, 1180);

        //BS Information
        public static readonly Equipment BSWeapon = new ("Picaresque Weapon", 40, Options.BS, 1, ItemType.Weapon, 0, 2719);
        public static readonly Equipment BSArmor = new ("Picaresque Armor", 41, Options.BS, 4, ItemType.Armor, 594, 1286);
        public static readonly Equipment BSEarringsAndPendant = new ("Picaresque Earrings/Pendant", 42, Options.BS, 2, ItemType.Accessory, 655, 0);
        public static readonly Equipment BSRings = new ("Picaresque Rings", 43, Options.BS, 2, ItemType.Accessory, 388, 1298);

        //TF Information
        public static readonly Equipment TFWeapon = new("Nostalgia Weapon", 50, Options.TF, 1, ItemType.Weapon, 0, 3263);
        public static readonly Equipment TFArmor = new("Nostalgia Armor", 51, Options.TF, 4, ItemType.Armor, 732, 1543);
        public static readonly Equipment TFEarringAndPendant = new("Nostalgia Earrings/Pendant", 52, Options.TF, 2, ItemType.Accessory, 786, 0);
        public static readonly Equipment TFRings = new("Nostalgia Rings", 53, Options.TF, 2, ItemType.Accessory, 465, 1428);

        //VP Information
        public static readonly Equipment VPWeapon = new("Insidious Weapon", 60, Options.VP, 1, ItemType.Weapon, 0, 3590);
        public static readonly Equipment VPArmor = new ("Insidious Armor", 61, Options.VP, 4, ItemType.Armor, 850, 1650);

        //Familiar Information
        public static readonly Equipment BSWeaponFam = new ("Lvl 76 Weapon Fam", 200, Options.FAMILIAR, 2, ItemType.Familiar, 1000, 500);
        public static readonly Equipment BSTypeAFam = new ("Lvl 76 Type A Fam", 201, Options.FAMILIAR, 4, ItemType.Familiar, 0, 500);
        public static readonly Equipment BSTypeCFam = new ("Lvl 76 Type C Fam", 202, Options.FAMILIAR, 4, ItemType.Familiar, 0, 700);
        public static readonly Equipment VPWeaponFam = new ("Lvl 82 Weapon Fam", 203, Options.FAMILIAR, 2, ItemType.Familiar, 1200, 1500);
        public static readonly Equipment VPTypeAFam = new ("Lvl 82 Type A Fam", 204, Options.FAMILIAR, 4, ItemType.Familiar, 0, 800);
        public static readonly Equipment VPTypeCFam = new ("Lvl 82 Type C Fam", 205, Options.FAMILIAR, 4, ItemType.Familiar, 0, 910);

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
