namespace JewelCollector2._0;
/// <summary>
/// This Jewel class represents a jewel object on the map
/// </summary>
public class Jewel : Cell
{
    private int points;
    private int color;
    /// <summary>
    /// This constructor initializes a jewel object
    /// </summary>
    /// <param name="c">Jewel color: Red, Green or Blue</param>
    public Jewel(string c) : base(""){
        points = 0;
        color = 0;
        switch(c){
            case "Red":
                this.label = "JR";
                points = 100;
                color = 12;
                break;
            case "Green":
                this.label = "JG";
                points = 50;
                color = 10;
                break;
            case "Blue":
                this.label = "JB";
                points = 10;
                color = 9;
                break;
        }
    }
    /// <summary>
    /// This method gets Jewel points
    /// </summary>
    /// <returns>Jewel points</returns>
    public int getPoints(){
        int p = points;
        points = 0;
        return p;
    }
    /// <summary>
    /// This method gets Jewel color
    /// </summary>
    /// <returns>Jewel color</returns>
    public int getColor(){
        return color;
    }
}