﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace PizzaBurgerOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Order order = new Order();
            decimal personMoney = 100m;
            bool payed = false;

            int input = 1;
            while (input != 0)
            {
                Console.WriteLine("Choose Menu Option");
                MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList);
                Console.WriteLine("[0] Exit Restaurant");
                Console.WriteLine("Your pick: ");

                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Clear();
                    Console.WriteLine("Choose Menu Option");
                    MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList);
                    Console.WriteLine("[0] Exit Restaurant");
                    Console.WriteLine("You entered an invalid choice");
                    Console.Write("Pick Again ");
                }

                Console.WriteLine("");

                switch (input)
                {
                    case 1:
                        //build burger
                        Burger burger = new Burger();
                        int choice = 1;
                        order.BuildBurgerOrder(order, choice, burger);
                        break;
                    case 2:
                        //build pizza
                        Pizza pizza = new Pizza();
                        choice = 1;
                        order.BuildPizzaOrder(order, choice, pizza);
                        break;
                    case 3:
                        //Extra Items
                        Extra extra = new Extra();
                        int choiceItem = 1;
                        int choiceSize = 1;
                        order.BuildExtraOrder(choiceItem, choiceSize, order, extra);
                        break;
                    case 4:
                        //Checkout
                        Console.WriteLine("\nThank you for eating with us!!\n**** Here is your receipt ****\n");
                        order.ShowBurgerOrder();
                        order.ShowPizzaOrder();
                        order.ShowExtraOrder();
                        order.CheckOut(personMoney);
                        Console.WriteLine("\nCome again!!\n Press 0 to exit....\n");
                        Console.ReadLine();
                        Console.Clear();
                        order.ClearAllOrdersAndList();
                        payed = true;
                        break;
                    default:
                        char oops;
                        if (input == 0 && payed == false && (order.MyBurgers.Count + order.MyExtras.Count + order.MyPizzas.Count) > 0)
                        {
                            Console.WriteLine($"\nOops you forgot to pay, did you mean to Checkout and pay instead? Press Y for yes.");
                            while (!char.TryParse(Console.ReadLine(), out oops))
                            {
                                Console.WriteLine($"\nOops you forgot to pay, did you mean to Checkout and pay instead? Press Y for yes.");
                            }
                            if (oops == 'y' || oops == 'Y')
                            {
                                Console.WriteLine("\nThank you for eating with us!!\n**** Here is your receipt ****\n");
                                order.ShowBurgerOrder();
                                order.ShowPizzaOrder();
                                order.ShowExtraOrder();
                                order.CheckOut(personMoney);
                                Console.WriteLine("\nCome again!!\n Press 0 to exit....\n");
                                Console.ReadLine();
                                Console.Clear();
                                order.ClearAllOrdersAndList();
                                payed = true;
                            }
                            else
                            {
                                input = 0;
                                payed = false;
                                Console.WriteLine($"YOU LEFT WITHOUT PAYING " + order.CheckOut(personMoney).ToString("C") + "\nSHAME ON YOU!!!!!");
                                Console.WriteLine("\n\nPress Enter to Exit Program....");
                                Console.ReadLine();
                                //continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nPress Enter to Exit Program....");
                            Console.ReadLine();
                        }
                        break;
                }
            }

        }
    }
}
