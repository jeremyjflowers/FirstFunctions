using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _GameOver;
        string _playerName = "";
        int _damage = 7;
        int _level = 1;
        //Initialize input value
        char input = ' ';
        void OpenMainMenu()
        {
            //Loops until valid input is found
            while (input != '1')
            {
                //Clears previous text
                Console.Clear();
                //Asks for player's name
                Console.WriteLine("Please give us your name.");
                _playerName = Console.ReadLine();
                //Confirms player's choice and gives them the option to change if neccesary
                Console.WriteLine("Are you sure you want this name, " + _playerName + "?");
                input = GetInput("Yes", "No");
                if (input == '2')
                {
                    Console.WriteLine("No wonder your parents didn't love you. Your name is terrible.");
                    Console.ReadLine();
                }
            }
        }

        void Explore()
        {
            Console.WriteLine("You have approached a fork in the road.");
            input = GetInput("Go Left", "Go Right");
            if (input != '1')
            {
                Console.WriteLine("You head left and is immediatley attacked by a giant rock.");
                _GameOver = true;
            }
            else
            {
                Console.WriteLine("You head right and arrived at your destination shortly after.");
                _GameOver = true;
            }
        }

        void ViewStats(string _playerName, int _damage, int _level)
        {
            Console.WriteLine(_playerName);
            Console.WriteLine(_damage);
            Console.WriteLine(_level);
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
        }

        char GetInput(string option1, string option2)
        {
            //Loops until a valid input is recieved
            while(input != '1' && input != '2')
            {
                //Dispalys options
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. View Stats");
                Console.Write("> ");
                //Get input from player
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if(input == '3')
                {
                    ViewStats();
                }
            }
            //Returns input recieved from the player
            return input;
        }

        //Run the game
        public void Run()
        {
            Start();

            while(_GameOver == false)
            {
                Update();
            }

            End();
        }

        //Used for variables that are performed once when the game begins
        public void Start()
        {
            OpenMainMenu();
            Console.WriteLine("\nGreetings " + _playerName + " Welcome to the World of God!");
            Console.WriteLine();
        }

        //Used for repeating game logic
        public void Update()
        {
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("NOW, WELCOME TO HELL!!!!!!!");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
