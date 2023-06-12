namespace JewelCollector2._0;
/// <summary>
/// This Obstacle class represents an obstacle object that implements cell interface
/// </summary>
public class Obstacle : Cell
{
    private int posx;
    private int posy;
    private string label;
    /// <summary>
    /// This constructor initializes an obstacle object
    /// </summary>
    /// <param name="t">Obstacle type: Water, Tree, Radioactive</param>
    public Obstacle(string t){
        posx = -1;
        posy = -1;
        label = "";
        switch(t){
            case "Water":
                label = "##";
                break;
            case "Tree":
                label = "$$";
                break;
            case "Radioactive":
                label = "!!";
                break;
            default:
                throw new Exception("Invalid Obstacle Type!");
        }
    }
    /// <summary>
    /// This method sets Obstacle X axis
    /// </summary>
    /// <param name="x">Obstacle X axis</param>
    public void setPosx(int x){
        posx = x;
        return;
    }
    /// <summary>
    /// This method sets Obstacle Y axis
    /// </summary>
    /// <param name="y">Obstacle Y axis</param>
    public void setPosy(int y){
        posy = y;
        return;
    }
    /// <summary>
    /// This method gets Obstacle X axis
    /// </summary>
    /// <returns>Obstacle X axis</returns>
    public int getPosx(){
        return posx;
    }
    /// <summary>
    /// This method gets Obstacle Y axis
    /// </summary>
    /// <returns>Obstacle Y axis</returns>
    public int getPosy(){
        return posy;
    }
    /// <summary>
    /// This method gets Obstacle label
    /// </summary>
    /// <returns>Obstacle label</returns>
    public override string ToString(){
        return label;
    }
}