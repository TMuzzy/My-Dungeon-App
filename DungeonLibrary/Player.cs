using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //New classes default to internal. We must make it public in order to access it outside of the project.
    public sealed class Player : Character //This is now a child of Character
        //The sealed keyword indicates that this class cannot be used as a base class for other classes.
        //No more inheritance can occur.
    {
        //fields
        //only need to create fields for the attributes that will have business rules
        //private int _life; - moved to the Character class

        //properties
        //Automatic properties are a shortcut syntax that allows you to create a shortened version of a public property.
        //They have an open getter and setter! The guard is asleep.
        //These automatically create default fields for you at runtime

        //The below properties were moved to Character
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Race CharacterRace { get; set; }

        //You cannot have business rules with automatic properties
        //The below was moved to Character
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        //business rule: life should not be MORE than max life
        //        if (value <= MaxLife) 
        //        {
        //            _life = value;
        //        }
        //        else
        //        {
        //            _life = 1;
        //        }
        //    }
        //}

        //ctor
        //ONLY making a FQCTOR. We do not want to allow a blank to be created. To create a player, you must have information about all attributes.
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            //Since Life depends on MaxLife.... set the value for MaxLife first
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

        //methods
        public override string ToString()
        {
            string description = " ";

            switch (CharacterRace)
            {
                case Race.DragonBorn:
                    description = "DragonBorn";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Butterfly:
                    description = "Butterfly";
                    break;
                case Race.Rouge:
                    description = "Rouge";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.SparklyVampire:
                    description = "SparklyVampire";
                    break;
                case Race.Skeleton:
                    description = "Skeleton";
                    break;
                case Race.Unicorn:
                    description = "Unicorn";
                    break;
                case Race.PumpkinSpice:
                    description = "PumpkinSpice";
                    break;
            }

            return string.Format("----- {0} -----\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon:\n{4}\nBlock: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                description);

        }

        //Overriding the cCalcDamage in player to use their weapons properties of MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //return base.CalcDamage(); this would just return 0

            //create a Random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;

        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

    }
}
