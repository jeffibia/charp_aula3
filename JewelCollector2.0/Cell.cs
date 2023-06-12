namespace JewelCollector2._0;
/// <summary>
/// This Cell interface can be implemented by any object with X and Y axis
/// </summary>
public interface Cell
{
    /// <summary>
    /// This method sets object's X axis
    /// </summary>
    /// <param name="x">Object's X axis</param>
    public void setPosx(int x);
    /// <summary>
    /// This method sets object's Y axis
    /// </summary>
    /// <param name="y">Object's Y axis</param>
    public void setPosy(int y);
    /// <summary>
    /// This method gets object's X axis
    /// </summary>
    /// <returns>Returns object's X axis</returns>
    public int getPosx();
    /// <summary>
    /// This method gets object's Y axis
    /// </summary>
    /// <returns>Returns object's Y axis</returns>
    public int getPosy();
}