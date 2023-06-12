using System;
namespace JewelCollector2._0;
/// <summary>
/// This class Map represents a bidimensional map of objects of Cell type
/// </summary>
public class Map
{
    private Cell[,] map;
    /// <summary>
    /// This constructor initializes a map object
    /// </summary>
    /// <param name="x">Axis X size</param>
    /// <param name="y">Axis Y size</param>
    public Map(int x, int y){
        map = new Cell[x,y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
                map[i,j] = new Empty();
    }
    /// <summary>
    /// Method that adds an object to the map
    /// </summary>
    /// <param name="x">Axis X position</param>
    /// <param name="y">Axis Y position</param>
    /// <param name="item">Object</param>
    public void addItem(int x, int y, Cell item){
        map[x,y] = item;
        return;
    }
    /// <summary>
    /// Method that removes an object from the map
    /// </summary>
    /// <param name="x">Axis X position</param>
    /// <param name="y">Axis Y position</param>
    /// <returns>Map's object</returns>
    public Cell delItem(int x, int y){
        Cell item = map[x,y];
        map[x,y] = new Empty();
        return item;
    }    
    /// <summary>
    /// Method that reads an object from the map 
    /// </summary>
    /// <param name="x">Axis X position</param>
    /// <param name="y">Axis Y position</param>
    /// <returns>Map's object</returns>
    public Cell readItem(int x,int y){
        return map[x,y];
    }
    /// <summary>
    /// Method that returns map dimension size
    /// </summary>
    /// <param name="dimension">Dimension: Axis X (0), Axis Y (1)</param>
    /// <returns>Map's dimension size</returns>
    public int getLength(int dimension){
        return map.GetLength(dimension);
    }
    /// <summary>
    /// Method that prints map
    /// </summary>
    public void printMap(){
        string? type;
        for (int i = 0; i < map.GetLength(0); i++){
            for (int j = 0; j < map.GetLength(1); j++){
                type = map[i,j].ToString();
                switch(type){
                    case "JR":
                    case "JG":
                    case "JB":
                        Jewel jw = (Jewel)map[i,j];
                        Console.BackgroundColor = (ConsoleColor)jw.getColor();
                        Console.Write(map[i,j]);
                        Console.ResetColor();
                        Console.Write("  ");
                        break;
                    case "ME":
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(map[i,j]);
                        Console.ResetColor();
                        Console.Write("  ");
                        break;
                    case "$$":
                        Obstacle obs = (Obstacle)map[i,j];
                        if (obs.hasEnergy()){
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i,j]);
                            Console.ResetColor();
                            Console.Write("  ");
                        }
                        else Console.Write(map[i,j]+"  ");
                        break;
                    default:
                        Console.Write(map[i,j]+"  ");
                        break;
                }
            }
            Console.Write("\n");           
        }
        return;
    }
}