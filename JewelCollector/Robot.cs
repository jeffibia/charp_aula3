using System;
namespace JewelCollector;

public class Robot
{
    private int posx = -1;
    private int posy = -1;
    private static string type = "Robot";
    private Jewel?[] bag;
    private int jewels;
    private int totalvalue;
    public Robot(int n){
        bag = new Jewel[n];
        for (int i = 0; i < n; i++){
            bag[i] = null;
        }
        jewels = 0;
        totalvalue = 0;
    }
    public void setPosx(int x){
        posx = x;
        return;
    }
    public void setPosy(int y){
        posy = y;
        return;
    }
    public int getPosx(){
        return posx;
    }
    public int getPosy(){
        return posy;
    }
    public string getType(){
        return type;
    }
    public void printStatus (){
        Console.WriteLine("Bag total items: "+jewels+" | Bag total value: "+totalvalue);
    }
    public void printBag (){
        Console.WriteLine("Your Bag has the following jewels:");
        if (jewels == 0){
            Console.WriteLine("Bag has: None");
            return;
        }
        Console.WriteLine("Bag has:");
        for (int i = 0; i < jewels; i++){
            Console.WriteLine("Jewel "+ bag[i].getType() );
        }
        return;
    }
    public void moveRobot(Map m,int x, int y){
        Object? o = null;
        string type = "";
        Jewel? jewel = null;
        o = m.delObject(x,y);
        if (o == null){
            o = m.delObject(posx,posy);
            m.addObject(x,y,o);
            posx = x;
            posy = y;
            return;
        }
        type = o.GetType()+"";
        type = type.Substring(type.LastIndexOf('.') + 1);
        if (type.Equals("Jewel")){
            jewel = (Jewel) o;
            bag[jewels] = jewel;
            jewels++;
            totalvalue = totalvalue + jewel.getValue();
            o = m.delObject(posx,posy);
            m.addObject(x,y,o);
            posx = x;
            posy = y;
        }
        else{
            Console.WriteLine("Invalid move, try another position.");
            m.addObject(x,y,o);
        }  
        return; 
    }
}
