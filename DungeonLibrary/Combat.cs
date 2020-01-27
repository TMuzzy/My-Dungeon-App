using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {

        //This class will not have fields, properties, or any custom ctors as it is just a warehouse for
        //different methods relating to combat

        public static void DoAttack(Character attacker, Character defender)
        {

            //Get a random number from 1-100
            //This random number is simulating a dice roll in the game
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //when the attacker landed a successful attack on the defender
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write the results to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }

        }

        public static void DoBattle(Player player, Monster monster)
        {
            //player gets to attack first
            DoAttack(player, monster);

            //Monster attacks second if they are alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }

        public static void DoMultiBattle(Player player, Monster monster)
        {
            //player gets to attack first
            DoAttack(player, monster);

            //Monster attacks second if they are alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }

    }
}
