using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class Player
    {
        private int HP = 1;
        private int MP = 1;


        //Constructor
        public Player()
        {
            HP = 100;
            MP = 200;
        }


        //Player actions.
        public void Heal()
        {
            if(MP >= 5)
            {
                this.HP += 3;
                this.MP -= 5;
                Console.WriteLine("Healing energy infuses your body");
                if (HP > 95)
                {
                    int totalSum = 3 - (this.HP - 100);
                    setPlayerHP(100);
                    Console.WriteLine("Health healed: " + totalSum);
                }
                else { Console.WriteLine("Health healed: 5"); }
                
            }
            else { Console.WriteLine("Not enough mana"); }
        }
        

        public bool FleeCheck()
        {
            bool succeed;
            Random rand = new Random();

            if(rand.Next(0, 2) != 0) { succeed = true; }
            else { succeed = false; }
            return succeed;
        }






        //Powerups
        




        //Setters and getters.
        public void setPlayerHP(int HP)
        {
            this.HP = HP;
        }
        public void setPlayerMP(int MP)
        {
            this.MP = MP;
        }
        public int getPlayerHP()
        {
            return HP;
        }
        public int getPlayerMP()
        {
            return MP;
        }

        //playeraction printer
        public static void printPlayerActions()
        {
            Console.WriteLine("Please type an action.");
            Console.WriteLine();
            Console.WriteLine("Attack.");
            Console.WriteLine("Heal.");
            Console.WriteLine("Attempt to Flee.");
        }

    }
}
