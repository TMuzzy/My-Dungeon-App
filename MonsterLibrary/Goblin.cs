using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //added

namespace MonsterLibrary
{
    public class Goblin : Monster
    {

        //Fields

        //Properties

        //CTORs
        public Goblin(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

        }

        //Set some value for a basic monster of this type in the default ctor
        public Goblin()
        { 
            MaxLife = 30;
            MaxDamage = 8;
            Name = "Goblin";
            Life = 30;
            HitChance = 60;
            Block = 30;
            MinDamage = 4;
            Description = "Regular goblin. Nothing special.";
        }

        //methods
        public override string ToString()
        {
            return base.ToString();
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }

    }
}
