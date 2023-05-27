namespace JewelCollector;

public class Obstacle
{
    private int posx = -1;
    private int posy = -1;
    private string type;
    public Obstacle(string t){
        type = t;
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
}