using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //added

namespace MonsterLibrary
{
    public class Rabbit : Monster
    {

        //Fields

        //Properties
        public bool IsFluffy { get; set; }
        public static int monsterQuantity { get; private set; }

        //CTORs
        public Rabbit(string name,int monsterQuality, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, monsterQuantity, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsFluffy = isFluffy;
        }

        //Set some value for a basic monster of this type in the default ctor
        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            MonsterQuantity = 1;
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny...why would you hurt it!! Bully!!";
            IsFluffy = false;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "\nFluffy" : "\nNot so fluffy...");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;

        }

    }
}
