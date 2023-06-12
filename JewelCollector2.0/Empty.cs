namespace JewelCollector2._0;
/// <summary>
/// This Empty class represents an empty object that implements cell interface 
/// </summary>
public class Empty : Cell
{
    private int posx;
    private int posy;
    private string label;
    /// <summary>
    /// This constructor initializes an empty object
    /// </summary>
    public Empty(){
        posx = -1;
        posy = -1;
        label = "--";
    }
    /// <summary>
    /// This method sets Empty X axis
    /// </summary>
    /// <param name="x">Empty X axis</param>
    public void setPosx(int x){
        posx = x;
        return;
    }
    /// <summary>
    /// This method sets Empty Y axis
    /// </summary>
    /// <param name="y">Empty Y axis</param>
    public void setPosy(int y){
        posy = y;
        return;
    }
    /// <summary>
    /// This method gets Empty X axis 
    /// </summary>
    /// <returns>Empty X axis</returns>
    public int getPosx(){
        return posx;
    }
    /// <summary>
    /// This method gets Empty Y axis
    /// </summary>
    /// <returns>Empty Y axis</returns>
    public int getPosy(){
        return posy;
    }
    /// <summary>
    /// This method gets Empty label
    /// </summary>
    /// <returns>Empty label</returns>
    public override string ToString(){
        return label;
    }
}