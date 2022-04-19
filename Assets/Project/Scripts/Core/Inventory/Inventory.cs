using System.Collections.Generic;
public class Inventory
{
    public List<Slot> Slots { get; private set; }
 // Count slots future for to length 
    public Inventory(ConfigInventory config)
    {    
        Slots = new List<Slot>()
        {
            new Slot(config),
            new Slot(config),
            new Slot(config)
        };       
    }
}
