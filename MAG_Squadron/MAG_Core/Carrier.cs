using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG_Squadron
{
    public class Carrier
    {

        public Menu currentMenu;
        public string currentName {get; set;}
        private Player Player;
        private Game Game;
        public Carrier(Player player, Game game) 
        {
            currentName = "Unknown. You shouldn't have got here...";
            currentMenu = new ElevatorMenu(this);
            Player = player;
            Game = game;
        }
        
        public void CarrierDisplay()
        {
            Console.WriteLine($"You are currently in {currentName}. Select an Option");
            currentMenu.DisplayMenu();
        }

        public void CarrierHandleInput(string input)
        {
            SwitchMenu(currentMenu.HandleInput(input));
        }

        public void SwitchMenu(string input)
        {
            switch (input)
            {
                case "hangar":
                    currentMenu = new HangarMenu(this);
                    break;

                case "brief":
                    Player.isBriefed = true;
                    Console.WriteLine("Player is briefed. This is placeholder to be expanded on");
                    break;
                case "menu":
                    Game.MenuRequest = true;
                    break;
                case "buy":
                    currentMenu = new BuyMAGsMenu(this, Player, Game.MAGMasterList);
                    break;
                case "elevator":
                    currentMenu = new ElevatorMenu(this);
                    break;
                case "check":
                    HangarCheck();
                    break;
                default:
                    Player.InvalidInput();
                    break;
            }
        }
        public void HangarCheck()
        {

            if (Player.PlayerMAGs.Count() == 0)
            {
                Console.WriteLine("No MAGs in the Hangar. Consider Purchasing some.");
                return;
            }
            foreach (var key in Player.PlayerMAGs)
            {
                MAG MAGChoices = Player.PlayerMAGs[key.Key];
                Console.WriteLine($"{key.Key + 1}. {MAGChoices.Name}: {MAGChoices.Description}.");
            }
        }
    }
}
