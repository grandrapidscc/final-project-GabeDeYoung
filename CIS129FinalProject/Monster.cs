using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    public class Monster
    {   
        public string type;
        private int HP;
        private int attack;
        private string attDesc;

        //constructors
        public Monster()
        {
            this.HP = 3;
            this.attack = 2;
            this.type = "goblin";
            this.attDesc = "Slam";
        }
        public Monster(string monsterType)
        {
            this.type = monsterType;
            string temp = monsterType;
            if (monsterType == "goblin")
            {
                this.HP = 3;
                this.attack = 2;
                this.attDesc = "Body Slam";
            }
            else if(monsterType == "orc")
            {
                this.HP = 5;
                this.attack = 3;
                this.attDesc = "Cleave";
            }
            else if (monsterType == "banshee")
            {
                this.HP = 8;
                this.attack = 5;
                this.attDesc = "Screech";
            }
            else
            {
                this.HP = 0;
                this.attack = 0;
                this.attDesc = "None";
            }
            
        }
              
        //setters and getters
        public void setType(string type)
        {
            this.type = type;
            if (type == "goblin")
            {
                this.HP = 3;
                this.attack = 2;
                this.attDesc = "Body Slam";
            }
            else if (type == "orc")
            {
                this.HP = 5;
                this.attack = 3;
                this.attDesc = "Cleave";
            }
            else if (type == "banshee")
            {
                this.HP = 8;
                this.attack = 5;
                this.attDesc = "Screech";
            }
            else
            {
                this.HP = 0;
                this.attack = 0;
                this.attDesc = "None";
            }
        }
        public void setHP(int HP)
        {
            this.HP = HP;
        }
        public void setAttack(int attack)
        {
            this.attack = attack;
        }
        public void setAttDesc(string attDesc)
        {
            this.attDesc = attDesc;
        }

        public string getType()
        {
            return type;
        }
        public int getHP()
        {
            return HP;
        }
        public int getAttack()
        {
            return attack;
        }
        public string getAttDesc()
        {
            return attDesc;
        }
        



        //monster spawner based on room.

        public Monster monsterMaker(string monsterType)
        {
            Monster monster = null;


            if (monsterType.Equals("goblin"))
            {
                monster = new Monster("goblin");
            }
            else if (monsterType.Equals("orc"))
            {
                monster = new Monster("orc");
            }
            else if (monsterType.Equals("banshee"))
            { 
                monster = new Monster("banshee");
            }
            else
            {
                monster = new Monster();
            }



            return monster;
        }

    }
}
