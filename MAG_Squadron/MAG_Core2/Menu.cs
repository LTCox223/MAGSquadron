using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG_Squadron
{
    public interface Menu
    {
        void DisplayMenu();
        string HandleInput(string input);
    }

    public class ElevatorMenu : Menu
    {
        private Carrier Carrier;
        public string Name {  get; private set; }

        public ElevatorMenu(Carrier carrier)
        {
            this.Carrier = carrier;
            Name = "Carrier Elevator";
            Carrier.currentName = Name;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("1. Hangar\n2. Briefing Room\n3. Pause Menu");
        }

        public string HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    input = "hangar";
                    break;
                case "2":
                    input = "brief";
                    break;
                case "3":
                    input = "menu";
                    break;
                default:
                    input = "-1";
                    break;
            }
            return input;
        }
    }

    public class HangarMenu : Menu
    {
        private Carrier Carrier;
        public string Name { get; private set; }

        public HangarMenu(Carrier carrier)
        {
            this.Carrier = carrier;
            Name = "Carrier Hangar";
            Carrier.currentName = Name;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("1. Check Current MAGs\n2. Purchase new MAGs\n3. Return to Elevator");
        }

        public string HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    input = "check";
                    break;
                case "2":
                    input = "buy";
                    break;
                case "3":
                    input = "elevator";
                    break;
                default:
                    input = "-1";
                    break;
            }
            return input;
        }
    }

    public class BuyMAGsMenu : Menu
    {
        private Carrier Carrier;
        private Player Player;
        public string Name { get; private set; }
        public Dictionary<int, MAG> MasterMAGList;

        public BuyMAGsMenu(Carrier carrier, Player player, Dictionary<int,MAG> masterMAGList)
        {
            this.Carrier = carrier;
            Name = "Buy/Sell MAG Menu";
            Carrier.currentName = Name;
            Player = player;
            MasterMAGList = masterMAGList;
        }
        public void DisplayMenu()
        {
            foreach (var key in MasterMAGList) 
            {
                MAG MAGChoices = MasterMAGList[key.Key];
                Console.WriteLine($"{key.Key+1}. {MAGChoices.Name}: {MAGChoices.Description}.\nCost:{MAGChoices.Cost}");
            }
            Console.WriteLine($"{MasterMAGList.Count()+1}. Exit Buy/Sell");
            Console.WriteLine($"Current funds: {Player.Money}");
        }

        public string HandleInput(string input)
        {
            MAG MAGSelected;
            bool validKey = false;
            int MAGKey=0;
            int ExitValue = MasterMAGList.Count() + 1;

            if (!int.TryParse(input, out MAGKey)) 
            {
                return "-1";
            }
            else if (MAGKey == ExitValue)
            {
                input = "hangar";
            }
            MAGKey -= 1;

            validKey = MasterMAGList.TryGetValue(MAGKey, out MAGSelected);
            if (validKey & MAGSelected != null)
            {
                int PlayerCounts = Player.PlayerMAGs.Count;
                Player.PlayerMAGs.Add(PlayerCounts, MAGSelected);
                Player.Money -= MAGSelected.Cost;
                Console.WriteLine("Purchase successful.");
                input = "buy";
            }
            
            return input;
        }
    }
}
