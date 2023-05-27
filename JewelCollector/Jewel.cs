namespace JewelCollector;

public class Jewel
{
    private int posx = -1;
    private int posy = -1;
    private string type;

    private string charp;
    private int value;
    public Jewel(string t){
        type = t;
        switch(t){
            case "Red":
                value = 100;
                charp = "JR";
                break;
            case "Green":
                value = 50;
                charp = "JQ";
                break;
            case "Blue":
                value = 10;
                charp = "JB";
                break;
            default:
                value = 0;
                charp = "-";
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
    public string getCharp(){
        return charp;
    }
    public int getValue(){
        return value;
    }
}