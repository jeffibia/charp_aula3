using System;
using System.Collections;
namespace JewelCollector2._0;
/// <summary>
/// This class Robot represents a Robot object that implements cell interface
/// </summary>
public class Robot : Cell
{
    private int posx;
    private int posy;   
    private string label;
    private int energy;
    private ArrayList bag;
    private int totalvalue;
    private Map m;
    /// <summary>
    /// This constructor initializes a Robot object
    /// </summary>   
    public Robot(Map map){
        posx = -1;
        posy = -1;
        label = "ME";
        energy = 5;
        bag = new ArrayList();       
        totalvalue = 0;
        m = map;       
    }
    /// <summary>
    /// This method sets Robot X axis
    /// </summary>
    /// <param name="x">Robot X axis</param>
    public void setPosx(int x){
        posx = x;
        return;
    }
    /// <summary>
    /// This method sets Robot Y axis
    /// </summary>
    /// <param name="y">Robot Y axis</param>
    public void setPosy(int y){
        posy = y;
        return;
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
    /// This method gets Robot label
    /// </summary>
    /// <returns>Robot label</returns>
    public override string ToString(){
        return label;
    }
    /// <summary>
    /// This method gets Robot energy
    /// </summary>
    /// <returns>Robot energy</returns>
    public int getEnergy(){
        return energy;
    }
    /// <summary>
    /// This method prints Robot status: Bag count, Bag totalvalue, Energy
    /// </summary>
    public void printStatus (){
        Console.WriteLine("Bag total items: "+bag.Count+" | Bag total value: "+totalvalue+" | Energy: "+energy);
    }
    /// <summary>
    /// This method prints Robot bag items
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
    /// This method gets total number of collected jewels
    /// </summary>
    /// <returns>Total number of collected jewels</returns>
    public int totalJewels(){
        return bag.Count;
    }
    /// <summary>
    /// This method moves Robot to a valid adjacent cell on the map 
    /// </summary>
    /// <param name="x">New Robot X axis value</param>
    /// <param name="y">New Robot Y axis value</param>
    public void moveRobot(int x, int y){
        if (((x >= 0) && (x < m.GetLength(0))) && ((y >= 0) && (y < m.GetLength(1)))){
            Cell item = m.readItem(x,y);
            string type = item.ToString()+"";
            if (type.Equals("--") || type.Equals("!!")){
                if (type.Equals("--")){
                    energy--;
                }
                else{
                    energy = energy - 30;
                }
                item = m.delItem(posx,posy);
                m.addItem(x,y,item);
                checkAdjCells();
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
    /// This method collects objects or recharge Robot from adjacent cells on the map
    /// </summary>
    public void collectItems(){
        Cell[] adjList = new Cell[4];
        int qty = 0;
        if ((posx-1) >= 0){
            adjList[qty] = m.readItem(posx-1,posy);
            qty++;
        }
        if ((posy-1) >= 0){
            adjList[qty] = m.readItem(posx,posy-1);
            qty++;
        }        
        if ((posx+1) < m.GetLength(0)){
            adjList[qty] = m.readItem(posx+1,posy);
            qty++;
        }
        if ((posy+1) < m.GetLength(1)){
            adjList[qty] = m.readItem(posx,posy+1);
            qty++;
        }
        for (int i = 0; i < qty; i++)
            switch(adjList[i].ToString()){
                case "JR":
                case "JG":
                case "JB":
                Jewel j = (Jewel)m.delItem(adjList[i].getPosx(),adjList[i].getPosy());
                totalvalue += j.getValue();
                bag.Add(j);
                if (j.ToString().Equals("JB")) energy += 5;
                break;
                case "$$":
                energy += 3;
                break;
            }
        return; 
    }
    /// <summary>
    /// This method checks Robot adjacent cells on the map for radioactive obstacle
    /// </summary>
    public void checkAdjCells(){
        Cell[] adjList = new Cell[4];
        int qty = 0;
        if ((posx-1) >= 0){
            adjList[qty] = m.readItem(posx-1,posy);
            qty++;
        }
        if ((posy-1) >= 0){
            adjList[qty] = m.readItem(posx,posy-1);
            qty++;
        }        
        if ((posx+1) < m.GetLength(0)){
            adjList[qty] = m.readItem(posx+1,posy);
            qty++;
        }
        if ((posy+1) < m.GetLength(1)){
            adjList[qty] = m.readItem(posx,posy+1);
            qty++;
        }
        for (int i = 0; i < qty; i++){
            Console.WriteLine("Entrou");
            if (adjList[i].ToString().Equals("!!")){
                energy -= 10;
            }             
        }
        return; 
    }
}