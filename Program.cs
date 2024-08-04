using System;
using System.Collections.Generic;

namespace CaffeMacs_Test
{
    internal class Program
    {
        private static bool isLoggedIn = false;
        static void LineGeneration()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static void Users(List<Users> users)
        {
            Console.WriteLine("Welcome to CaffeMacs! Since this is a compiled program, you need to register first.");

            Users user = new Users();
            Console.WriteLine("Enter your desired username below:");
            user.users = Console.ReadLine();

            Console.WriteLine("Enter your desired password below:");
            user.password = Console.ReadLine();
            users.Add(user);
        }

        static bool LoginUser(List<Users> users)
        {
            Console.WriteLine("Please log in to CaffeMacs");

            Console.WriteLine("Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.users.Equals(username) && user.password == password)
                {
                    Console.WriteLine("Login successful! Welcome back.");
                    return true;
                }
            }

            Console.WriteLine("Login failed. Incorrect username or password.");
            return false; // Login failed
        }

        static void LogoutUser()
        {
            isLoggedIn = false;
            Console.WriteLine("You have been logged out.");
        }

        static void Cafe_MenuDrinks(List<Drinks> cafe_drinks)
        {
            int drinks_count = 0;

            while (true)
            {
                Console.WriteLine("Add your drinks here");

                Drinks drink = new Drinks();
                Console.WriteLine("Enter your drink item here");
                drink.Drink_Item = Console.ReadLine();

                Console.WriteLine("Enter your drink price here");
                drink.Drink_Price = float.Parse(Console.ReadLine());

                Console.WriteLine("Enter your drink size here");
                drink.Drink_Size = Console.ReadLine();

                Console.WriteLine("Enter your drink variant here");
                drink.Drink_Variant = Console.ReadLine();

                cafe_drinks.Add(drink);
                drinks_count++;


                if (drinks_count >= 3)
                {
                    Console.WriteLine("Would you like to add more drinks?");
                    Console.WriteLine("Y for Yes, N for No.");
                    string add_prompt = Console.ReadLine().ToUpper();

                    if (add_prompt == "N")
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (add_prompt == "Y")
                    {
                        Console.WriteLine("Please continue.");
                        continue;
                    }
                }
            }
        }
        static void Cafe_MenuGoods(List<Goods> goods)
        {

            int goods_count = 0;

            while (true)
            {
                Console.WriteLine("Add your goods here");

                Goods goods1 = new Goods();
                Console.WriteLine("Enter your goodie item here");
                goods1.Goodie_Name = Console.ReadLine();

                Console.WriteLine("Enter your goodie price here");
                goods1.Goodie_Price = float.Parse(Console.ReadLine());

                Console.WriteLine("Enter your drink size here");
                goods1.Goodie_Variant = Console.ReadLine();

                goods.Add(goods1);
                goods_count++;

                if (goods_count >= 3)
                {
                    Console.WriteLine("Would you like to add more goods?");
                    Console.WriteLine("Y for Yes, N for No.");
                    string add_prompt = Console.ReadLine().ToUpper();

                    if (add_prompt == "N")
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (add_prompt == "Y")
                    {
                        Console.WriteLine("Please continue.");
                        continue;
                    }
                }
            }
        }

        static void ViewDrinks(List<Drinks> cafe_drinks)
        {
            if (cafe_drinks.Count == 0)
            {
                Console.WriteLine("No drinks available.");
                return;
            }

            Console.WriteLine("Current drinks:");
            foreach (var drink in cafe_drinks)
            {
                Console.WriteLine($"Item: {drink.Drink_Item}, Price: {drink.Drink_Price}, Size: {drink.Drink_Size}, Variant: {drink.Drink_Variant}");
            }
        }

        static void ViewGoods(List<Goods> goods)
        {
            if (goods.Count == 0)
            {
                Console.WriteLine("No goods available.");
                return;
            }

            Console.WriteLine("Current goods:");
            foreach (var good in goods)
            {
                Console.WriteLine($"Name: {good.Goodie_Name}, Price: {good.Goodie_Price}, Variant: {good.Goodie_Variant}");
            }
        }

        static void ViewDrinks_table(List<Drinks> cafe_drinks)
        {

            if (cafe_drinks.Count == 0)
            {
                Console.WriteLine("No drinks available.");
                return;
            }

            Console.WriteLine("Current drinks:");
            Console.WriteLine($"{"Item",-20} {"Price",-10} {"Size",-10} {"Variant",-15}");
            Console.WriteLine(new string('-', 55)); // Line separator

            foreach (var drink in cafe_drinks)
            {
                Console.WriteLine($"{drink.Drink_Item,-20} {drink.Drink_Price,-10:F2} {drink.Drink_Size,-10} {drink.Drink_Variant,-15}");
            }
        }

