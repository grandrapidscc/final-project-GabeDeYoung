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
        private string powerupType;

        //room constructor
        public Room() {
            this.exit = false;
            this.powerup = false;
            this.enemyPres = false;
            desc = "This room is bland and unadorned.";
            monsterType = "";
        }
        public Room(string monsterType, string desc, bool powerup, string powerupType)
        {
            enemyPres = true;
            this.exit = false;
            this.powerup = powerup;
            this.monsterType = monsterType;
            this.desc = desc;
            this.powerupType = powerupType;
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
        public void setPowType(string type)
        {
            this.powerupType = type;
        }
        public string getPowType()
        {
            return this.powerupType;
        }
        public void setEnemyTrue()
        {
            this.enemyPres = true;
        }
        public void setDesc(string desc)
        {
            this.desc = desc;
        }
        public void printDesc()
        {
            Console.WriteLine(desc);
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

        public static string printNavigation(int playerLocation)
        {
            string invalDirection = "None";
            if (playerLocation < 5 && playerLocation > 1)
            {
                Console.WriteLine("Please enter a direction to travel. South, East, or West.");
                Console.WriteLine("There is a wall to the North.");
                invalDirection = "North";
            }
            else if (playerLocation < 10 && playerLocation > 6)
            {
                Console.WriteLine("Please enter a direction to travel. North, South, East, or West.");
            }
            else if (playerLocation < 15 && playerLocation > 11)
            {
                Console.WriteLine("Please enter a direction to travel. North, South, East, or West.");
            }
            else if (playerLocation < 20 && playerLocation > 16)
            {
                Console.WriteLine("Please enter a direction to travel. North, South, East, or West.");
            }
            else if (playerLocation < 25 && playerLocation > 21)
            {
                Console.WriteLine("Please enter a direction to travel. North, East, or West.");
                Console.WriteLine("There is a wall to the South.");
                invalDirection = "South";
            }
            else if (playerLocation + 4 % 5 == 0 && playerLocation != 1 && playerLocation != 21)
            {
                Console.WriteLine("Please enter a direction to travel. North, South, or East");
                Console.WriteLine("There is a wall to the West.");
                invalDirection = "West";
            }
            else if (playerLocation % 5 == 0 && playerLocation != 5 && playerLocation != 25)
            {
                Console.WriteLine("Please enter a direction to travel. North, South, or West.");
                Console.WriteLine("There is a wall to the East.");
                invalDirection = "East";
            }
            else if (playerLocation == 1)
            {
                Console.WriteLine("Please enter a direction to travel. South, or East.");
                Console.WriteLine("There is a wall to the North and the West.");
                invalDirection = "North West";
            }
            else if (playerLocation == 21)
            {
                Console.WriteLine("Please enter a direction to travel. North, or East.");
                Console.WriteLine("There is a wall to the South and the West.");
                invalDirection = "South West";
            }
            else if (playerLocation == 5)
            {
                Console.WriteLine("Please enter a direction to travel. South, or West.");
                Console.WriteLine("There is a wall to the North and the East.");
                invalDirection = "North East";
            }
            else if (playerLocation == 25)
            {
                Console.WriteLine("Please enter a direction to travel. North, or West.");
                Console.WriteLine("There is a wall to the South and the East.");
                invalDirection = "South East";
            }
            return invalDirection;
        }
    }
}
