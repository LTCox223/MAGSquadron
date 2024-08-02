using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG_Squadron
{
    public class Player
    {

        public int Money { get; set; }
        public bool isBriefed {  get; set; }
        public Dictionary<int, MAG> PlayerMAGs;

        public Player() 
        {
            PlayerMAGs = new Dictionary<int, MAG>();
        }
        public string PlayerInput() 
        {
            string sendIt = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine("\n");
            return sendIt;
        }
        public void InvalidInput()
        {
            Console.WriteLine("Invalid command. Please use the number associated with the option you want to do.");
        }
    }
}
