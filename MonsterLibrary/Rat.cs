using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //added

namespace MonsterLibrary
{
    public class Rat : Monster
    {

        //Fields

        //Properties

        //CTORs
        public Rat(string name, int monsterQuantity, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, monsterQuantity, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

        }

        //Set some value for a basic monster of this type in the default ctor
        public Rat()
        {
            MaxLife = 4;
            MaxDamage = 1;
            Name = "Small Rat";
            MonsterQuantity = 1;
            Life = 4;
            HitChance = 50;
            Block = 30;
            MinDamage = 1;
            Description = "A puny rat that can be killed in one attack.";
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
