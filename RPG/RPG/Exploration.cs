using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Exploration
    {
        static Random rnd = new Random();

        public static void Explore(bool random, string setting, int encounter)
        {

            string s = "";
            int e = 0;

            if (random)
            {
                string adventureType = randomAdventure(s);
                int encounterChance = randomEncounter(e);

                if (adventureType == "Dungeon")
                {
                    if (encounterChance >= 3)
                    {
                        dungeonAdventure(true);
                    }
                    else
                    {
                        dungeonAdventure(false);
                    }
                }
                else if (adventureType == "Village")
                {
                    if (encounterChance >= 5)
                    {
                        villageAdventure(true);
                    }
                    else
                    {
                        villageAdventure(false);
                    }
                }
                else if (adventureType == "Plains")
                {
                    if (encounterChance >= 7)
                    {
                        plainsAdventure(true);
                    }
                    else
                    {
                        plainsAdventure(false);
                    }
                }

            }
            else
            {
                s = setting;
                e = encounter;
            }


        }

        public static string randomAdventure(string adventure)
        {

            string[] adventureTypes = { "Dungeon", "Village", "Plains" };
            adventure = adventureTypes[rnd.Next(0, 3)];
            //adventure = "Village";
            return adventure;
        }

        public static int randomEncounter(int encounter)
        {
            encounter += rnd.Next(1, 11);
            //encounter = 2;
            return encounter;

        }

        public static void dungeonAdventure(bool encounter)
        {
            bool input = true;

            if (encounter)
            {
                Console.Clear();
                Console.WriteLine("You enter a dark and ominous dungeon");
                string[] randomContext = { "temple", "prison", "mineshaft" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("From the looks of it, it appears this dungeon was used as a " + r + " long before you discovered it\n");
                Console.ReadKey();

                while (input)
                {

                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();
                    if (playerInput.ToUpper() == "Y")
                    {
                       //input = false;
                        Console.WriteLine("\nWhile looking for valuables you alert yourself to whomever dwells in this " + r);
                        Console.ReadKey();
                        Encounter.Combat(true, "", 0, 0);
                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        //input = false;
                        bool transitionCheck = true;
                        if (transitionCheck)
                        {
                            Console.WriteLine("You exit the dungeon");
                            Console.WriteLine("Would you like to CONTINUE exploring or head to the SHOP?");
                            if (playerInput.ToUpper() == "CONTINUE")
                            {
                                transitionCheck = false;
                                Exploration.Explore(true, "", 0);
                            }
                            else if (playerInput.ToUpper() == "SHOP")
                            {
                                transitionCheck = false;
                                MainGame.Shop();
                            }
                        }
                        
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You enter a dark and ominous dungeon");
                string[] randomContext = { "temple", "prison", "mineshaft" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("From the looks of it, it appears this dungeon was used as a " + r + " long before you discovered it\n");
                Console.ReadKey();

                while (input)
                {
                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();

                    if (playerInput.ToUpper() == "Y")
                    {
                        input = false;
                        Console.WriteLine("While exploring the ruins of what remaind of this " + r + " you came across a chest");
                        int randomCoin = rnd.Next(10, 21);
                        Player.coins += randomCoin;
                        Console.WriteLine("You found " + randomCoin + " coins in the chest!");
                        Console.ReadKey();
                        //restock shop
                        TheShop.potions = 5;
                        TheShop.shield = 1;
                        MainGame.Shop();
                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        input = false;
                        Console.WriteLine("You exit the dungeon, making your way back to a shop");
                        Console.ReadKey();
                        MainGame.Shop();
                    }
                }

            }

        }

        public static void villageAdventure(bool encounter)
        {
            bool input = true;

            if (encounter)
            {
                Console.Clear();
                Console.WriteLine("A village catches your eye in the distance. You decide to head over and attempt to explore it");
                string[] randomContext = { "farming community", "raider stronghold", "ruin" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("Upon closer investigation, you discover that this village is a " + r + "\n");
                Console.ReadKey();

                while (input)
                {

                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();
                    if (playerInput.ToUpper() == "Y")
                    {
                        input = false;
                        Console.WriteLine("\nAs you continue to search this " + r + " its inhabitants leap out and attack");
                        Console.ReadKey();
                        Encounter.Combat(true, "", 0, 0);
                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        input = false;
                        bool transitionCheck = true;
                        if (transitionCheck)
                        {
                            Console.WriteLine("You exit the dungeon");
                            Console.WriteLine("Would you like to CONTINUE exploring or head to the SHOP?");
                            if (playerInput.ToUpper() == "CONTINUE")
                            {
                                transitionCheck = false;
                                Exploration.Explore(true, "", 0);
                            }
                            else if (playerInput.ToUpper() == "SHOP")
                            {
                                transitionCheck = false;
                                MainGame.Shop();
                            }
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("A village catches your eye in the distance. You decide to head over and attempt to explore it");
                string[] randomContext = { "farming community", "raider stronghold", "ruin" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("Upon closer investigation, you discover that this village is a " + r + "\n");
                Console.ReadKey();

                while (input)
                {
                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();

                    if (playerInput.ToUpper() == "Y")
                    {
                        input = false;
                        Console.WriteLine("While exploring the village some inhabitants approach you");
                        int randomCoin = rnd.Next(10, 21);
                        Player.coins += randomCoin;
                        Console.WriteLine("They give you " + randomCoin + " coins!");
                        Console.WriteLine("\nInhabitant: Most people come here to attack, we're glad you came with friendly intentions! " +
                            "Thank you " + MainGame.currentPlayer.name +".");
                        string attackInput = Console.ReadLine();
                        if (attackInput.ToUpper() == "ATTACK")
                        {
                            Encounter.Combat(false, "Villager", 1, 6);
                        }
                        else
                        {
                           // Console.ReadKey();
                            //restock shop
                            TheShop.potions = 5;
                            TheShop.shield = 1;
                            MainGame.Shop();
                        }

                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        input = false;
                        bool transitionCheck = true;
                        if (transitionCheck)
                        {
                            Console.WriteLine("You depart from the village");
                            Console.WriteLine("Would you like to CONTINUE exploring or head to the SHOP?");
                            if (playerInput.ToUpper() == "CONTINUE")
                            {
                                transitionCheck = false;
                                Exploration.Explore(true, "", 0);
                            }
                            else if (playerInput.ToUpper() == "SHOP")
                            {
                                transitionCheck = false;
                                MainGame.Shop();
                            }
                        }
                    }
                }
            }
        }

        public static void plainsAdventure(bool encounter)
        {
            bool input = true;

            if (encounter)
            {
                Console.Clear();
                Console.WriteLine("You begin travelling through a large plains area");
                string[] randomContext = { "camp", "watchtower", "field" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("While traveling through this expanse of land, you see a " + r + " in the distance\n");
                Console.ReadKey();

                while (input)
                {

                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();
                    if (playerInput.ToUpper() == "Y")
                    {
                        input = false;
                        Console.WriteLine("\nYou decide to investigate the " + r + ", only to find out it was an elaborate trap! You are ambushed.");
                        Console.ReadKey();
                        Encounter.Combat(true, "", 0, 0);
                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        input = false;
                        bool transitionCheck = true;
                        if (transitionCheck)
                        {
                            Console.WriteLine("You hastily make your way though the plains");
                            Console.WriteLine("Would you like to CONTINUE exploring or head to the SHOP?");
                            if (playerInput.ToUpper() == "CONTINUE")
                            {
                                transitionCheck = false;
                                Exploration.Explore(true, "", 0);
                            }
                            else if (playerInput.ToUpper() == "SHOP")
                            {
                                transitionCheck = false;
                                MainGame.Shop();
                            }
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You begin travelling through a large plains area");
                string[] randomContext = { "camp", "watchtower", "field" };
                string r = randomContext[rnd.Next(0, 3)];
                Console.WriteLine("While traveling through this expanse of land, you see a " + r + " in the distance\n");
                Console.ReadKey();

                while (input)
                {
                    Console.WriteLine("Continue searching?(Y/N)");
                    string playerInput = Console.ReadLine();
                    Console.Clear();

                    if (playerInput.ToUpper() == "Y")
                    {
                        input = false;
                        Console.WriteLine("In the " + r + " you find a chest full of loot!");
                        int randomCoin = rnd.Next(10, 21);
                        Player.coins += randomCoin;
                        Console.WriteLine("You found " + randomCoin + " coins in the chest!");
                        Console.ReadKey();
                        //restock shop
                        TheShop.potions = 5;
                        TheShop.shield = 1;
                        MainGame.Shop();
                    }
                    else if (playerInput.ToUpper() == "N")
                    {
                        input = false;
                        Console.WriteLine("You make your way through the plains, returning to the shop");
                        Console.ReadKey();
                        MainGame.Shop();
                    }
                }

            }
        }
    }
}

