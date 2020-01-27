using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {

        //fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Properties
        //properties that have business rules last
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than the MaxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than max and greater than 0, so let it pass
                    _minDamage = value;
                }
                else
                {
                    //tried to set the value outside of the range
                    _minDamage = 1;
                }
            }
        }

        //Constructors
        //create a FQCTOR
        //There will be No default ctor because we do not want somebody to make a blank weapon and then only initialize part of the info.
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have any properties that have business rules that are based off of any OTHER properties set the 'other' properties first
            MaxDamage = maxDamage; //we did this first, because MinDamage business rules depend on MaxDamage
            //having a value
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }
        //Methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit: {3}%\t{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }

    }
}
