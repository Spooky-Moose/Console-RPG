using System;
using static RPG.Encounter;


namespace RPG
{
    class MainGame
    {

        public static Player currentPlayer = new Player();
        
        static void Main(string[] args)
        {
            Start();
            //FirstEncounter();
            //Shop();
        }

        static void Start()
        {
            Console.WriteLine("Welcome to C# RPG!\n\nWhat is your name?\n");
            currentPlayer.name = Console.ReadLine();
            if (currentPlayer.name == "")
            {
                Console.Clear();
                Start();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You wake up in your dungeon cell to a loud bang. It appears that your cell door has been blown open.\nYour name is " + currentPlayer.name);
                Console.ReadKey();
                Console.WriteLine("You exit your cell and head into the abandoned hallway, searching for clues as to what is going on.\n");
                Console.ReadKey();
                Console.WriteLine("A dark figure appears in front of you, unaware of your presence.");
                Console.ReadKey();
                FirstEncounter();

            }
            




        }
        public static void Shop()
        {

            bool input = true;

            Console.Clear();
            if (Player.coins == 0)
            {
                Console.WriteLine("Welcome to the shop! Sorry traveler, it seem you have no coins!");
                Console.WriteLine("Coins: " + Player.coins);
                Console.ReadKey();
                //Combat(true, "", 0, 0);
                Exploration.Explore(true, "", 0);
            }
            else
            {
                while (input)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the shop! Safest shop in the land!\n");
                    Console.WriteLine("==============================");
                    Console.WriteLine("1. Potions: " + TheShop.potions + " for 5 coins");
                    Console.WriteLine("2. Shield: " + TheShop.shield + " for 10 coins");
                    Console.WriteLine("3. Weapon Upgrade: " + TheShop.weaponUpgrade + " for 20 coins\n\n");
                    Console.WriteLine("   Your balance = " + Player.coins);
                    Console.WriteLine("==============================");
                    Console.WriteLine("\nHere is my inventory. Select an item you would like! You can also continue if you would like.\n");
                    Console.WriteLine("Type 'CONTINUE' to continue your journey");

                    string playerInput = Console.ReadLine();

                    if (playerInput.ToUpper() == "1" || playerInput.ToUpper() == "POTIONS")
                    {
                        if (Player.coins >= 5)
                        {
                            Player.coins = Player.coins - 5;
                            TheShop.potions = TheShop.potions - 1;
                            currentPlayer.potions++;
                            Console.WriteLine("Potion added!");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        else if (Player.coins < 5)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        if (TheShop.potions == 0)
                        {
                            Console.WriteLine("Out of potions!");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                    }
                    else if (playerInput.ToUpper() == "3" || playerInput.ToUpper() == "WEAPON UPGRADE")
                    {
                        if (Player.coins >= 20)
                        {
                            Player.coins = Player.coins - 20;
                            TheShop.weaponUpgrade = TheShop.weaponUpgrade - 1;
                            currentPlayer.damage += 2;
                            Console.WriteLine("Damage Increased!");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        else if (Player.coins < 20)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        if (TheShop.weaponUpgrade == 0)
                        {
                            Console.WriteLine("Out of upgrades!");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                    }
                    else if (playerInput.ToUpper() == "2" || playerInput.ToUpper() == "SHIELD")
                    {
                        if (Player.coins >= 10)
                        {
                            currentPlayer.armorValue = currentPlayer.armorValue + 5;
                            Console.WriteLine("Armor value upgraded! Armor: " + currentPlayer.armorValue);
                            TheShop.shield--;
                            Player.coins = Player.coins - 10;
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        else if (Player.coins < 10)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }
                        if (TheShop.shield == 0)
                        {
                            Console.WriteLine("Out of shields!");
                            Console.ReadKey();
                            Console.Clear();
                            Shop();
                        }

                    }
                    else if (playerInput.ToUpper() == "CONTINUE")
                    {
                        Console.Clear();
                        input = false;
                        Exploration.Explore(true, "", 0);
                        // Combat(true, "", 0, 0);

                    }

                }
            }
            
        }
       


    }
}
