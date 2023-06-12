namespace JewelCollector2._0;
/// <summary>
/// This Jewel class represents a jewel object that implements cell interface
/// </summary>
public class Jewel : Cell
{
    private int posx;
    private int posy;
    private int value;
    private string label;
    private int color;
    /// <summary>
    /// This constructor initializes a jewel object
    /// </summary>
    /// <param name="c">Jewel color: Red, Green or Blue</param>
    public Jewel(string c){
        posx = -1;
        posy = -1;
        value = 0;
        label = "";
        color = 0;
        switch(c){
            case "Red":
                value = 100;
                label = "JR";
                color = 12;
                break;
            case "Green":
                value = 50;
                label = "JG";
                color = 10;
                break;
            case "Blue":
                value = 10;
                label = "JB";
                color = 9;
                break;
            default:
                throw new Exception("Invalid Jewel Type!");
        }
    }
    /// <summary>
    /// This method sets Jewel X axis
    /// </summary>
    /// <param name="x">Jewel X axis</param>
    public void setPosx(int x){
        posx = x;
        return;
    }
    /// <summary>
    /// This method sets Jewel Y axis
    /// </summary>
    /// <param name="y">Jewel Y axis</param>
    public void setPosy(int y){
        posy = y;
        return;
    }
    /// <summary>
    /// This method gets Jewel X axis
    /// </summary>
    /// <returns>Jewel X axis</returns>
    public int getPosx(){
        return posx;
    }
    /// <summary>
    /// This method gets Jewel Y axis
    /// </summary>
    /// <returns>Jewel Y axis</returns>
    public int getPosy(){
        return posy;
    }
    /// <summary>
    /// This method gets Jewel value
    /// </summary>
    /// <returns>Jewel value</returns>
    public int getValue(){
        return value;
    }
    /// <summary>
    /// This method gets Jewel label
    /// </summary>
    /// <returns>Jewel label</returns>
    public override string ToString(){
        return label;
    }
    /// <summary>
    /// This method gets Jewel color
    /// </summary>
    /// <returns>Jewel color</returns>
    public int getColor(){
        return color;
    }
}