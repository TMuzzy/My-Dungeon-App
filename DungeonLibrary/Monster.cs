using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {

        //Fields
        private int _minDamage;
        private int _monsterQuantity;

        //Properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //Can't be more than the max damage
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        public int MonsterQuantity
        {
            get { return _monsterQuantity; }
            set
            {
                if (value >= 1)
                {
                    _monsterQuantity = value;
                }
                else
                {
                    _monsterQuantity = 1;
                }
            }
        }

        //CTORs
        public Monster() { }

        public Monster(string name,int monsterQuantity, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            //no FQ ctor in the parent, so we have to handle it all here
            //Make sure to set MaxLife and MaxDamage first because other properties depend on them.
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            MonsterQuantity = monsterQuantity;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            Name = name;
            Life = life;
            MaxLife = maxLife;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("\n***************MONSTER**************\n{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\nDescription:\n{6}\n",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }

    }
}
