using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    class Encounter
    {

        static Random rnd = new Random();

        public static void FirstEncounter()
        {
            Console.WriteLine("The dark figure senses you and lunges at you");
            Console.ReadKey();
            Combat(false, "Maurador", 1, 5);
        }

        public static void PlayerDeath()
        {
           
             MainGame.currentPlayer.health = 0;
             Console.WriteLine("==================GAME OVER====================");
             Console.ReadKey();
             Environment.Exit(0);
           
        }

        public static void Escape()
        {
            Console.WriteLine("\nYou escape successfully!");
            Console.ReadKey();
            MainGame.Shop();
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            
            string n = "";
            int p = 0;
            int h = 0;
            int difficulty = MainGame.currentPlayer.health/2;

            if (random)
            {
                string[] enemyNames = { "Raider", "Maurador", "Wolf" };
                int[] enemyPowers = { 1, 2, 4 };
                int[] enemyHealths = { 2, 4, 6 };
                n = enemyNames[rnd.Next(0, 3)];
                p = enemyPowers[rnd.Next(0, 3)];
                h = enemyHealths[rnd.Next(0, 3)];
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine("Enemy Name: " + n);
                Console.WriteLine("Attack Power: " + p + " | " + "Health: " + h + "\n");
                Console.WriteLine("===========================");
                Console.WriteLine("|| ATTACK (A)  DEFEND (D) || ");
                Console.WriteLine("|| RUN (R)  HEAL(H)       ||");
                Console.WriteLine("===========================\n");
                Console.WriteLine("Potions: " + MainGame.currentPlayer.potions + "  Health: " + MainGame.currentPlayer.health);
                
                if (MainGame.currentPlayer.health <= 0)
                {
                    PlayerDeath();
                }
                else
                {
                    string playerInput = Console.ReadLine();

                    if (playerInput.ToUpper() == "A" || playerInput.ToUpper() == "ATTACK")
                    {
                        Console.WriteLine(MainGame.currentPlayer.name + " darts forward and attacks the " + n);
                        int damage = p - MainGame.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        int attack = rnd.Next(0, MainGame.currentPlayer.weaponValue) + rnd.Next(1, 4);
                        MainGame.currentPlayer.health -= damage;
                        h -= attack;
                        Console.WriteLine("You lost " + damage + " health and dealt " + attack + " damage");
                        if (MainGame.currentPlayer.armorValue > damage)
                        {
                            int armorLost = MainGame.currentPlayer.armorValue - p;
                            Console.WriteLine("You lost " + armorLost + " points of armor");
                            MainGame.currentPlayer.armorValue -= p;
                            
                        }
                    }
                    else if (playerInput.ToUpper() == "D" || playerInput.ToUpper() == "DEFEND")
                    {
                        Console.WriteLine("You brace for an attack as the " + n + " makes a move against you");
                        int damage = (p / 4) - MainGame.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        int attack = rnd.Next(0, MainGame.currentPlayer.weaponValue) / 2;
                        MainGame.currentPlayer.health -= damage;
                        h -= attack;
                        Console.WriteLine("You lost " + damage + " health and dealt " + attack + " damage");
                    }
                    else if (playerInput.ToUpper() == "R" || playerInput.ToUpper() == "RUN")
                    {
                        Console.WriteLine("You make an attempt to escape the battle");
                        if (rnd.Next(0, 2) == 0)
                        {
                            Console.WriteLine("\n as you sprint away you trip and fall, letting " + n + " catch up to you.\n The battle continues.");
                            int damage = (p * 2) - MainGame.currentPlayer.armorValue;
                            if (damage < 0)
                            {
                                damage = 0;
                            }
                            MainGame.currentPlayer.health -= damage;
                            Console.WriteLine("\nYou lost " + damage + " health and failed to escape.");
                            if (MainGame.currentPlayer.health <= 0)
                            {
                                PlayerDeath();
                            }
                            //Console.ReadKey();

                        }
                        else
                        {
                            Escape();
                        }
                    }
                    else if (playerInput.ToUpper() == "H" || playerInput.ToUpper() == "HEAL")
                    {
                        if (MainGame.currentPlayer.potions == 0)
                        {
                            Console.WriteLine("\nYou check your knapsack but find 0 potions.\n" + n + "leaps forward and attacks you while you're distracted");
                            int damage = p - MainGame.currentPlayer.armorValue;
                            if (damage < 0)
                            {
                                damage = 0;
                            }
                            MainGame.currentPlayer.health -= damage;
                            Console.WriteLine("\nYou lost " + damage + " health and failed to heal.");
                        }
                        else
                        {
                            MainGame.currentPlayer.health = MainGame.currentPlayer.health + rnd.Next(1, 6);
                            MainGame.currentPlayer.potions = MainGame.currentPlayer.potions - 1;
                            Console.WriteLine("\nYour health is now at: " + MainGame.currentPlayer.health);
                        }
                        Console.ReadKey();
                    }
                }
                
                Console.ReadKey();
            }
            if (h <= 0)
            {
                if (MainGame.currentPlayer.health <= 0)
                {
                    PlayerDeath();
                }
                else
                {
                    Console.WriteLine("\nYou defeated the " + n);
                    int randomCoin = rnd.Next(1, 11);
                    Player.coins += randomCoin;
                    Console.WriteLine("You found " + randomCoin + " coins!");
                    Console.ReadKey();
                    MainGame.Shop();
                }
            }
            
        }

    }
}
