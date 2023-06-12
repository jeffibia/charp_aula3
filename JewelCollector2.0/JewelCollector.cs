using System;
namespace JewelCollector2._0;
/// <summary>
/// This class starts JewelCollector game
/// </summary>
public class JewelCollector
{     
    static void Main(){
        int phase = 1;
        int dimension = 10;
        Map m = new Map(dimension,dimension);
        Robot r = new Robot(m);
        int jr = 2;
        int jg = 2;
        int jb = 2;
        int wt = 7;
        int tr = 5;
        int rd = 0;
        string command = "";

        m.addItem(0,0,r);
        startPhase(phase,m,jr,jg,jb,wt,tr,rd);
        bool running = true;
        do {
            Console.Clear();            
            m.printMap();
            r.printStatus();

            if (r.getEnergy() <= 0) {
                Console.WriteLine("Game over! Please try again...[y/n]");
                command = Console.ReadLine();
                if (command.Equals("y") || command.Equals("Y")){
                    m = new Map(dimension,dimension);
                    r = new Robot(m);
                    m.addItem(0,0,r);
                    startPhase(phase,m,jr,jg,jb,wt,tr,rd);
                    continue;
                } 
                else break;
            }
            if (r.totalJewels() == (jr+jg+jb)){
                Console.WriteLine("You Won! Hit ENTER to continue...");
                Console.ReadLine();
                phase++;
                dimension++;
                if (dimension > 30){
                    Console.WriteLine("Congratulations! You have completed all phases!");
                    break;
                }
                jr++;
                jg++;
                jb++;
                wt++;
                tr++;
                rd++;
                m = new Map(dimension,dimension);
                r = new Robot(m);
                m.addItem(0,0,r);
                startPhase(phase,m,jr,jg,jb,wt,tr,rd);
                continue;
            }
  
            Console.WriteLine("Enter the command: w,a,s,d,g,p,help,quit...");
            command = Console.ReadLine();
            try{  
                if (command.Equals("quit")) {
                    running = false;
                } else if (command.Equals("w")) {
                    r.moveRobot(r.getPosx()-1,r.getPosy());              
                } else if (command.Equals("a")) {
                    r.moveRobot(r.getPosx(),r.getPosy()-1);  
                } else if (command.Equals("s")) {
                    r.moveRobot(r.getPosx()+1,r.getPosy());             
                } else if (command.Equals("d")) {
                    r.moveRobot(r.getPosx(),r.getPosy()+1); 
                } else if (command.Equals("g")) {  
                    r.collectItems();         
                } else if (command.Equals("p")) {  
                    r.printBag();         
                } else if (command.Equals("help")){
                    Console.WriteLine("");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("****                Help                     ****");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("w: move up");
                    Console.WriteLine("a: move left");
                    Console.WriteLine("s: move down");
                    Console.WriteLine("d: move right");
                    Console.WriteLine("g: collect jewels/energy");
                    Console.WriteLine("p: print bag");
                    Console.WriteLine("ME cannot occupy cells with ##,$$,JR,JG,JB labels");
                    Console.ReadLine();
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine("Hit ENTER to continue...");
                Console.ReadLine();
            }            
      } while (running);
    }
    private static void startPhase(int p,Map map,int red,int green,int blue,int water,int tree,int radio){
        if (p == 1){
            map.addItem(1,9,new Jewel("Red"));
            map.addItem(8,8,new Jewel("Red"));
            map.addItem(9,1,new Jewel("Green"));
            map.addItem(7,6,new Jewel("Green"));
            map.addItem(3,4,new Jewel("Blue"));
            map.addItem(2,1,new Jewel("Blue"));
            map.addItem(5,0,new Obstacle("Water"));
            map.addItem(5,1,new Obstacle("Water"));
            map.addItem(5,2,new Obstacle("Water"));
            map.addItem(5,3,new Obstacle("Water"));
            map.addItem(5,4,new Obstacle("Water"));
            map.addItem(5,5,new Obstacle("Water"));
            map.addItem(5,6,new Obstacle("Water"));
            map.addItem(5,9,new Obstacle("Tree"));
            map.addItem(3,9,new Obstacle("Tree"));
            map.addItem(8,3,new Obstacle("Tree"));
            map.addItem(2,5,new Obstacle("Tree"));
            map.addItem(1,4,new Obstacle("Tree"));
        }                
        else {
            Random num = new Random();
            Boolean populated = false;
            int x = 0;
            int y = 0;
            string type = "";
            while(!populated){
                x = num.Next(0,map.GetLength(0));
                y = num.Next(0,map.GetLength(1));
                type = map.readItem(x,y).ToString()+"";
                if (type.Equals("--")){
                    if (red > 0){
                        map.addItem(x,y,new Jewel("Red"));
                        red--;
                        continue;
                    }
                    if (green > 0){
                        map.addItem(x,y,new Jewel("Green"));
                        green--;
                        continue;
                    }
                    if (blue > 0){
                        map.addItem(x,y,new Jewel("Blue"));
                        blue--;
                        continue;
                    }
                    if (water > 0){
                        map.addItem(x,y,new Obstacle("Water"));
                        water--;
                        continue;
                    }
                    if (tree > 0){
                        map.addItem(x,y,new Obstacle("Tree"));
                        tree--;
                        continue;
                    }
                    if (radio > 0){
                        map.addItem(x,y,new Obstacle("Radioactive"));
                        radio--;
                        continue;
                    }
                }
                else continue;
                break;                
            }
        }              
    }
}