namespace JewelCollector;

public class Jewel
{
    private int posx = -1;
    private int posy = -1;
    private string type;
    private int value;
    public Jewel(string t){
        type = t;
        switch(t){
            case "Red":
                value = 100;
                break;
            case "Green":
                value = 50;
                break;
            case "Blue":
                value = 10;
                break;
            default:
                value = 0;
                break;
        }
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
    public int getValue(){
        return value;
    }
}