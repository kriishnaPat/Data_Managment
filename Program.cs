﻿using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace Data_Managment
{

    class Program
    {
        public static void Main(string[] args)
        {
        String groceryText = File.ReadAllText(@"C:\Users\k.patel61\Desktop\Data_Managment\data-files\grocery.txt");
        String[] items = Regex.Split(groceryText, @"/");

            while (true){
                usercheck();
                //diplays menu options
                Console.WriteLine(@"

1.Display all of the products
2.Display certain products
3.Select products to add to shopping cart.
4.Remove products from shopping cart.
5.Display shopping cart.
6.Logout
");
            Console.Write("Enter the number for your choice: ");
            int user_choice = Convert.ToInt32(Console.ReadLine());
            if (user_choice == 1){
                Console.WriteLine("Here are all the grocery items availble in store, there prices, and item codes:");
                for (int i = 0; i < items.Length; i++){
                    Console.Write(items[i]);
                }
            } 
            else if (user_choice == 2){
                Console.Write(@"Please enter the product area code of the types of products you are looking for:
                Baked goods: 234
                Dairy: 998
                Fruits/Vegetables: 222
                Seasoning: 345
                Condiments: 565
                Hyigene: 223");
                string category = Console.ReadLine();
                Console.Write(category);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(category) == true){
                        Console.WriteLine(items[i]);
                    }
                }
            }
            else if (user_choice == 3){ 
                Console.Write(@"Please enter the name or product number, for the product you would like to add to your shopping cart: ");
                string want = Console.ReadLine();
                Console.Write(want);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(want) == true){
                        
                    }
                }
            }
            else if (user_choice == 4){
                Console.Write(@"Please enter the name or product number, for the product you would like to remove from your shopping cart: ");
                string remove = Console.ReadLine();
                Console.Write(remove);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(remove) == true){

                    }
                }
            }
            else if (user_choice == 5){
            }
            else if (user_choice == 6){
                break;
            }
            else {
                Console.Write("That was not a valid choice!");
            }
        }

        static void usercheck(){
                List<List<string>> userChoice = new List<List<string>>();
                List<string> userPass = new List<string>();
                Console.WriteLine("Enter 1 if you are a new user, enter 2 if you are an exisiting user: ");
                string user = Console.ReadLine();
                if (user == "1"){
                Console.WriteLine("Enter a username of your choosing : ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter a Password of your choosing: ");
                string password = Console.ReadLine();
                userPass.Add(username);
                userPass.Add(password);
                userChoice.Add(userPass);
                Display(userChoice);
                var options = new JsonSerializerOptions { IncludeFields = true };
                string jsonString = JsonSerializer.Serialize(userChoice, options);
                File.WriteAllText(@"C:\Users\k.patel61\Desktop\Data_Managment\data-files\data.txt", jsonString);
                Console.WriteLine(jsonString);
                string jsonStringFromFile = File.ReadAllText(@"C:\Users\k.patel61\Desktop\Data_Managment\data-files\data2.txt");
                Console.WriteLine(jsonStringFromFile);
                }
                else if (user == "2"){
                Console.WriteLine("Enter Username: ");
                string usernameN = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string passwordN = Console.ReadLine();
                int index = userPass.IndexOf(usernameN);
                    if(userChoice[index].Contains(passwordN) == true){
                        Console.Write($@"Welcome {usernameN} to the grocery store!");
                    }else{
                            Console.WriteLine("Either your username or password is incorrect please try again.");
                        }
                }
        }}
        class Item {
            public string name;
            public string price;
            public string number; 

            public Item(string name, string price, string number) {
            this.name = name;
            this.price = price;
            this.number = number;
    }
            
            public override string ToString() {
            return $"({this.name},{this.price},{this.number})";
        }
        
                static void Display(List<List<string>> list)
            {
                Console.WriteLine("Elements:");
                foreach (var sublist in list)
                {
                    foreach (var value in sublist)
                    {
                        Console.Write(value);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
  }
    }
    }
}