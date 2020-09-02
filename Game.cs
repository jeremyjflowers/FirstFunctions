using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _GameOver;
        string name = "";
        int playerHealth = 100;
        int damage = 12;
        //Initialize input value
        char input = ' ';

        void RequestName(ref string name)
        {
            input = ' ';
            //Asks for player's name
            Console.WriteLine("Please give us your name.");
            name = Console.ReadLine();
            //Confirms player's choice and gives them the option to change if neccesary
            input = GetInput("Yes", "No", "Are you sure this is your name " + name + "?");
            if (input == '1')
            {
                return;
            }
            else if (input == '2')
            {
                Console.WriteLine("No wonder your parents didn't love you. Your name is terrible. Try again");
                RequestName(ref name);
            }
        }

        void Explore()
        {
            string petName = "flying pitbull dragon thing";
            string enemeyName = "Bandit Keith";
            input = GetInput("Go Left", "Go Right", "You have approached a fork in the road.");
            if (input != '1')
            {
                Console.WriteLine("You head right and walk down a long road. Then suddenly, bandits attack!! They are after your prized possessions!" +
                    "But out of nowhere, a " + petName + "appears and begans swallowing bandits whole. One of those bandits managed to escape with his life." +
                    "It seems like you have befriended the flaying pitbull dragon thing. What would you like to call it?");
                RequestName(ref petName);
                petName = Console.ReadLine();
                Console.WriteLine("Its new name is " + petName);
                Console.ReadKey();
            }
            else if(input == '2')
            {
                Console.WriteLine("You continue on your journey through the lands.");
            }
            Console.Clear();
            Console.WriteLine("The last bandit returns full of rage and states that his name is " + enemeyName + " and that beats just murdered his family.");

            int enemyHealth = 75;
            _GameOver = StartBattle(ref playerHealth, enemyHealth, damage);
        }

        bool StartBattle(ref int playerHealth, int enemyHealth, int damage)
        {
            input = ' ';
            //Creates battle until either the player or enemy is defeated
            while(playerHealth > 0 && enemyHealth > 0)
            {
                //Gets input from the player
                input = GetInput("Attack", "Defend", "What will do?");
                //If input is 1 then the player attacks
                if (input == '1')
                {
                    enemyHealth -= damage;
                    Console.WriteLine("You dealt " + damage + " points of damage");
                }
                //If the input is 2 then the player blocks
                else if(input == '2')
                {
                    Console.WriteLine("You blocked the enemy's attack");
                    continue;
                }
                playerHealth -= 20;
                Console.WriteLine("The enemy dealt 20 points of damage to you");
                Console.ReadKey();
            }
            return playerHealth <= 0;
        }

        //Allows player to move through different enviroments
        void EnterRoom(int roomNumber)
        {
            string exitMessage = "";
            switch (roomNumber)
            {
                case 0:
                    {
                        exitMessage = "You head back to your home in the forest deciding that adventuring is fucking dangerous.";
                        Console.WriteLine("Before you is the Fields of Love, a beautiful seaside hill full of glorious flowers.");
                        break;
                    }
                case 1:
                    {
                        exitMessage = "You head back to the Field of Love.";
                        Console.WriteLine("In front of you stands the Majestic Castle of DOOM");
                        break;
                    }
                case 2:
                    {
                        exitMessage = "You return to the outside of the castle's entrance";
                        Console.WriteLine("You enter the castle's main hall, which is filled with a sparkling chandiler");
                        break;
                    }
                    
            }

            Console.WriteLine("You are in " + roomNumber);
            input = ' ';
            input = GetInput("Go Foward", "Go Back", "Which direction would you like to go?");
            if(input == '1')
            {
                EnterRoom(roomNumber + 1);
            }
            Console.WriteLine(exitMessage);
        }

        void ViewStats(string name, int damage)
        {
            Console.WriteLine("Player Name: " + name);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
        }

        char GetInput(string option1, string option2, string query)
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
                    ViewStats(name, damage);
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
            RequestName(ref name);
            Console.WriteLine("\nGreetings " + name + " Welcome to the World of Beculra!");
            Console.ReadLine();
            Console.Clear();
        }

        //Used for repeating game logic
        public void Update()
        {
            EnterRoom(0);
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("The World has just lost a Great Hero.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
