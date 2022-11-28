
using Players;
using MapAndNav;
using Monsters;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

class Program
{
    static void Main(String[] args)
    {

        //init variables.
        Random rnd = new Random();
        int playerLocation = rnd.Next(1, 25);
        int playerLastMoved = 0;
        int exitLocation = rnd.Next(1, 25);
        bool quitCheck = false;
        bool fleeCheck = false;
        string navCheck = "";
        string sInput;

        Monster blankMonster = new Monster();

        //ROOM START TEST VARIABLES REMOVE LATER
        playerLocation = 2;
        exitLocation = 1;


        //Player

        Player player1 = new Player();


        Console.WriteLine(playerLocation + " " + exitLocation);

        

        //loop to populate List with room objects for navigation.

        List<Room> roomList = new List<Room>();

        for(int i = 0; i < 25; i++)
        {
          if(i % 3 == 0 && i % 5 != 0)
            {
                roomList.Add(new Room("goblin", "The room reaks of goblin", true, "red", blankMonster.monsterMaker("goblin")));
            }
          else if(i % 5 == 0)
            {
                roomList.Add(new Room("orc", "You hear the growling of an orc", true, "blue", blankMonster.monsterMaker("orc")));

            }
          else if(i % 11 == 0)
            {
                roomList.Add(new Room("banshee", "There is a glowing figure in the middle of the room", false, "blue", blankMonster.monsterMaker("banshee")));
            }
          else { roomList.Add(new Room()); }
        }


        //Main While loop.
        while (quitCheck != true)
        {
            //REMOVE LATER INFO ON CURRENT LOCATION




            //checks if player is at exit.
            if (playerLocation == exitLocation)
            {
                Console.WriteLine("YOU WIN!");
                quitCheck = true;
                
            }
            else if(player1.getPlayerHP() <= 0)
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("You lose!");
                quitCheck = true;
            }
            else
            {
                var currRoom = roomList[playerLocation];

                //Potion check
                if (currRoom.getPowBool() == true && currRoom.getMonsterPrez() == false)
                {
                    if (currRoom.getPowType().Equals("blue")){
                        player1.setPlayerMP(player1.getPlayerMP() + 20);
                        currRoom.setPowUpBool(false);
                        Console.WriteLine("There is a potion alcove by the door, it contains a blue potion. You drink the mysterious substance and your mind becomes sharper.");
                        Console.WriteLine();
                    }
                    else { 
                        player1.setPlayerHP(player1.getPlayerHP() + 10);
                        Console.WriteLine("There is a potion alcove by the door, it contains a red potion. You drink the mysterious substance and feel full of vigor.");
                        Console.WriteLine();
                        currRoom.setPowUpBool(false);
                    }
                }


                
                //Checks if player is in empty room or not.
                if(currRoom.getMonsterType() == "")
                {
                    //sets players last location for flee.
                    
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
                    if(string.Equals(sInput,"South", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door on your South.");
                        playerLocation += 5;
                        playerLastMoved = -5;
                        continue;
                    }
                    else if(string.Equals(sInput, "EAST", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door on your East.");
                        playerLocation += 1;
                        playerLastMoved = -1;
                        continue;
                    }
                    else if(string.Equals(sInput, "WEST", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door on your West.");
                        playerLocation -= 1;
                        playerLastMoved = 1;
                        continue;
                    }
                    else if (string.Equals(sInput, "NORTH", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door on your East.");
                        playerLocation -= 5;
                        playerLastMoved = 5;
                        continue;
                    }



                }
                //Executes if room is not empty.
                else if(currRoom.getMonsterPrez() != false)
                {

                    string currMonster = currRoom.getMonsterType();

                    blankMonster = blankMonster.monsterMaker(currMonster);


                    //50/50 check to see if mosnter gets an attack off first.

                    Console.WriteLine("You encounter a " + currMonster + "!");
                    Console.WriteLine("Its current HP is " + blankMonster.getHP());
                    Console.WriteLine("Press...");
                    Player.printPlayerActions();
                    Console.WriteLine();
                    sInput = Console.ReadLine();


                    //fight loop.

                    while (blankMonster.getHP() > 0 || player1.getPlayerHP() <= 0 || fleeCheck == false)
                    {
                        if(string.Equals(sInput,"ATTACK", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("You blast the " + currMonster + " with your arcane might!");
                            blankMonster.setHP(blankMonster.getHP() - 5);
                            player1.setPlayerMP(player1.getPlayerMP() - 3);
                            Console.WriteLine("You have " + player1.getPlayerMP() + " mana.");
                            //check print out a neat zero instead of negatives for monster hp.
                           
                            
                        }
                        else if (string.Equals(sInput, "HEAL", StringComparison.OrdinalIgnoreCase))
                        {
                            if (player1.getPlayerHP() >= 100)
                            {
                                Console.WriteLine("You heal yourself with magic!");
                                player1.Heal();
                                Console.WriteLine("You have " + player1.getPlayerHP() + " health.");
                                Console.WriteLine("You have " + player1.getPlayerMP() + " mana.");
                            }

                        }
                        else if (string.Equals(sInput, "FLEE", StringComparison.OrdinalIgnoreCase) && playerLastMoved != 0)
                        {
                            if(player1.FleeCheck() == false)
                            {
                                Console.WriteLine("You have failed to get away.");
                            }
                            else
                            {
                                Console.WriteLine("You escape for now...");
                                Console.WriteLine();
                                playerLocation += playerLastMoved;
                                fleeCheck = true;
                                break;
                            }
                        }
                        else if (string.Equals(sInput, "FLEE", StringComparison.OrdinalIgnoreCase) && playerLastMoved == 0)
                        {
                            Console.WriteLine("You cannot flee into the unknown.");
                        }
                        else
                        {
                            Console.WriteLine("Please input a valid command");
                            Console.ReadLine();
                        }
                        //Check for player HP
                        

                        //check for mosnter HP
                        if(blankMonster.getHP() > 0)
                        {
                            Console.WriteLine("The " + currMonster + " " + blankMonster.getAttDesc() + "s");
                            player1.setPlayerHP(player1.getPlayerHP() - blankMonster.getAttack());
                            Console.WriteLine("You have " + player1.getPlayerHP() + " health.");
                            if (player1.getPlayerHP() < 1)
                            {
                                fleeCheck = false;
                                break;
                            }
                            Player.printPlayerActions();
                            sInput = Console.ReadLine();
                        }
                        else if(blankMonster.getHP() <= 0)
                        {
                            Console.WriteLine("You have slain the " + currMonster + "!");
                            currRoom.setEnemy(false);
                            break;
                        }
                    }

                    //potion check after the fight(could be made this a method if needed)
                    if (currRoom.getPowBool() == true && fleeCheck == false)
                    {
                        if (currRoom.getPowType().Equals("blue"))
                        {
                            player1.setPlayerMP(player1.getPlayerMP() + 20);
                            currRoom.setPowUpBool(false);
                            Console.WriteLine("There is a potion alcove by the exit, it contains a blue potion. You drink the mysterious substance and your mind becomes sharper.");
                            Console.WriteLine();
                            
                        }
                        else
                        {
                            player1.setPlayerHP(player1.getPlayerHP() + 10);
                            Console.WriteLine("There is a potion alcove by the exit, it contains a red potion. You drink the mysterious substance and feel full of vigor.");
                            Console.WriteLine();
                            currRoom.setPowUpBool(false);
                            
                        }
                        Room.printNavigation(playerLocation);
                        Console.ReadLine();
                    }
                    






                }





            }









        }


    }
}