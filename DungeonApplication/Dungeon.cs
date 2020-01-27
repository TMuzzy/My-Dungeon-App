using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //added
using MonsterLibrary; //added

namespace DungeonApplication
{
    class Dungeon
    {
        static void Main(string[] args)
        {

            Console.Title = "Dungeon of Doom";

            Console.WriteLine("Your journey begins...\n");

            //1. create a player
            //we need to learn about custom classes
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, false);

            Player player = new Player("Leeroy Jenkins", 70, 5, 100, 100, Race.Elf, sword);

            //2. create a loop for the room
            bool exit = false; //COUNTER

            do
            {

                //3. write a method for getting a room description
                Console.WriteLine(GetRoom());

                //4. create a Monster in the room
                //need to learn about creating objects and then randomly select one
                Rabbit rab1 = new Rabbit(); //uses the default ctor which sets the values and creates the baby rabbit
                Rabbit rab2 = new Rabbit("White Rabbit", 1, 25, 25, 50, 20, 2, 8, "That's no ordinary rabbit! Look at the bones", true);
                Goblin g1 = new Goblin(); //uses the default ctor which sets the values and creates the goblin
                Goblin g2 = new Goblin("Blood Thief", 50, 50, 70, 35, 5, 10, "Watch out for this one!");
                Rat rat1 = new Rat(); //uses the default ctor which sets the values and creates the rat

                Monster[] monsters = { rat1, rat1, rat1, rat1, rat1, rab1, rab1, rab1, rab1, rab2, rab2, rab2, g1, g1, g2 };

                //randomly select a monster from the array
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];
                Console.WriteLine("\nIn this room: " + monster.Name);

                //5. create loop for the menu
                bool reload = false; //COUNTER
                do
                {

                    //6. Menu of decisions on that to do next in the game
                    #region MENU

                    Console.WriteLine("\nPlease choose an action\nA) Attack\nR) Run Away\nP) Player Info\nM) Monster Info\nE) Exit");

                    //7. catch the user input

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //8. clear the console AFTER we get the input just to clean up the screen
                    Console.Clear();

                    //9. build out a switch for user choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //TODO 10. handle doing battle
                            //TODO 11. handle if the player wins
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //It's dead
                                //You could put some logic hereto have the player get items, get life back, or something similar due to
                                //defeating the monster.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}\n", monster.Name);
                                Console.ResetColor();
                                //now we need to get a new room with a new monster
                                reload = true;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!!!!!");
                            //TODO 12. monster gets a free attack
                            //TODO 13. handle running away and getting a new room
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); //free attack
                            Console.WriteLine();
                            reload = true; //load new room with a new monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //14. need to ad player info and write to the screen
                            Console.WriteLine(player);
                            //Here would be a good place to tell the user how many monsters(opponents) that they have defeated.
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            //15. need to add monster info and write to the screen
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("No one likes a quitter....");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest again...");
                            break;
                    }

                    #endregion

                    //TODO 16. check the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude...you died!");
                        exit = true;
                    }

                } while (!reload && !exit);

            } while (!exit);//while exit is not true, keep looping

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = 
                {
                    "The room is dark and dusty with the smell of lost souls.",
                    "This chamber served as an armory for some group of creatures.",
                    "The burble of water reaches your ears after you open the door to this room.",
                    "A chill wind blows against you as you open the door. Beyond it, you see that the floor and ceiling are nothing but iron grates.",
                    "This room smells strange, no doubt due to the weird sheets of black slime that drip from cracks in the ceiling and spread across the floor.",
                    "This tiny room holds a curious array of machinery. Winches and levers project from every wall, and chains with handles dangle from the ceiling.",
                    "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it.",
                    "This small room contains several pieces of well-polished wood furniture. Eight ornate, high-backed chairs surround a long oval table, and a side table stands next to the far exit.",
                    "This chamber holds an odd contraption of metal and wood.",
                    "Many small desks with high-backed chairs stand in three long rows in this room. Each desk has an inkwell, book stand, and a partially melted candle in a rusting tin candleholder. Everything is covered with dust."
                };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;

            //return rooms[new Random().Next(rooms.Length)];

        }

    }//end Class
}//end Namespace
