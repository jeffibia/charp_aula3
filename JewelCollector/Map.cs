using System;
namespace JewelCollector;

public class Map
{
    private Object?[,] map;
    public Map(int x, int y){
        map = new Object[x,y];
        for (int i = 0; i < x; i++){
            for (int j = 0; j < y; j++){
                map[i,j] = null;
            }
        }
    }
    public void addObject(int x, int y, Object o){
        string type = "";
        Jewel? jewel = null;
        Obstacle? obstacle = null;
        Robot? robot = null;
        type = o.GetType()+"";
        type = type.Substring(type.LastIndexOf('.') + 1);
        if (type.Equals("Jewel")){
            jewel = (Jewel) o;
            jewel.setPosx(x);
            jewel.setPosy(y);
        }
        else if (type.Equals("Obstacle")){
            obstacle = (Obstacle) o;
            obstacle.setPosx(x);
            obstacle.setPosy(y);
        }
        else{
            robot = (Robot) o;
            robot.setPosx(x);
            robot.setPosy(y);
        }
        map[x,y] = o;
        return;
    }
    public Object delObject(int x, int y){
        Object? o = map[x,y];
        map[x,y] = null;
        return o;
    }
    public void printMap(){
        string type = "";
        Jewel? jewel = null;
        Obstacle? obstacle = null;
        for (int i = 0; i < map.GetLength(0); i++){
            for (int j = 0; j < map.GetLength(1); j++){
                if (map[i,j] == null){
                    Console.Write("--  ");
                }
                else{
                    type = map[i,j].GetType()+"";
                    type = type.Substring(type.LastIndexOf('.') + 1);
                    if (type.Equals("Jewel")){
                        jewel = (Jewel) map[i,j];
                        switch (jewel.getType()){
                            case "Red":
                            Console.Write("JR  ");
                            break;
                            case "Green":
                            Console.Write("JG  ");
                            break;
                            case "Blue":
                            Console.Write("JB  ");
                            break;
                            default:
                            break;
                        }
                    }
                    else if (type.Equals("Obstacle")){
                        obstacle = (Obstacle) map[i,j];
                        switch (obstacle.getType()){
                            case "Tree":
                            Console.Write("$$  ");
                            break;
                            case "Water":
                            Console.Write("##  ");
                            break;
                            default:
                            break;
                        }
                    }
                    else Console.Write("ME  ");
                }
                continue;                
            } 
            Console.Write("\n");           
        }
        return;
    }
}
