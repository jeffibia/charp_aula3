using System;
namespace JewelCollector;

public class JewelCollector
{   
    static void Main(){
        Map m = new Map(10,10);
        Robot r = new Robot(6);
        
        m.addObject(1,9,new Jewel("Red"));
        m.addObject(8,8,new Jewel("Red"));
        m.addObject(9,1,new Jewel("Green"));
        m.addObject(7,6,new Jewel("Green"));
        m.addObject(9,4,new Jewel("Blue"));
        m.addObject(2,1,new Jewel("Blue"));

        m.addObject(5,0,new Obstacle("Water"));
        m.addObject(5,1,new Obstacle("Water"));
        m.addObject(5,2,new Obstacle("Water"));
        m.addObject(5,3,new Obstacle("Water"));
        m.addObject(5,4,new Obstacle("Water"));
        m.addObject(5,5,new Obstacle("Water"));
        m.addObject(5,6,new Obstacle("Water"));
        m.addObject(5,9,new Obstacle("Tree"));
        m.addObject(3,9,new Obstacle("Tree"));
        m.addObject(8,3,new Obstacle("Tree"));
        m.addObject(2,5,new Obstacle("Tree"));
        m.addObject(1,4,new Obstacle("Tree"));

        m.addObject(0,0,r);
        
        bool running = true;
  
        do {
            m.printMap();
            r.printStatus();
  
            Console.WriteLine("Enter the command: ");
            string command = Console.ReadLine();
  
            if (command.Equals("quit")) {
                running = false;
            } else if (command.Equals("w")) {
                r.moveRobot(m,r.getPosx()-1,r.getPosy());              
            } else if (command.Equals("a")) {
                r.moveRobot(m,r.getPosx(),r.getPosy()-1);  
            } else if (command.Equals("s")) {
                r.moveRobot(m,r.getPosx()+1,r.getPosy());             
            } else if (command.Equals("d")) {
                r.moveRobot(m,r.getPosx(),r.getPosy()+1); 
            } else if (command.Equals("p")) {  
                r.printBag();         
            }
            Console.Clear();
      } while (running);
    }
}