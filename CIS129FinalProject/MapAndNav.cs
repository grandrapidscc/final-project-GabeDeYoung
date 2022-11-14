using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monsters;

namespace MapAndNav
{
    public class Room
    {
        private bool powerup, enemyPres, exit;
        private string monsterType;
        private string desc;

        //room constructor
        public Room() {
            this.exit = false;
            this.powerup = false;
            this.enemyPres = false;
            desc = "This room is bland and unadorned.";
            monsterType = "";
        }
        public Room(string monsterType, string desc, bool powerup)
        {
            enemyPres = true;
            this.exit = false;
            this.powerup = powerup;
            this.monsterType = monsterType;
            this.desc = desc;
        }


        //setters getters.

        public void setExitTrue()
        {
            this.exit = true;
        }
        public void setPowUpTrue()
        {
            this.powerup = true;
        }
        public void setEnemyTrue()
        {
            this.enemyPres = true;
        }
        public void setDesc(string desc)
        {
            this.desc = desc;
        }
        public void setMonsterType(string monsterType)
        {
            this.monsterType = monsterType;
            setEnemyTrue();
        }
        public bool getExit()
        {
            return exit;
        }
        public String getMonsterType()
        {
            return monsterType;
        }
        //print room commands.

        public void printRoom(Room roomNum)
        {
            Console.WriteLine(desc);
            if(enemyPres == true)
            {
                Console.WriteLine("There is a " + monsterType + " present");
            }
            if(exit == true)
            {
                Console.WriteLine("You see the exit!");
            }
            if(powerup == true)
            {
                Console.WriteLine("There is a " + " potion on the floor.");
            }
        }
    }
    public class MapAndNav
    {






    }
}