        static void ViewGoods_table(List<Goods> goods)
        {
            if (goods.Count == 0)
            {
                Console.WriteLine("No goods available.");
                return;
            }

            Console.WriteLine("Current goods:");
            Console.WriteLine($"{"Name",-20} {"Price",-10} {"Variant",-15}");
            Console.WriteLine(new string('-', 45)); // Line separator

            foreach (var good in goods)
            {
                Console.WriteLine($"{good.Goodie_Name,-20} {good.Goodie_Price,-10:F2} {good.Goodie_Variant,-15}");
            }
        }

        static void TakeOrder(List<Drinks> drinks, List<Goods> goods)
        {
            Console.WriteLine("Enter the orderer's nickname:");
            string nickname = Console.ReadLine();

            Console.WriteLine("Select drinks by their number. Type 'done' when finished.");
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {drinks[i].Drink_Item} - ${drinks[i].Drink_Price}");
            }

            List<Drinks> orderedDrinks = new List<Drinks>();
            while (true)
            {
                Console.WriteLine("Enter the number of the drink to add to the order (or 'done' to finish):");
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;

                if (int.TryParse(input, out int drinkNumber) && drinkNumber > 0 && drinkNumber <= drinks.Count)
                {
                    orderedDrinks.Add(drinks[drinkNumber - 1]);
                    Console.WriteLine($"Added {drinks[drinkNumber - 1].Drink_Item} to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or 'done'.");
                }
            }

            Console.WriteLine("Select goods by their number. Type 'done' when finished.");
            for (int i = 0; i < goods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goods[i].Goodie_Name} - ${goods[i].Goodie_Price}");
            }

            List<Goods> orderedGoods = new List<Goods>();
            while (true)
            {
                Console.WriteLine("Enter the number of the good to add to the order (or 'done' to finish):");
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;

                if (int.TryParse(input, out int goodNumber) && goodNumber > 0 && goodNumber <= goods.Count)
                {
                    orderedGoods.Add(goods[goodNumber - 1]);
                    Console.WriteLine($"Added {goods[goodNumber - 1].Goodie_Name} to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or 'done'.");
                }
            }

            // Calculate total amount
            float totalAmount = 0;
            foreach (var drink in orderedDrinks)
            {
                totalAmount += drink.Drink_Price;
            }

            foreach (var good in orderedGoods)
            {
                totalAmount += good.Goodie_Price;
            }

            Console.WriteLine($"Order Summary for {nickname}:");
            Console.WriteLine("Drinks:");
            foreach (var drink in orderedDrinks)
            {
                Console.WriteLine($"{drink.Drink_Item} - ${drink.Drink_Price}");
            }

            Console.WriteLine("Goods:");
            foreach (var good in orderedGoods)
            {
                Console.WriteLine($"{good.Goodie_Name} - ${good.Goodie_Price}");
            }

            Console.WriteLine($"Total Amount: ${totalAmount:F2}");

            // Payment process
            float payment = 0;
            while (true)
            {
                Console.WriteLine("Enter the payment amount:");
                if (float.TryParse(Console.ReadLine(), out payment) && payment >= totalAmount)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid payment amount. It must be a number and at least the total amount.");
                }
            }

            float change = payment - totalAmount;
            Console.WriteLine($"Payment: ${payment:F2}");
            Console.WriteLine($"Change: ${change:F2}");
            Console.WriteLine("Thank you!");
        }


        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            List<Drinks> drinks = new List<Drinks>();
            List<Goods> goods = new List<Goods>();
            while (true)
            {
                Console.WriteLine("Welcome to CaffeMacs! What would you like to do?");
                LineGeneration();
                Console.WriteLine("1. Create a system account.");
                Console.WriteLine("2. Log in to the system.");
                Console.WriteLine("3. View/add inventory items.");
                Console.WriteLine("4. Take the customer order");
                Console.WriteLine("5. Exit the app");
                LineGeneration();

                string cafe_choice = Console.ReadLine();

                switch (cafe_choice)
                {
                    case "1":
                        Users(users);
                        break;

                    case "2":
                        LoginUser(users);
                        break;

                    case "3":
                        Console.WriteLine("Would you want to add items or view them?");
                        Console.WriteLine("Type 'view' or 'add' below:");
                        string add_view = Console.ReadLine();
                        switch (add_view)
                        {
                            case "view" or "View":
                                Console.WriteLine("Type 'drinks' to view drinks or 'goods' to view goods:");
                                string view_type = Console.ReadLine().ToLower();
                                if (view_type == "drinks")
                                {
                                    ViewDrinks(drinks);
                                }
                                else if (view_type == "goods")
                                {
                                    ViewGoods(goods);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid option.");
                                }
                                break;

                            case "add" or "add":
                                Cafe_MenuDrinks(drinks);
                                Cafe_MenuGoods(goods);
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("This functionality is under testing.");
                        ViewDrinks_table(drinks);
                        ViewGoods_table(goods);
                        TakeOrder(drinks, goods);
                        continue;

                    case "5":
                        LogoutUser();
                        return;
                }
            }
        }
    }
}