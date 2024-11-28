namespace StatHelper.Models
{
    public class Item
    {
        public int Attack { get; private set; }
        public int CritDmg { get; private set; }

        public Equipment Equipment { get; }

        public Item(int attack, int critDmg, Equipment equipment)
        {
            Attack = attack;
            CritDmg = critDmg;
            Equipment = equipment;

        }

        public bool ChangeAttack(string value)
        {
            if (!Equipment.CanChangeAttack())
            {
                return false;
            }
            try
            {
                int atk = int.Parse(value);

                if (atk > Equipment.MaxAttack)
                {
                    Attack = Equipment.MaxAttack;
                    return true;
                }

                Attack = atk;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangeCritDmg(string value)
        {
            if (!Equipment.CanChangeCritDmg())
            {
                return false;
            }
            try
            {
                int cDmg = int.Parse(value);

                if (cDmg > Equipment.MaxCritDmg)
                {
                    CritDmg = Equipment.MaxCritDmg;
                    return true;
                }

                CritDmg = cDmg;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
