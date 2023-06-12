namespace JewelCollector2._0;
/// <summary>
/// This Obstacle class represents an obstacle object on the map
/// </summary>
public class Obstacle : Cell
{
    private int energy;
    /// <summary>
    /// This constructor initializes an obstacle object
    /// </summary>
    /// <param name="t">Obstacle type: Water, Tree, Radioactive</param>
    public Obstacle(string t) : base(""){
        energy = 0;
        switch(t){
            case "Water":
                this.label = "##";
                break;
            case "Tree":
                this.label = "$$";
                energy = 3;
                break;
            case "Radioactive":
                this.label = "!!";
                break;
        }
    }
    /// <summary>
    /// This method gets obstacle energy
    /// </summary>
    /// <returns>Obstacle energy</returns>
    public int getEnergy(){
        int e = energy;
        energy = 0;
        return e;
    }
    /// <summary>
    /// This method returns if obstacle has energy
    /// </summary>
    /// <returns>True or false</returns>
    public Boolean hasEnergy(){
        if (energy > 0) return true;
        else return false;
    }
}