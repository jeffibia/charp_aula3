using System;
using System.Collections;
namespace JewelCollector2._0;
/// <summary>
/// This class Robot represents a robot object on the map
/// </summary>
public class Robot : Cell
{
    private int posx;
    private int posy;
    private int energy;
    private ArrayList bag;
    private int totalpoints;
    private Map m;
    /// <summary>
    /// This constructor initializes a Robot object
    /// </summary>   
    public Robot(Map map) : base(""){
        posx = 0;
        posy = 0;
        this.label = "ME";
        energy = 5;
        bag = new ArrayList();       
        totalpoints = 0;
        m = map;       
    }
    /// <summary>
    /// This method gets Robot X axis
    /// </summary>
    /// <returns>Robot X axis</returns>
    public int getPosx(){
        return posx;
    }
    /// <summary>
    /// This method gets Robot Y axis
    /// </summary>
    /// <returns>Robot Y axis</returns>
    public int getPosy(){
        return posy;
    }
    /// <summary>
    /// This method gets Robot energy
    /// </summary>
    /// <returns>Robot energy</returns>
    public int getEnergy(){
        return energy;
    }
    /// <summary>
    /// This method prints Robot bag jewels
    /// </summary>
    public void printBag (){
        Console.WriteLine("Your Bag have(has) the following jewel(s):");
        if (bag.Count == 0){
            Console.WriteLine("None");
        }
        else{
            IEnumerator e = bag.GetEnumerator();
            while (e.MoveNext()){
                Object j = e.Current;
                Console.WriteLine(j);
            }
        }
        Console.WriteLine("Hit ENTER to continue...");
        Console.ReadLine();
        return;
    }
    /// <summary>
    /// This method prints Robot status: Bag count, Bag totalpoints, Energy
    /// </summary>
    public void printStatus (){
        Console.WriteLine("Bag total jewels: "+bag.Count+" | Bag total value: "+totalpoints+" | Energy: "+energy);
    }
    /// <summary>
    /// This method gets total number of collected jewels
    /// </summary>
    /// <returns>Total number of collected jewels</returns>
    public int totalJewels(){
        return bag.Count;
    }
    /// <summary>
    /// This method moves Robot to a valid adjacent position on the map 
    /// </summary>
    /// <param name="x">New Robot X axis value</param>
    /// <param name="y">New Robot Y axis value</param>
    public void moveRobot(int x, int y){
        Cell? item;
        string? type;
        if (((x >= 0) && (x < m.getLength(0))) && ((y >= 0) && (y < m.getLength(1)))){
            item = m.readItem(x,y);
            type = item.ToString();
            if (type.Equals("--") || type.Equals("!!")){
                if (type.Equals("--")){
                    energy--;
                }
                else{
                    energy -= 30;
                }
                item = m.delItem(posx,posy);
                m.addItem(x,y,item);
                posx = x;
                posy = y;
                collectItems(false);
            }
            else{
                throw new Exception("Invalid move! You can't occupy this object position...");
            }
        }
        else{
            throw new Exception("Invalid move! You can't move outside of map boundaries...");
        }
        return;
    }
    /// <summary>
    /// This method reads robot adjacent items and process them
    /// </summary>
    /// <param name="grab">Grab jewels/recharge robot (true) or check radioactive items (false)</param>
    public void collectItems(Boolean g){
        Cell? item;
        if ((posx-1) >= 0){
            item = m.readItem(posx-1,posy);
            if (g) grab(item,posx-1,posy);
            else if (item.ToString().Equals("!!")) energy -= 10;
        }
        if ((posy-1) >= 0){
            item = m.readItem(posx,posy-1);
            if (g) grab(item,posx,posy-1);
            else if (item.ToString().Equals("!!")) energy -= 10;
        }        
        if ((posx+1) < m.getLength(0)){
            item = m.readItem(posx+1,posy);
            if (g) grab(item,posx+1,posy);
            else if (item.ToString().Equals("!!")) energy -= 10;
        }
        if ((posy+1) < m.getLength(1)){
            item = m.readItem(posx,posy+1);
            if (g) grab(item,posx,posy+1);
            else if (item.ToString().Equals("!!")) energy -= 10;
        }
        return; 
    }
    /// <summary>
    /// This method grabs jewel or recharges robot
    /// </summary>
    /// <param name="item">Map's object</param>
    /// <param name="x">Axis X</param>
    /// <param name="y">Axis Y</param>
    private void grab(Cell item,int x,int y){
        switch(item.ToString()){
            case "JR":
            case "JG":
            case "JB":
                Jewel jw = (Jewel)m.delItem(x,y);
                totalpoints += jw.getPoints();
                bag.Add(jw);
                if (jw.ToString().Equals("JB")) energy += 5;
            break;
            case "$$":
                Obstacle obs = (Obstacle)item;
                energy += obs.getEnergy();           
            break;
        }
    }
}