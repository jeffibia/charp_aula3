using System;
namespace JewelCollector2._0;
/// <summary>
/// This class starts JewelCollector game
/// </summary>
public class JewelCollector
{     
    delegate void moveRobot(int x, int y);
    delegate void collectItems(Boolean g);
    delegate void printBag();
    static event moveRobot OnMoveRobot;
    static event collectItems OnCollectItems;
    static event printBag OnPrintBag;
    static void Main(){
        int lvl = 1;
        int dimension = 10;
        int jr = 2;
        int jg = 2;
        int jb = 2;
        int wt = 7;
        int tr = 5;
        int rd = 0;
        bool running = true;
        // Start Game
        Map m = new Map(dimension,dimension);
        Robot r = new Robot(m);
        m.addItem(0,0,r);
        OnMoveRobot += r.moveRobot;
        OnCollectItems += r.collectItems;
        OnPrintBag += r.printBag;
        loadMap(lvl,m,jr,jg,jb,wt,tr,rd);
        do {
            Console.Clear();            
            m.printMap();
            r.printStatus();

            // You lost
            if (r.getEnergy() <= 0) {
                Console.WriteLine("Game over! Please try again...[y/n]");
                ConsoleKeyInfo entered1 = Console.ReadKey(true);
                if (entered1.Key.ToString().Equals("Y")){
                    OnMoveRobot -= r.moveRobot;
                    OnCollectItems -= r.collectItems;
                    OnPrintBag -= r.printBag;
                    // Restart game
                    m = new Map(dimension,dimension);
                    r = new Robot(m);
                    m.addItem(0,0,r);
                    OnMoveRobot += r.moveRobot;
                    OnCollectItems += r.collectItems;
                    OnPrintBag += r.printBag;
                    loadMap(lvl,m,jr,jg,jb,wt,tr,rd);
                    continue;
                } 
                else break;
            }

            // You won
            if (r.totalJewels() == (jr+jg+jb)){
                Console.WriteLine("You Won! Hit ENTER to play next level...");
                Console.ReadLine(); 
                lvl++;               
                dimension++;
                if (dimension > 30){
                    Console.WriteLine("Congratulations! You have completed all levels!");
                    break;
                }
                jr++;
                jg++;
                jb++;
                wt++;
                tr++;
                rd++;
                OnMoveRobot -= r.moveRobot;
                OnCollectItems -= r.collectItems;
                OnPrintBag -= r.printBag;
                // Start next level
                m = new Map(dimension,dimension);
                r = new Robot(m);
                m.addItem(0,0,r);
                OnMoveRobot += r.moveRobot;
                OnCollectItems += r.collectItems;
                OnPrintBag += r.printBag;   
                loadMap(lvl,m,jr,jg,jb,wt,tr,rd);
                continue;
            }

            // Play  
            Console.WriteLine("Enter the command: w,a,s,d,g,p,(h)elp,(q)uit...");
            ConsoleKeyInfo entered = Console.ReadKey(true);

            try{
                switch (entered.Key.ToString())
                {
                    case "W":
                        OnMoveRobot(r.getPosx()-1,r.getPosy());
                        break;
                    case "A":
                        OnMoveRobot(r.getPosx(),r.getPosy()-1); 
                        break;
                    case "S":
                        OnMoveRobot(r.getPosx()+1,r.getPosy());
                        break;
                    case "D":
                        OnMoveRobot(r.getPosx(),r.getPosy()+1); 
                        break;
                    case "G": 
                        OnCollectItems(true); 
                        break;
                    case "P":
                        OnPrintBag();
                        break;
                    case "H":
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
                        Console.WriteLine("ME cannot occupy cells with [##,$$,JR,JG,JB] labels");
                        Console.WriteLine("Hit ENTER to continue...");
                        Console.ReadLine();
                        break;
                    case "Q": 
                        running = false;
                        break;
                    default: 
                        Console.WriteLine("Invalid option entered...Hit ENTER to continue...");
                        Console.ReadLine(); 
                        break;
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine("Hit ENTER to continue...");
                Console.ReadLine();
            }            
      } while (running);
    }
    /// <summary>
    /// This private method loads items into the map, either fixed for level 1, or randomly for next levels
    /// </summary>
    /// <param name="level">Game level</param>
    /// <param name="map">Map</param>
    /// <param name="red">Number of Red Jewels</param>
    /// <param name="green">Number of Green Jewels</param>
    /// <param name="blue">Number of Blue Jewels</param>
    /// <param name="water">Number of Water instances</param>
    /// <param name="tree">Number of Tree instances</param>
    /// <param name="radio">Number of Radioactive instances</param>
    private static void loadMap(int level,Map map,int red,int green,int blue,int water,int tree,int radio){
        if (level == 1){
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
            string? type = "";
            while(!populated){
                x = num.Next(0,map.getLength(0));
                y = num.Next(0,map.getLength(1));
                type = map.readItem(x,y).ToString();
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
                    break;
                }
                else continue;                
            }
        }              
    }
}