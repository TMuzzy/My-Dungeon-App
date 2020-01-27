using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //make it public
    //The abstract modifier indicates that the thing being modified has an incomplete implementation. The abstract
    //modifier can be used with CLasses, methods, and properties. Use the abstract modifier in a class
    //declaration to indicate that the class is intended to only be a base(parent) class of other classes.
    public abstract class Character
    {

        //Field
        private int _life;

        //Properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                //business rule: life should not be MORE than max life
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = 1;
                }
            }
        }

        //CTORs
        //SInce we dont inherit ctors and we already did a lot of work defining the player FQ CTOR, we will
        //not create any here. We still get the free parameterless ctor by default, but we will be unable to use
        //it since this class is abstract


        //Methods

        //No need to override the ToString() we will never create a character object it will always be Player or Monster.

        //Below are methods we want to be inheritted by player and monster, so we are creating the default version of each
        //instead here that the child classes will use if they do not override them.

        public virtual int CalcBlock()
        {
            //The virtual keyword allows child classes to override this, but they dont have to. If this is NOT overridden in a child
            //class, then the child will use the base functionality below.
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            //starting with just returning 0. We will override the method in Monster and Player.
            return 0;
        }

    }
}
