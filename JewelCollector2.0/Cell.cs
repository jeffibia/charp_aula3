namespace JewelCollector2._0;
/// <summary>
/// This abstract Cell class represents an object on the map
/// </summary>
public abstract class Cell
{
    private protected string label;
    /// <summary>
    /// This constructor sets the object label
    /// </summary>
    /// <param name="l">Object label</param>
    public Cell(string l){
        this.label = l;
    }
    /// <summary>
    /// This method overrides ToString method to return object label
    /// </summary>
    /// <returns>Object label</returns>
    public override string ToString(){
        return label;
    }
}