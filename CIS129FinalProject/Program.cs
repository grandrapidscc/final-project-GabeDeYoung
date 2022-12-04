
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
        bool encountBFor = false;
        bool rndCheck = rnd.Next(2) == 1;
        string navCheck = "";
        string sInput = "A";
        string invalDirection;
        String[] playerActions;
        playerActions = new string[3]{"attack", "flee", "heal"};

        Monster blankMonster = new Monster();



        //Player

        Player player1 = new Player();

        //PRINTS OUT PLAYER LOCATION AND EXIT FOR TESTING
        //Console.WriteLine(playerLocation + " " + exitLocation);

        

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
            sInput.ToLower();



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
                if (currRoom.getMonsterPrez() == false)
                {
                    //sets players last location for flee.
                    
                    //Logic that tells player available directions they can travel.
                    

                    invalDirection = Room.printNavigation(playerLocation);
                    String[] invalDi = invalDirection.Split(" ");
                    
                    


                    sInput = Console.ReadLine().ToLower();
                    
                    bool runCheck = true;

                    //While loop to prevent invalid directional inputs.
                    while (runCheck == true)
                    {
                        if (playerActions.Contains(sInput))
                        {
                            Console.WriteLine("Please input a valid direction...");
                            sInput = Console.ReadLine();
                        }
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
                        Console.WriteLine("You travel through the door to your South.");
                        playerLocation += 5;
                        playerLastMoved = -5;
                        continue;
                    }
                    else if(string.Equals(sInput, "EAST", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door to your East.");
                        playerLocation += 1;
                        playerLastMoved = -1;
                        continue;
                    }
                    else if(string.Equals(sInput, "WEST", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door to your West.");
                        playerLocation -= 1;
                        playerLastMoved = 1;
                        continue;
                    }
                    else if (string.Equals(sInput, "NORTH", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("You travel through the door to your North.");
                        playerLocation -= 5;
                        playerLastMoved = 5;
                        continue;
                    }



                }
                //Executes if room is not empty.
                else if(currRoom.getMonsterPrez() != false)
                {

                    string currMonster = currRoom.getMonsterType();

                    if (encountBFor == false)
                    {
                        blankMonster = blankMonster.monsterMaker(currMonster);
                    }
                    encountBFor = false;

                    //50/50 check to see if monster gets an attack off first.

                    if(rndCheck == true)
                    {
                        Console.WriteLine("A " + currRoom.getMonsterType() + " surprises you!");
                        player1.setPlayerHP(player1.getPlayerHP() - blankMonster.getAttack());
                        Console.WriteLine("You have " + player1.getPlayerHP() + " health.");
                        Console.WriteLine();

                    }

                    currRoom.printDesc();

                    Console.WriteLine("You encounter a " + currMonster + "!");
                    Console.WriteLine("Its current HP is " + blankMonster.getHP());
                    Player.printPlayerActions();
                    Console.WriteLine();
                    sInput = Console.ReadLine();
                    Console.WriteLine();


                    //fight loop.

                    while (blankMonster.getHP() > 0 || player1.getPlayerHP() > 0 || fleeCheck != false)
                    {
                        //attack action
                        if(string.Equals(sInput,"ATTACK", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("You blast the " + currMonster + " with your arcane might!");
                            blankMonster.setHP(blankMonster.getHP() - 5);
                            player1.setPlayerMP(player1.getPlayerMP() - 3);
                            Console.WriteLine("You have " + player1.getPlayerMP() + " mana.");
                            
                        }
                        //heal action
                        else if (string.Equals(sInput, "HEAL", StringComparison.OrdinalIgnoreCase))
                        {
                            
                            player1.Heal();
                            Console.WriteLine();

                        }
                        //flee action
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
                                encountBFor = true;
                                break;
                            }
                        }
                        //flee action if player trys to flee an encounter in the starting room
                        else if (string.Equals(sInput, "FLEE", StringComparison.OrdinalIgnoreCase) && playerLastMoved == 0)
                        {
                            Console.WriteLine("You cannot flee into the unknown.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Please input a valid command");
                            Console.ReadLine();
                        }
                        //Check for player HP
                        

                        //check for monster HP
                        if(blankMonster.getHP() > 0)
                        {
                            //monster attack then check for player HP
                            Console.WriteLine("The " + currMonster + " " + blankMonster.getAttDesc() + "s");
                            player1.setPlayerHP(player1.getPlayerHP() - blankMonster.getAttack());
                            Console.WriteLine("You have " + player1.getPlayerHP() + " health.");
                            if (player1.getPlayerHP() < 1)
                            {
                                fleeCheck = false;
                                break;
                            }
                            //taking player actions
                            Player.printPlayerActions();
                            Console.WriteLine();
                            sInput = Console.ReadLine();
                        }
                        //checking if monster HP drops below zero
                        else if(blankMonster.getHP() <= 0)
                        {
                            Console.WriteLine("You have slain the " + currMonster + "!");
                            currRoom.setEnemy(false);
                            fleeCheck = false;
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
                       
                    }

                }

            }
        }
    }
}