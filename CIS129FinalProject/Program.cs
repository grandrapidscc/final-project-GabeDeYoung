
using Players;
using MapAndNav;
using Monsters;
using System;
using System.Collections;
using System.Text.RegularExpressions;

class Program
{
    static void Main(String[] args)
    {

        //init variables.
        Random rnd = new Random();
        int playerLocation = rnd.Next(1, 25);
        int exitLocation = rnd.Next(1, 25);
        bool quitCheck = false;
        string navCheck = "";
        string sInput;

        //ROOM START TEST VARIABLES REMOVE LATER
        playerLocation = 1;
        exitLocation = 3;


        //Player

        Player player1 = new Player();


        Console.WriteLine(playerLocation + " " + exitLocation);

        

        //loop to populate List with room objects for navigation.

        List<Room> roomList = new List<Room>();

        for(int i = 0; i < 25; i++)
        {
          if(i % 3 == 0 && i % 5 != 0)
            {
                roomList.Add(new Room("goblin", "The room reaks of goblin", true, "red"));
            }
          else if(i % 5 == 0)
            {
                roomList.Add(new Room("orc", "You hear the growling of an orc", true, "blue"));

            }
          else if(i % 11 == 0)
            {
                roomList.Add(new Room("banshee", "There is a glowing figure in the middle of the room", false, "blue"));
            }
          else { roomList.Add(new Room()); }
        }


        //Main While loop.
        while (quitCheck != true)
        {
            //checks if player is at exit.
            if(playerLocation == exitLocation)
            {
                Console.WriteLine("YOU WIN!");
                quitCheck = true;
                
            }
            else
            {


                //PUT POTION CHECK HERE LATER!


                var currRoom = roomList[playerLocation];
                //Checks if player is in empty room or not.
                if(currRoom.getMonsterType() == "")
                {
                    //Logic that tells player available directions they can travel.
                    currRoom.printDesc();

                    string invalDirection = Room.printNavigation(playerLocation);
                    String[] invalDi = invalDirection.Split(" ");
                    


                    sInput = Console.ReadLine();
                    bool runCheck = true;

                    //While loop to prevent invalid directional inputs.
                    while (runCheck == true)
                    {
                        if (invalDi.Contains(sInput) || Regex.IsMatch(sInput, @"[!@#$%^&(),.?:{}|<>1-9""]"))
                        {
                            Console.WriteLine("Please input a valid direction...");
                            sInput = Console.ReadLine();
                        }
                        else { runCheck = false;}
                        
                    }
                    //If statements to navigate player through the map.
                    if(sInput.Equals("South"))
                    {
                        Console.WriteLine("You travel through the door on your South.");
                        playerLocation += 5;
                        continue;
                    }
                    else if(sInput.Equals("East"))
                    {
                        Console.WriteLine("You travel through the door on your East.");
                        playerLocation += 1;
                        continue;
                    }
                    else if (sInput.Equals("West"))
                    {
                        Console.WriteLine("You travel through the door on your West.");
                        playerLocation -= 1;
                        continue;
                    }
                    else if (sInput.Equals("North"))
                    {
                        Console.WriteLine("You travel through the door on your East.");
                        playerLocation -= 5;
                        continue;
                    }



                }
                //Executes if room is not empty.
                else if(currRoom.getMonsterType() != "")
                {
                    //Checking for type, then creating a monster object then reading player actions.
                   if(currRoom.getMonsterType() == "goblin")
                    {
                        Console.WriteLine("You encounter a goblin!");
                        Monster goblin = new Monster("goblin");
                        Console.WriteLine("Its current HP is " + goblin.getHP());
                        Console.WriteLine("Press...");
                        Player.printPlayerActions();
                        sInput = Console.ReadLine();
                        
                    }
                   else if (currRoom.getMonsterType() == "orc")
                    {
                        Console.WriteLine("You encounter an orc!");
                        Monster orc = new Monster("orc");
                        Console.WriteLine("Its current HP is " + orc.getHP());
                        Console.WriteLine("Press...");
                        Player.printPlayerActions();
                        sInput = Console.ReadLine();

                    }
                    else if (currRoom.getMonsterType() == "banshee")
                    {
                        Console.WriteLine("You encounter an banshee!");
                        Monster banshee = new Monster("orc");
                        Console.WriteLine("Its current HP is " + banshee.getHP());
                        Console.WriteLine("Press...");
                        Player.printPlayerActions();
                        sInput = Console.ReadLine();

                    }

                }





            }









        }


    }
}