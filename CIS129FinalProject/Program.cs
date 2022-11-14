
using Player;
using MapAndNav;
using Monsters;

class Program
{
    static void Main(String[] args)
    {

        //init variables.

        Room roomTest = new Room();
        Monster MTest = new Monster("goblin");

        roomTest.setMonsterType("goblin");
        
        

        roomTest.printRoom(roomTest);
        Console.WriteLine(MTest.getAttack());

        roomTest.setMonsterType("orc");
        MTest.setType(roomTest.getMonsterType());

        roomTest.printRoom(roomTest);
        Console.WriteLine(MTest.getAttack());

        //main while loop




    }
}