using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG_Squadron
{
    public class MAG
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public int Armor {  get; set; }
        public int Core { get; set; }
        //Add a pilot...
        //Add weapons...
        //Add equipment...
        public MAG(string name, string description, int cost, int armor, int core) 
        {
            Name = name;
            Description = description;
            Cost = cost;
            Armor = armor;
            Core = core;
        }
    }

    public class CombatMAG
    {
        private MAG MAG;
        private bool isBackLine;
        private int InitialPosition;
        private int CurrentPosition;

        public CombatMAG(MAG mag, int initialPosition)
        {
            MAG = mag;
            InitialPosition = initialPosition;
            CurrentPosition = InitialPosition;
        }
    }
}
