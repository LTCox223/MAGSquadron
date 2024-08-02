using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG_Squadron
{
    public class Game
    {
        public Dictionary<int,MAG> MAGMasterList { get; private set; }
        string UserInput { get; set; }
        int Money { get; set; }
        public enum GameState { Sortie, Briefed, Carrier, Menu};
        public GameState State { get; set; }
        public Carrier Carrier { get; set; }
        public Player Player { get; set; }
        public bool MenuRequest {  get; set; }
        public bool SortieRequest { get; set; }

        public Game()
        {
            Player = new Player();
            Carrier = new Carrier(Player, this);
            UserInput = string.Empty;
            MAGMasterList = new Dictionary<int, MAG>();
            InitializeComponents();
            MainMenu();
        }

        private void InitializeComponents()
        {
            InitializeMenu();
            InitializeMAGList();
        }

        private void InitializeMAGList()
        {
            MAGMasterList.Add(0, new MAG("D-33 Paladin", "MAG designed for CQB Combat", 500,130,120));
            MAGMasterList.Add(1, new MAG("A-3 Trebuchet","MAG designed for Ranged Combat", 500,50,100));
            MAGMasterList.Add(2, new MAG("F-4 Tomahawk", "MAG designed for Multi-role tasks", 500,100,100));

        }

        private void InitializeMenu()
        {
        }

        private void MainMenu()
        {
            bool bValid = false;
            Console.WriteLine("This is the main menu!");
            Console.WriteLine("");
            Console.WriteLine("Type a command! Use the number associated with the command you wish to execute. \n \n");
            Console.WriteLine("1. New Game\n2. Load Game\n3. Exit Game");
            while (!bValid)
            {
                UserInput = Player.PlayerInput();
                State = GameState.Carrier;
                    switch (UserInput)
                    {
                        case "1":
                            Player.Money = 1500;
                            Console.WriteLine("Starting new game. New game will start you on the carrier elevator menu.");
                            Run();
                            break;
                        case "2":
                            Console.WriteLine("I don't do anything yet!");
                            break;
                        case "3":
                            Console.WriteLine("Thanks for Playing!");
                        return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
            }
        }

        private void Run()
        {
            Console.WriteLine("Game Started");
            string inputHolder;
            while (true)
            {
                if (State == GameState.Carrier)
                {
                    Carrier.CarrierDisplay();
                }
                else if (State == GameState.Sortie)
                {
                    Console.WriteLine("Not working right now. Come back soon!");
                }
                else if (State == GameState.Menu)
                {

                }

                inputHolder = Player.PlayerInput(); //grab the players input here.

                if (State == GameState.Carrier)
                {
                    Carrier.CarrierHandleInput(inputHolder);
                }
                else if (State == GameState.Sortie)
                {
                    Console.WriteLine("Not working right now. Come back soon!");
                }

                GameStateChange(); //Update the gamestate.
            }
        }

        private void GameStateChange()
        {
            if (MenuRequest)
            {
                State = GameState.Menu;
            }

            MenuRequest = false;
            SortieRequest = false;
        }

    }
}
